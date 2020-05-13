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
    public abstract class DBInstagram
    {
        protected string url;
        protected DataSet dataset;
        protected SqlConnection sqlconnection;

        public DBInstagram()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();
            url = config.GetConnectionString("SQLDev");
        }

        public virtual bool Conectar()
        {
            sqlconnection = new SqlConnection(url);
            sqlconnection.Open();
            return (sqlconnection.State == ConnectionState.Open);
        }

        public virtual void Desconectar()
        {
            url = "";
            if (sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }

        public abstract void Seleccionar();
        public abstract Instagram Procesar();


        //Template method
        public Instagram Ejecutar()
        {
            var datos = new Instagram();
            if (Conectar())
            {
                Seleccionar();
                datos = Procesar();
                Desconectar();
            }
            return datos;
        }
    }
}
