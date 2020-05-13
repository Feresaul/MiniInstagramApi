using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MiniInstagramAPI.Controllers
{
    [ApiController]
    [Route("api/instagram")]
    public class InstagramController : ControllerBase
    {
        private IInstagramService instagramService;
        public InstagramController(IInstagramService instagramService)
        {
            this.instagramService = instagramService;
        }

        [HttpGet("LogIn")]
        public bool LogIn(string user, string correo, string contrasenia)
        {
            return instagramService.LogIn(user, correo, contrasenia);
        }

        [HttpGet("GetUser")]
        public Instagram GetUser(string user)
        {
            return instagramService.GetUser(user);
        }

        [HttpGet("GetFeed")]
        public Instagram GetFeed(string user)
        { 
            return instagramService.GetFeed(user);
        }

        [HttpGet("SeguirEstado")]
        public bool SiguiendoEstado(string user, string nombre)
        {
            return instagramService.SeguirEstado(user, nombre);
        }

        [HttpGet("LikeEstado")]
        public bool LikeEstado(string user, string nombre, int id)
        {
            return instagramService.LikeEstado(user, nombre, id);
        }

        [HttpGet("GuardarEstado")]
        public bool GuardarEstado(string user, string nombre, int id)
        {
            return instagramService.GuardarEstado(user, nombre, id);
        }

        [HttpPost("SeguirCambiar")]
        public void CambiarEstado(string user, string nombre)
        {
            instagramService.SeguirCambiar(user, nombre);
        }

        [HttpPost("LikeCambiar")]
        public void LikeCambiar(string user, string nombre, int id)
        {
            instagramService.LikeCambiar(user, nombre, id);
        }

        [HttpPost("GuardarCambiar")]
        public void GuardarCambiar(string user, string nombre, int id)
        {
            instagramService.GuardarCambiar(user, nombre, id);
        }

        [HttpPost("GuardarComentario")]
        public void GuardarComentario(string user, string nombre, int id, string texto)
        {
            instagramService.GuardarComentario(user, nombre, id, texto);
        }

        [HttpPost("BorrarComentario")]
        public void BorrarComentario(string nombre, int id, int id_comment)
        {
            instagramService.BorrarComentario(nombre, id, id_comment);
        }

        [HttpPost("CrearPost")]
        public void CrearPost(string usuario, string titulo, string descripcion, string url)
        {
            instagramService.CrearPost(usuario,titulo,descripcion,url);
        }

        [HttpGet("ObtenerPost")]
        public Post ObtenerPost(string usuario, int id)
        {
            return instagramService.ObtenerPost(usuario, id);
        }

        [HttpPost("BorrarPost")]
        public void BorrarPost(string usuario, int id)
        {
            instagramService.BorrarPost(usuario, id);
        }

        [HttpPost("CrearStorie")]
        public void CrearStorie(string usuario, string url)
        {
            instagramService.CrearStorie(usuario, url);
        }

        [HttpPost("BorrarStories")]
        public void BorrarStories(string usuario)
        {
            instagramService.BorrarStories(usuario);
        }

        [HttpPost("Registro")]
        public bool Registro(string user, string nombre, string correo, string contrasenia)
        {
            return instagramService.Registro(user, nombre, correo, contrasenia);
        }

        [HttpPost("EditarPerfil")]
        public void EditarPerfil(string user, string url, string biografia)
        {
            instagramService.EditarPerfil(user, url, biografia);
        }

        [HttpGet("Buscar")]
        public List<string> Buscar(string user, string busqueda)
        {
            return instagramService.Buscar(user,busqueda);
        }
    }
}
