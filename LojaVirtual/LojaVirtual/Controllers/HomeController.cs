using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Email;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult ContatoAcao() {

            Contato contato = new Contato();

            contato.Nome = HttpContext.Request.Form["nome"];
            contato.Texto = HttpContext.Request.Form["texto"];
            contato.Email = HttpContext.Request.Form["email"];


            /*Pega os dados apartir de uma requsição de um formulario*/
            //string nome =   HttpContext.Request.Form["nome"];
            //string email =    HttpContext.Request.Form["email"];
            // string texto =  HttpContext.Request.Form["texto"];

            //chama o método para enviar as informações
            ContatoEmail.EnviarContatoPorEmail(contato);
           return new ContentResult(){Content = string.Format("nome:{0} <br> Email: {1} <br> texto:{2}",contato.Nome,contato.Email,contato.Texto),ContentType = "text/html" };
      
        }

        public IActionResult Login()
        {
            return View();
        }  
        public IActionResult CadastroCliente()
        {
            return View();
        }
        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}
