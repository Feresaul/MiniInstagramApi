using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class EditarPerfil : DBInstagramState
    {
        public EditarPerfil() { }
        public void Editar(string usuario, string url, string biografia)
        {
            Conectar();
            string sql = $"update {usuario}_PERFIL  set foto = '{url}' , biografia = '{biografia}';";
            var cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            Desconectar();
        }
    }
}
