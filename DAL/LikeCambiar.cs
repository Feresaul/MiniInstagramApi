using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class LikeCambiar : DBInstagramState
    {
        public LikeCambiar() { }
        public void CambiarEstado(string usuario, string nombre, int id)
        {
            Conectar();
            string sql = $"select * from {nombre}_{id}_LIKES where nombre_usuario = '{usuario}';";
            var adaptador = new SqlDataAdapter(sql, sqlconnection);
            dataset = new System.Data.DataSet();
            adaptador.Fill(dataset, "Likes");

            var lista = new List<string>();
            foreach (DataRow row in dataset.Tables["Likes"].Rows)
            {
                lista.Add(row["nombre_usuario"].ToString());
            }

            if (lista.Count <= 0)
            {
                sql = $"insert into {nombre}_{id}_LIKES (nombre_usuario) values ('{usuario}');";
                var cmd = new SqlCommand(sql, sqlconnection);
                cmd.ExecuteNonQuery();
            }
            else
            {
                sql = $"delete from {nombre}_{id}_LIKES where nombre_usuario = '{usuario}';";
                var cmd = new SqlCommand(sql, sqlconnection);
                cmd.ExecuteNonQuery();
            }

            Desconectar();
        }
    }
}
