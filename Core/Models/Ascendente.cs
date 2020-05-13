using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyDemo.Models
{
    public class Ascendente : IOrdenamiento
    {
        public List<Post> Ordenar(List<Post> posts)
        {
            posts = posts.OrderBy(o => o.date).ToList();
            var lista = new List<Post>();
            for(int i = posts.Count-1; i>=0; i--)
            {
                lista.Add(posts[i]);
            }
            return lista;
        }
    }
}
