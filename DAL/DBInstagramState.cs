using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace DAL
{
    public class DBInstagramState
    {
        protected string url;
        protected DataSet dataset;
        protected SqlConnection sqlconnection;

        public DBInstagramState()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();
            url = config.GetConnectionString("SQLDev");
        }

        public bool Conectar()
        {
            sqlconnection = new SqlConnection(url);
            sqlconnection.Open();
            return (sqlconnection.State == ConnectionState.Open);
        }

        public void Desconectar()
        {
            url = "";
            if (sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }

    }
}
