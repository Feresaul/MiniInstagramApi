using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Instagram
    {
        public string user { set; get; }
        public List<Post> posts { set; get; }
        public List<Post> guardado { set; get; }
        public string contrasenia { set; get; }
        public string correo { set; get; }
        public string nombre { set; get; }
        public string biografia { set; get; }
        public string foto { set; get; }
        public List<Post> publico { set; get; }
        public Stories stories { set; get; }
        public List<Stories> publicStories { set; get; }
        public List<string> seguidos { set; get; }
        public List<string> seguidores { set; get; }

        public Instagram()
        {
            contrasenia = null;
            publico = new List<Post>();
            seguidos = new List<string>();
            seguidores = new List<string>();
            posts = new List<Post>();
            guardado = new List<Post>();
            stories = new Stories();
            publicStories = new List<Stories>();
        }

        public object OrderBy(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
