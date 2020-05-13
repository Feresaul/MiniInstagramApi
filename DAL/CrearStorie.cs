using Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace DAL
{
    public class CrearStorie : DBInstagramState
    {
        private Storie storie = new Storie();
        private string usuario;
        public CrearStorie(string usuario, string url)
        {
            this.usuario = usuario;
            storie.url = url;
        }
        public void Crear()
        {
            Conectar();
            string sql = $"select count(*) from {usuario}_STORIES";
            SqlCommand cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int index = (int)reader[0];
            reader.Close();
            int max = 0;
            if (index > 0)
            {
                sql = $"select max(id_foto) from {usuario}_STORIES";
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
;           var tipe = DateTime.Now.ToString("tt", CultureInfo.InvariantCulture);
            var newTime = "" + time[6] + time[7] + time[8] + time[9] + "/" + time[3] + time[4] + "/" + time[0] + time[1] + " ";
            int num = (time[11]-48)*10+time[12]-48;
            if (tipe == "PM")
            {
                num += 12;
                var stringnum = num.ToString();
                newTime += stringnum[0];
                newTime += stringnum[1];
                for (int i = 13; i < 19; i++) newTime += time[i];
            }
            else
            {
                for (int i = 11; i < 19; i++) newTime += time[i];
            }

            sql = $"insert into {usuario}_STORIES (id_foto,archivo,times) " +
                $"values ({index},'{storie.url}','{newTime}');";
            cmd = new SqlCommand(sql, sqlconnection);
            cmd.ExecuteNonQuery();
            Desconectar();
        }
    }
}
