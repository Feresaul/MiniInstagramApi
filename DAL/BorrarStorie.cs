using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class BorrarStorie : DBInstagramState
    {
        public BorrarStorie() { }
        public void EliminarStories(string usuario)
        {
            Conectar();
            string sql = $"delete from {usuario}_STORIES;";
            var cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            Desconectar();
        }
    }
}
