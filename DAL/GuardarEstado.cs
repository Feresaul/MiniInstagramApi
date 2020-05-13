using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class GuardarEstado : DBInstagramState
    {
        public GuardarEstado() { }
        public bool ObtenerEstado(string usuario, string nombre, int id)
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
            Desconectar();
            if (lista.Count > 0) return true;
            return false;
        }
    }
}
