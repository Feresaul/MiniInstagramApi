using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyDemo.Models
{
    public class OrdenarNumeros
    {
        private List<Post> _posts;
        private IOrdenamiento _EstrategiaOrdenamiento;

        public OrdenarNumeros(List<Post> posts, IOrdenamiento estrategiaOrdenamiento)
        {
            _posts = posts;
            _EstrategiaOrdenamiento = estrategiaOrdenamiento;
        }

        public List<Post> ListaOrdenada()
        {
            if (_posts == null) return new List<Post>();
            return _EstrategiaOrdenamiento.Ordenar(_posts);
        }
    }
}
