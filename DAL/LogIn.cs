using Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class LogIn : DBInstagram
    {
        private string usuario;
        private string correo;
        public LogIn(Instagram instagram)
        {
            usuario = instagram.user;
            correo = instagram.correo;
        }
        public override Instagram Procesar()
        {
            var insta = new Instagram();
            foreach (DataRow row in dataset.Tables["Login"].Rows)
            {
                insta.contrasenia = (row["contrasenia"].ToString());
            }
            return insta;
        }

        public override void Seleccionar()
        {
            string sql = $"select * from USUARIOS where nombre_usuario = '{usuario}' or correo = '{correo}';";
            var adaptador = new SqlDataAdapter(sql, sqlconnection);
            dataset = new System.Data.DataSet();
            adaptador.Fill(dataset, "Login");
        }
    }
}
