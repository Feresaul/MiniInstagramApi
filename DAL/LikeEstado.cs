using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class LikeEstado : DBInstagramState
    {
        public LikeEstado() { }
        public bool ObtenerEstado(string usuario, string nombre, int id)
        {
            Conectar();
            string sql = $"select * from {nombre}_{id}_LIKES where nombre_usuario = '{usuario}';";
            var adaptador = new SqlDataAdapter(sql, sqlconnection);
            dataset = new System.Data.DataSet();
            adaptador.Fill(dataset, "Like");
            var lista = new List<string>();
            foreach (DataRow row in dataset.Tables["Like"].Rows)
            {
                lista.Add(row["nombre_usuario"].ToString());
            }
            Desconectar();
            if (lista.Count > 0) return true;
            return false;
        }
    }
}
