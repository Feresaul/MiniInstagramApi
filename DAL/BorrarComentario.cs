using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class BorrarComentario : DBInstagramState
    {
        public BorrarComentario() { }
        public void CambiarEstado(string nombre, int id, int id_comment)
        {
            Conectar();
            string sql = $"delete from {nombre}_{id}_COMENTARIOS  where id_comentario={id_comment};";
            var cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            Desconectar();
        }
    }
}
