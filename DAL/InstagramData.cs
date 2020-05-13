using Core.Models;
using StrategyDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace DAL
{
    public class InstagramData : IInstagramData
    {
        public InstagramData() { }

        public bool seguirEstado(string usuario, string nombre)
        {
            var getestado = new SeguirEstado();
            return getestado.ObtenerEstado(usuario, nombre);
        }

        public Instagram getUsuario(Instagram instagram)
        {
            var getdata = new GetUser(instagram);
            var data = getdata.Ejecutar();

            // Strategy
            OrdenarNumeros ordenador = new OrdenarNumeros(data.posts, new Ascendente());
            data.posts = ordenador.ListaOrdenada();

            var guardado = new List<Post>();
            for (int i = data.guardado.Count - 1; i >= 0; i--)
            {
                guardado.Add(data.guardado[i]);
            }
            data.guardado = guardado;

            return data;
        }
        public Instagram getFeed(Instagram instagram)
        {
            var getdata = new GetFeed(instagram);
            var data = getdata.Ejecutar();

            //Strategy
            OrdenarNumeros ordenador = new OrdenarNumeros(data.publico, new Ascendente());
            data.publico = ordenador.ListaOrdenada();

            return data;
        }

        public bool logInUsuario(Instagram instagram)
        {
            var login = new LogIn(instagram);
            var temp = login.Ejecutar();
            if (temp.contrasenia == instagram.contrasenia) return true;
            else return false;
        }

        public bool registrarUsuario(Instagram instagram)
        {
            var registro = new Registro(instagram);
            var temp = registro.Ejecutar();
            if (temp.contrasenia == instagram.contrasenia) return false;
            return true;
        }

        public List<string> buscar(string user, string busqueda)
        {
            var lista = new Busqueda().Buscar(user, busqueda);
            return lista;
        }

        public void seguirCambiar(string user, string nombre)
        {
            var cambiar = new SeguirCambiar();
            cambiar.CambiarEstado(user, nombre);
        }

        public bool likeEstado(string user, string nombre, int id)
        {
            var getestado = new LikeEstado();
            return getestado.ObtenerEstado(user, nombre, id);
        }

        public bool guardarEstado(string user, string nombre, int id)
        {
            var getestado = new GuardarEstado();
            return getestado.ObtenerEstado(user, nombre, id);
        }

        public void likeCambiar(string user, string nombre, int id)
        {
            var cambiar = new LikeCambiar();
            cambiar.CambiarEstado(user, nombre, id);
        }

        public void guardarCambiar(string user, string nombre, int id)
        {
            var cambiar = new GuardarCambiar();
            cambiar.CambiarEstado(user, nombre, id);
        }

        public void guardarComentario(string user, string nombre, int id, string texto)
        {
            var cambiar = new GuardarComentario();
            cambiar.CambiarEstado(user, nombre, id, texto);
        }

        public void borrarComentario(string nombre, int id, int id_comment)
        {
            var cambiar = new BorrarComentario();
            cambiar.CambiarEstado(nombre, id, id_comment);
        }

        public void crearPost(string usuario, string titulo, string descripcion, string url)
        {
            var crear = new CrearPost(usuario, titulo, descripcion, url);
            crear.Crear();
        }

        public Post obtenerPost(string usuario, int id)
        {
            var crear = new GetPost();
            return crear.ObtenerPost(usuario, id);
        }

        public void borrarPost(string usuario, int id)
        {
            var borrar = new BorrarPost();
            borrar.EliminarPost(usuario, id);
        }

        public void editarPerfil(string user, string url, string biografia)
        {
            var editar = new EditarPerfil();
            editar.Editar(user, url, biografia);
        }

        public void borrarStories(string usuario)
        {
            var borrar = new BorrarStorie();
            borrar.EliminarStories(usuario);
        }

        public void crearStorie(string usuario, string url)
        {
            var crear = new CrearStorie(usuario,url);
            crear.Crear();
        }
    }
}
