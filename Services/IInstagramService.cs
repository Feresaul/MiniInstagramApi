using Core.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IInstagramService
    {
        public bool LogIn(string user, string correo, string contrasenia);
        public bool Registro(string user, string nombre, string correo, string contrasenia);
        public Instagram GetUser(string user);
        public Instagram GetFeed(string user);
        public bool SeguirEstado(string user, string nombre);
        public void SeguirCambiar(string user, string nombre);
        public bool LikeEstado(string user, string nombre, int id);
        public void LikeCambiar(string user, string nombre, int id);
        public bool GuardarEstado(string user, string nombre, int id);
        public void GuardarCambiar(string user, string nombre, int id);
        public void GuardarComentario(string user, string nombre, int id, string texto);
        public void BorrarComentario(string nombre, int id, int id_comment);
        public void CrearPost(string usuario, string titulo, string descripcion, string url);
        public Post ObtenerPost(string usuario, int id);
        public void BorrarPost(string usuario, int id);
        public void CrearStorie(string usuario, string url);
        public void BorrarStories(string usuario);
        public List<string> Buscar(string user, string busqueda);
        public void EditarPerfil(string user, string url, string biografia);
    }
}
