using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class SeguirCambiar : DBInstagramState
    {
        public SeguirCambiar() { }
        public void CambiarEstado(string usuario, string nombre)
        {
            Conectar();
            string sql = $"select * from {usuario}_SEGUIDOS where nombre_usuario = '{nombre}';";
            var adaptador = new SqlDataAdapter(sql, sqlconnection);
            dataset = new System.Data.DataSet();
            adaptador.Fill(dataset, "Seguidos");
            sql = $"select * from {nombre}_SEGUIDORES where nombre_usuario = '{usuario}';";
            adaptador = new SqlDataAdapter(sql, sqlconnection);
            adaptador.Fill(dataset, "Seguidores");

            var lista = new List<string>();
            foreach (DataRow row in dataset.Tables["Seguidos"].Rows)
            {
                lista.Add(row["nombre_usuario"].ToString());
            }

            if (lista.Count <= 0)
            {
                sql = $"insert into {usuario}_SEGUIDOS (nombre_usuario) values ('{nombre}');";
                var cmd = new SqlCommand(sql, sqlconnection);
                cmd.ExecuteNonQuery();
                sql = $"insert into {nombre}_SEGUIDORES (nombre_usuario) values ('{usuario}');";
                cmd = new SqlCommand(sql, sqlconnection);
                cmd.ExecuteNonQuery();
            }
            else
            {
                sql = $"delete from {usuario}_SEGUIDOS  where nombre_usuario = '{nombre}';";
                var cmd = new SqlCommand(sql, sqlconnection);
                cmd.ExecuteNonQuery();
                sql = $"delete from {nombre}_SEGUIDORES  where nombre_usuario = '{usuario}';";
                cmd = new SqlCommand(sql, sqlconnection);
                cmd.ExecuteNonQuery();
            }

            Desconectar();
        }
    }
}
