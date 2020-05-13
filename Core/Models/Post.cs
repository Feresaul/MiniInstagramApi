using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Post
    {
        public int id { set; get; }
        public string usuario { set; get; }
        public string foto { set; get; }
        public string titulo { set; get; }
        public string descripcion { set; get; }
        public DateTime date { set; get; }
        public string url { set; get; }
        public int likes { set; get; }
        public List<Comment> comentarios { set; get; }

        public Post()
        {
            comentarios = new List<Comment>();
            date = new DateTime();
        }
    }
}
