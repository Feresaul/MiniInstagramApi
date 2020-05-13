using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class GuardarCambiar : DBInstagramState
    {
        public GuardarCambiar() { }
        public void CambiarEstado(string usuario, string nombre, int id)
        {
            Conectar();
            string sql = $"select * from {usuario}_GUARDADO where nombre_usuario = '{nombre}' and id_foto = {id};";
            var adaptador = new SqlDataAdapter(sql, sqlconnection);
            dataset = new System.Data.DataSet();
            adaptador.Fill(dataset, "Guardado");

            var lista = new List<string>();
            foreach (DataRow row in dataset.Tables["Guardado"].Rows)
            {
                lista.Add(row["nombre_usuario"].ToString());
            }

            if (lista.Count <= 0)
            {
                sql = $"insert into {usuario}_GUARDADO (nombre_usuario,id_foto) values ('{nombre}',{id});";
                var cmd = new SqlCommand(sql, sqlconnection);
                cmd.ExecuteNonQuery();
                sql = $"insert into {nombre}_{id}_GUARDADO (nombre_usuario) values ('{usuario}');";
                cmd = new SqlCommand(sql, sqlconnection);
                cmd.ExecuteNonQuery();
            }
            else
            {
                sql = $"delete from {usuario}_GUARDADO  where nombre_usuario = '{nombre}' and id_foto ={id};";
                var cmd = new SqlCommand(sql, sqlconnection);
                cmd.ExecuteNonQuery();
                sql = $"delete from {nombre}_{id}_GUARDADO  where nombre_usuario = '{usuario}';";
                cmd = new SqlCommand(sql, sqlconnection);
                cmd.ExecuteNonQuery();
            }

            Desconectar();
        }
    }
}
