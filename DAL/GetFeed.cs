using Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class GetFeed : DBInstagram
    {
        private string usuario;
        public GetFeed(Instagram instagram)
        {
            usuario = instagram.user;
        }
        public override Instagram Procesar()
         {
             var insta = new Instagram();
            insta.user = usuario;
            foreach (DataRow row in dataset.Tables["Seguidos"].Rows)
            {
                var sql = $"select * from {row["nombre_usuario"]}_POSTS;";
                var adaptador = new SqlDataAdapter(sql, sqlconnection);
                adaptador.Fill(dataset, "Posts" + row["nombre_usuario"]);

                foreach (DataRow row2 in dataset.Tables["Posts" + row["nombre_usuario"]].Rows)
                {
                    var post = new Post();
                    post.usuario = row["nombre_usuario"].ToString();
                    post.id = Convert.ToInt32(row2["id_foto"]);
                    post.titulo = row2["titulo_foto"].ToString();
                    post.descripcion = row2["descripcion_foto"].ToString();
                    post.date = (DateTime)row2["fecha"];
                    post.url = row2["archivo"].ToString();

                    sql = $"select count(*) from {row["nombre_usuario"]}_{post.id}_LIKES"; // Likes
                    SqlCommand cmd = new SqlCommand(sql, sqlconnection);
                    cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    post.likes = Convert.ToInt32(reader[0]);
                    reader.Close();

                    sql = $"select * from {row["nombre_usuario"]}_{post.id}_COMENTARIOS;"; // Comentarios
                    adaptador = new SqlDataAdapter(sql, sqlconnection);
                    adaptador.Fill(dataset, row["nombre_usuario"] + "" + post.id + "comentarios");

                    foreach (DataRow row3 in dataset.Tables[row["nombre_usuario"] + "" + post.id + "comentarios"].Rows)
                    {
                        var comment = new Comment();
                        comment.id = Convert.ToInt32(row3["id_comentario"]);
                        comment.name = row3["nombre_usuario"].ToString();
                        comment.data = row3["texto"].ToString();
                        post.comentarios.Add(comment);
                    }

                    sql = $"select * from {row["nombre_usuario"]}_PERFIL";
                    adaptador = new SqlDataAdapter(sql, sqlconnection);
                    adaptador.Fill(dataset, "Perfil");
                    foreach (DataRow row4 in dataset.Tables["Perfil"].Rows)
                    {
                        post.foto = row4["foto"].ToString();
                    }

                    insta.publico.Add(post);
                }

                sql = $"select * from {row["nombre_usuario"]}_STORIES;";
                adaptador = new SqlDataAdapter(sql, sqlconnection);
                adaptador.Fill(dataset, "Stories");

                var stories = new Stories();

                foreach (DataRow row2 in dataset.Tables["Stories"].Rows)
                {
                   
                    var storie = new Storie();
                    storie.url = row2["archivo"].ToString();
                    storie.id = Convert.ToInt32(row2["id_foto"]);
                    storie.date = (DateTime)row2["times"];

                    if ((DateTime.Now-storie.date).TotalDays >= 1)
                    {
                        sql = $"delete from {row["nombre_usuario"]}_STORIES where id_foto = {storie.id};";
                        var cmd = new SqlCommand(sql, sqlconnection);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        stories.stories.Add(storie);
                    }
                }

                if (stories.stories.Count > 0)
                {
                    stories.nombre = row["nombre_usuario"].ToString();
                    insta.publicStories.Add(stories);
                }
            }

            var stories2 = new Stories();
            foreach (DataRow row2 in dataset.Tables["MyStories"].Rows)
            {
                var storie = new Storie();
                storie.url = row2["archivo"].ToString();
                storie.id = Convert.ToInt32(row2["id_foto"]);
                storie.date = (DateTime)row2["times"];

                if ((DateTime.Now - storie.date).TotalDays >= 1)
                {
                    var sql = $"delete from {usuario}_STORIES where id_foto = {storie.id};";
                    var cmd = new SqlCommand(sql, sqlconnection);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    stories2.stories.Add(storie);
                }
            }
            stories2.nombre = usuario;
            insta.stories = stories2;

            return insta;
         }

         public override void Seleccionar()
         {
            string sql = $"select * from {usuario}_SEGUIDOS;";
            var adaptador = new SqlDataAdapter(sql, sqlconnection);
            dataset = new System.Data.DataSet();
            adaptador.Fill(dataset, "Seguidos");
            sql = $"select * from {usuario}_STORIES;";
            adaptador = new SqlDataAdapter(sql, sqlconnection);
            adaptador.Fill(dataset, "MyStories");
         }
    }
}
