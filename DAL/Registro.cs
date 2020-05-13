using Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    class Registro : DBInstagram
    {
        private string usuario;
        private string nombre;
        private string correo;
        private string contrasenia;
        public Registro(Instagram instagram)
        {
            usuario = instagram.user;
            nombre = instagram.nombre;
            correo = instagram.correo;
            contrasenia = instagram.contrasenia;
        }
        public override Instagram Procesar()
        {
            var insta = new Instagram();
            foreach (DataRow row in dataset.Tables["Registro"].Rows)
            {
                insta.contrasenia = (row["contrasenia"].ToString());
            }
            if (insta.contrasenia != null) return insta;

            string sql = $"select count(*) from USUARIOS";
            SqlCommand cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            var index = reader[0];
            reader.Close();
           

            sql = $"insert into USUARIOS (id_usuario,nombre_usuario,nombre_completo,correo,contrasenia) " +
                $"values ({index},'{usuario}','{nombre}','{correo}','{contrasenia}')";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();

            sql = $"create table {usuario}_SEGUIDOS (nombre_usuario VARCHAR(50) PRIMARY KEY);";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();

            sql = $"create table {usuario}_SEGUIDORES (nombre_usuario VARCHAR(50) PRIMARY KEY);";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();

            sql = $"create table {usuario}_GUARDADO (nombre_usuario VARCHAR(50), id_foto int);";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();

            sql = $"create table {usuario}_POSTS (id_foto int PRIMARY KEY, archivo VARCHAR(MAX), titulo_foto VARCHAR(30), descripcion_foto VARCHAR(80), " +
                $"fecha datetime);";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();

            sql = $"create table {usuario}_STORIES (id_foto int PRIMARY KEY, archivo VARCHAR(MAX), times datetime);";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();

            sql = $"create table {usuario}_PERFIL (foto VARCHAR(50), biografia VARCHAR(160));";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();

            sql = $"insert into {usuario}_PERFIL (foto, biografia) values ('\\Imagenes\\FotoPerfil.jpg','');";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();

            return insta;
        }

        public override void Seleccionar()
        {
            string sql = $"select * from USUARIOS where nombre_usuario = '{usuario}' or correo = '{correo}';";
            var adaptador = new SqlDataAdapter(sql, sqlconnection);
            dataset = new System.Data.DataSet();
            adaptador.Fill(dataset, "Registro");
        }
    }
}
