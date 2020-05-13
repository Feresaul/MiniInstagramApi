using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class BorrarPost : DBInstagramState
    {
        public BorrarPost() { }
        public void EliminarPost(string usuario, int id)
        {
            Conectar();
            string sql = $"delete from {usuario}_POSTS  where id_foto = {id};";
            var cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            sql = $"drop table {usuario}_{id}_LIKES ;";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            sql = $"drop table {usuario}_{id}_COMENTARIOS ;";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            sql = $"select * from {usuario}_{id}_GUARDADO;";
            var adaptador = new SqlDataAdapter(sql, sqlconnection);
            dataset = new System.Data.DataSet();
            adaptador.Fill(dataset, "Usuarios");
            foreach (DataRow row in dataset.Tables["Usuarios"].Rows)
            {
                sql = $"delete from {row["nombre_usuario"].ToString()}_GUARDADO where nombre_usuario = '{usuario}' and id_foto ={id} ;";
                cmd = new SqlCommand(sql, sqlconnection);
                cmd.ExecuteNonQuery();
            }
            sql = $"drop table {usuario}_{id}_GUARDADO ;";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            Desconectar();
        }
    }
}
