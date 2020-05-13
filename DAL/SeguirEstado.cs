using Core.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace DAL
{
    public class SeguirEstado : DBInstagramState
    {
        public SeguirEstado() { }
        public bool ObtenerEstado(string usuario, string nombre)
        {
            Conectar();
            string sql = $"select * from {usuario}_SEGUIDOS where nombre_usuario = '{nombre}';";
            var adaptador = new SqlDataAdapter(sql, sqlconnection);
            dataset = new System.Data.DataSet();
            adaptador.Fill(dataset, "Estado");
            var lista = new List<string>();
            foreach (DataRow row in dataset.Tables["Estado"].Rows)
            {
                lista.Add(row["nombre_usuario"].ToString());
            }
            Desconectar();
            if (lista.Count > 0) return true;
            return false;
        }
    }
}
