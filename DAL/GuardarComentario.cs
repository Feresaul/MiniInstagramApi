using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

namespace DAL
{
    public class GuardarComentario : DBInstagramState
    {
        public GuardarComentario() { }
        public void CambiarEstado(string usuario, string nombre, int id, string texto)
        {
            Conectar();
            string sql = $"select count(*) from {nombre}_{id}_COMENTARIOS";
            SqlCommand cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int index = (int)reader[0];
            reader.Close();
            int max = 0;
            if (index > 0)
            {
                sql = $"select max(id_comentario) from {nombre}_{id}_COMENTARIOS";
                cmd = new SqlCommand(sql, sqlconnection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                reader.Read();
                max = (int)reader[0];
                reader.Close();
            }

            if ((int)index != 0)
                index = max+1; 

            sql = $"insert into {nombre}_{id}_COMENTARIOS (id_comentario, nombre_usuario, texto) values ({index},'{usuario}','{texto}');";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            Desconectar();
        }
    }
}
