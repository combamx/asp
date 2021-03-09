using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Models;

namespace Users.Controllers
{
    [Route("/Usuarios")]
    //[Route("[controller]/[action]")]
    //[Route("[controller]")]
    public class UsuariosController : Controller
    {
        //[Route("[controller]/[action]/{data}")]
        //[HttpGet("[controller]/[action]/{data:int}")]
        [Route("/Usuarios")]
        [Route("/Usuarios/Redirect")]
        public IActionResult Index()
        {
            //var url = Url.Action("Metodo", "Usuarios", new { age=25, name="Omar Cortes" });
            //ViewData["data"] = data;
            //return View();
            //return Content(url);
            var url = Url.RouteUrl("Omar", new { age = 25, name = "Omar Cortes" });
            return Redirect(url);
        }

        //[HttpGet, HttpPost]
        [Route("/Usuarios/Lista")]
        public IActionResult Index(String data, int? edad)
        {
            var usuario = new List<UsuarioModel>()
            {
                new UsuarioModel()
                {
                    Nombre = "Omar",
                    Ape_Paterno = "Cortes",
                    Ape_Materno = "Casillas",
                    Edad = 42,
                    CorreoElectronico = "omar.cortes.casillas@gmail.com",
                    Telefono = "352 122 01 93"
                },
                new UsuarioModel()
                {
                    Nombre = "Mario",
                    Ape_Paterno = "Cortes",
                    Ape_Materno = "Casillas",
                    Edad = 40,
                    CorreoElectronico = "omar.cortes.casillas@gmail.com",
                    Telefono = "352 122 01 93"
                },
                new UsuarioModel()
                {
                    Nombre = "Edgar",
                    Ape_Paterno = "Cortes",
                    Ape_Materno = "Casillas",
                    Edad = 38,
                    CorreoElectronico = "omar.cortes.casillas@gmail.com",
                    Telefono = "352 122 01 93"
                },
                new UsuarioModel()
                {
                    Nombre = "Fatima Abigail",
                    Ape_Paterno = "Cortes",
                    Ape_Materno = "Briseño",
                    Edad = 13,
                    CorreoElectronico = "omar.cortes.casillas@gmail.com",
                    Telefono = "352 122 01 93"
                },
                new UsuarioModel()
                {
                    Nombre = "Ivanna Paola",
                    Ape_Paterno = "Cortes",
                    Ape_Materno = "Briseño",
                    Edad = 9,
                    CorreoElectronico = "omar.cortes.casillas@gmail.com",
                    Telefono = "352 122 01 93"
                },
            };

           /*
            usuario.Add()
            usuario.Nombre = "Omar";
            usuario.Ape_Paterno = "Cortes";
            usuario.Ape_Materno = "Casillas";
            usuario.Edad = 42;
            usuario.CorreoElectronico = "omar.cortes.casillas@gmail.com";
            usuario.Telefono = "352 122 01 93";
           */

            ViewData["id"] = data + " " + edad;
            String datos = data + " " + edad;

            return View("Index", usuario);
        }

        //[HttpGet("[controller]/[action]/", Name = "Omar")]
        [HttpGet("/Usuarios/Metodo", Name = "Omar")]
        public IActionResult Metodo(int age, String name)
        {
            var data = $"Nombre {name} edad {age}";
            return View("Metodo", data);
        }
        
    }
}
