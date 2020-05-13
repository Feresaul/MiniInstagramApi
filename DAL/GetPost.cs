using Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class GetPost : DBInstagramState
    {
        public GetPost() { }
        public Post ObtenerPost(string usuario, int id)
        {
            var post = new Post();
            Conectar();
            
            string sql = $"select count(*) from {usuario}_{id}_LIKES;";
            SqlCommand cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            var index = reader[0];
            reader.Close();
            post.likes = Convert.ToInt32(index);

            sql = $"select * from {usuario}_{id}_COMENTARIOS;";
            dataset = new System.Data.DataSet();
            var adaptador = new SqlDataAdapter(sql, sqlconnection);
            adaptador.Fill(dataset, "Comments");
            var lista = new List<Comment>();
            foreach (DataRow row in dataset.Tables["Comments"].Rows)
            {
                var comentario = new Comment();
                comentario.id = (int)row["id_comentario"];
                comentario.name = row["nombre_usuario"].ToString();
                comentario.data = row["texto"].ToString();
                lista.Add(comentario);
            }
            post.comentarios = lista;

            sql = $"select * from {usuario}_POSTS where id_foto ={id};";
            adaptador = new SqlDataAdapter(sql, sqlconnection);
            adaptador.Fill(dataset, "Data");
            foreach (DataRow row in dataset.Tables["Data"].Rows)
            {
                post.descripcion = row["descripcion_foto"].ToString();
                post.titulo = row["titulo_foto"].ToString();
                post.url = row["archivo"].ToString();
                post.usuario = usuario;
                post.id = id;
            }
            sql = $"select * from {usuario}_PERFIL";
            adaptador = new SqlDataAdapter(sql, sqlconnection);
            adaptador.Fill(dataset, "Perfil");
            foreach (DataRow row in dataset.Tables["Perfil"].Rows)
            {
                post.foto = row["foto"].ToString();
            }

            Desconectar();
            return post;
        }
    }
}
