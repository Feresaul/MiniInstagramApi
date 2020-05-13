using Core.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace DAL
{
    public class Busqueda : DBInstagramState
    {
        public Busqueda()
        {
        }
        public List<string> Buscar(string user, string busqueda)
        {
            Conectar();

            var lista = new List<string>();
            string sql = $"select * from USUARIOS where nombre_usuario like '%{busqueda}%' and nombre_usuario <> '{user}'";
            var adaptador = new SqlDataAdapter(sql, sqlconnection);
            dataset = new System.Data.DataSet();
            adaptador.Fill(dataset, "Busqueda");
            foreach (DataRow row in dataset.Tables["Busqueda"].Rows)
            {
                lista.Add(row["nombre_usuario"].ToString());
            }
            Desconectar();

            return lista;
        }
    }
}
