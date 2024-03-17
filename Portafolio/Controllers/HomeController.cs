using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly ISmtpEmail smtpEmail;

        public HomeController( IRepositorioProyectos repositorioProyectos, ISmtpEmail smtpEmail )
        {
            
            this.repositorioProyectos = repositorioProyectos;
            this.smtpEmail = smtpEmail;
        }

        public IActionResult Index()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
           
            var modelo = new HomeIndexDTO() 
            { Proyectos = proyectos
             
            };
            return View(modelo);
        }

        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacto(ContactoDTO contactoDTO) 
        {
          
            var enviar = smtpEmail.Enviar(contactoDTO);

            if(!enviar.IsCanceled) 
            { 
                return RedirectToAction("Gracias"); 
            }
            else 
            { 
                return RedirectToAction("Error"); 
            }
            
            

        }

      
        public IActionResult Gracias()
        {
            return View();
        }

        public IActionResult Proyectos() 
        {
            var proyectos = repositorioProyectos.ObtenerProyectos();
            return View(proyectos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
