using Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class GetUser : DBInstagram
    {
        private string usuario;
        private string correo;
        public GetUser(Instagram instagram)
        {
            usuario = instagram.user;
            correo = instagram.correo;
        }
        public override Instagram Procesar()
        {
            var insta = new Instagram();
            foreach (DataRow row in dataset.Tables["User"].Rows)
            {
                insta.user = (row["nombre_usuario"].ToString());
                insta.nombre = (row["nombre_completo"].ToString());
                insta.correo = (row["correo"].ToString());
            }
            foreach (DataRow row in dataset.Tables["Seguidos"].Rows)
            {
                insta.seguidos.Add(row["nombre_usuario"].ToString());
            }
            foreach (DataRow row in dataset.Tables["Seguidores"].Rows)
            {
                insta.seguidores.Add(row["nombre_usuario"].ToString());
            }
            foreach (DataRow row in dataset.Tables["Posts"].Rows)
            {
                var post = new Post();
                post.usuario = usuario;
                post.id = Convert.ToInt32(row["id_foto"]);
                post.titulo = row["titulo_foto"].ToString();
                post.descripcion = row["descripcion_foto"].ToString();
                post.url = row["archivo"].ToString();

                insta.posts.Add(post);
            }
            foreach (DataRow row in dataset.Tables["Guardado"].Rows)
            {
                var post = new Post();
                post.usuario = row["nombre_usuario"].ToString();
                post.id = Convert.ToInt32(row["id_foto"]);
                insta.guardado.Add(post);
            }
            foreach (DataRow row in dataset.Tables["Perfil"].Rows)
            {
                insta.biografia = row["biografia"].ToString();
                insta.foto = row["foto"].ToString();
            }
            return insta;
        }

        public override void Seleccionar()
        {
            string sql = $"select * from USUARIOS where nombre_usuario = '{usuario}' or correo = '{correo}';";
            var adaptador = new SqlDataAdapter(sql, sqlconnection);
            dataset = new System.Data.DataSet();
            adaptador.Fill(dataset, "User");
            sql = $"select * from {usuario}_SEGUIDOS;";
            adaptador = new SqlDataAdapter(sql, sqlconnection);
            adaptador.Fill(dataset, "Seguidos");
            sql = $"select * from {usuario}_SEGUIDORES;";
            adaptador = new SqlDataAdapter(sql, sqlconnection);
            adaptador.Fill(dataset, "Seguidores");
            sql = $"select * from {usuario}_POSTS;";
            adaptador = new SqlDataAdapter(sql, sqlconnection);
            adaptador.Fill(dataset, "Posts");
            sql = $"select * from {usuario}_GUARDADO;";
            adaptador = new SqlDataAdapter(sql, sqlconnection);
            adaptador.Fill(dataset, "Guardado");
            sql = $"select * from {usuario}_PERFIL;";
            adaptador = new SqlDataAdapter(sql, sqlconnection);
            adaptador.Fill(dataset, "Perfil");
            sql = $"select * from {usuario}_STORIES;";
            adaptador = new SqlDataAdapter(sql, sqlconnection);
            adaptador.Fill(dataset, "Stories");
        }
    }
}
