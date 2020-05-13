using Core.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class InstagramService : IInstagramService
    {
        private IInstagramData instagramMethod;
        private Instagram instagram;

        public InstagramService()
        {
            instagramMethod = new InstagramData();
            instagram = new Instagram();
        }

        public bool SeguirEstado(string user, string nombre)
        {
            return instagramMethod.seguirEstado(user, nombre);
        }

        public Instagram GetUser(string user)
        {
            instagram.user = user;
            instagram.correo = user;
            return instagramMethod.getUsuario(instagram);
        }

        public Instagram GetFeed(string user)
        {
            instagram.user = user;
            return instagramMethod.getFeed(instagram);
        }

        public bool LogIn(string user,string correo, string contrasenia)
        {
            instagram.user = user;
            instagram.correo = correo;
            instagram.contrasenia = contrasenia;
            return instagramMethod.logInUsuario(instagram);
        }

        public bool Registro(string user, string nombre, string correo, string contrasenia)
        {
            instagram.user = user;
            instagram.nombre = nombre;
            instagram.correo = correo;
            instagram.contrasenia = contrasenia;
            return instagramMethod.registrarUsuario(instagram);
        }

        public List<string> Buscar(string user, string busqueda)
        {
            return instagramMethod.buscar(user,busqueda);
        }

        public void SeguirCambiar(string user, string nombre)
        {
            instagramMethod.seguirCambiar(user, nombre);
        }

        public bool LikeEstado(string user, string nombre, int id)
        {
            return instagramMethod.likeEstado(user, nombre, id);
        }

        public bool GuardarEstado(string user, string nombre, int id)
        {
            return instagramMethod.guardarEstado(user, nombre, id);
        }

        public void LikeCambiar(string user, string nombre, int id)
        {
            instagramMethod.likeCambiar(user, nombre, id);
        }

        public void GuardarCambiar(string user, string nombre, int id)
        {
            instagramMethod.guardarCambiar(user, nombre, id);
        }

        public void GuardarComentario(string user, string nombre, int id, string texto)
        {
            instagramMethod.guardarComentario(user, nombre, id, texto);
        }

        public void BorrarComentario(string nombre, int id, int id_comment)
        {
            instagramMethod.borrarComentario(nombre, id, id_comment);
        }

        public void CrearPost(string usuario, string titulo, string descripcion, string url)
        {
            instagramMethod.crearPost(usuario, titulo, descripcion, url);
        }

        public Post ObtenerPost(string usuario, int id)
        {
           return  instagramMethod.obtenerPost(usuario, id);
        }

        public void BorrarPost(string usuario, int id)
        {
            instagramMethod.borrarPost(usuario, id);
        }

        public void EditarPerfil(string user, string url, string biografia)
        {
            instagramMethod.editarPerfil(user, url, biografia);
        }

        public void BorrarStories(string usuario)
        {
            instagramMethod.borrarStories(usuario);
        }

        public void CrearStorie(string usuario, string url)
        {
            instagramMethod.crearStorie(usuario, url);
        }
    }
}
