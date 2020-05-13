using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IInstagramData
    {
        bool registrarUsuario(Instagram instagram);
        bool logInUsuario(Instagram instagram);
        Instagram getUsuario(Instagram instagram);
        Instagram getFeed(Instagram instagram);
        bool seguirEstado(string user, string nombre);
        void seguirCambiar(string user, string nombre);
        bool likeEstado(string user, string nombre, int id);
        void likeCambiar(string user, string nombre, int id);
        bool guardarEstado(string user, string nombre, int id);
        void guardarCambiar(string user, string nombre, int id);
        void guardarComentario(string user, string nombre, int id, string texto);
        void borrarComentario(string nombre, int id, int id_comment);
        void crearPost(string usuario, string titulo, string descripcion, string url);
        Post obtenerPost(string usuario, int id);
        void borrarPost(string usuario, int id);
        void crearStorie(string usuario, string url);
        void borrarStories(string usuario);
        List<string> buscar(string user, string busqueda);
        void editarPerfil(string user, string url, string biografia);
    }
}
