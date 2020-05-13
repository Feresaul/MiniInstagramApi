using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class CrearPost : DBInstagramState
    {
        private Post _post;
        public CrearPost(string usuario, string titulo, string descripcion, string url)
        {
            _post = new Post();
            _post.usuario = usuario;
            _post.titulo = titulo;
            _post.descripcion = descripcion;
            _post.url = url;
        }
        public void Crear()
        {
            Conectar();
            string sql = $"select count(*) from {_post.usuario}_POSTS";
            SqlCommand cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int index = (int)reader[0];
            reader.Close();
            int max = 0;
            if (index > 0)
            {
                sql = $"select max(id_foto) from {_post.usuario}_POSTS";
                cmd = new SqlCommand(sql, sqlconnection);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                reader.Read();
                max = (int)reader[0];
                reader.Close();
            }

            if ((int)index != 0)
                index = max + 1;

            var time = DateTime.Now.ToString();
            var newTime = "" + time[6] + time[7] + time[8] + time[9] + "/" + time[3] + time[4] + "/" + time[0] + time[1]+" ";
            for (int i = 11; i < 19; i++) newTime += time[i];

            sql = $"insert into {_post.usuario}_POSTS (id_foto,archivo,titulo_foto,descripcion_foto,fecha) " +
                $"values ({index},'{_post.url}','{_post.titulo}','{_post.descripcion}','{newTime}');";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            sql = $"create table {_post.usuario}_{index}_COMENTARIOS (id_comentario int PRIMARY KEY, nombre_usuario VARCHAR(50), texto VARCHAR(100));";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            sql = $"create table {_post.usuario}_{index}_LIKES (nombre_usuario VARCHAR(50) PRIMARY KEY);";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            sql = $"create table {_post.usuario}_{index}_GUARDADO (nombre_usuario VARCHAR(50) PRIMARY KEY);";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            Desconectar();
        }
    }
}
