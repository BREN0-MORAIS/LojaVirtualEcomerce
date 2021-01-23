using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Email;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
            try
            {
                

                contato.Nome = HttpContext.Request.Form["nome"];
                contato.Texto = HttpContext.Request.Form["texto"];
                contato.Email = HttpContext.Request.Form["email"];

                //lista de validações
                var ListaMenssagens = new List<ValidationResult>();

                //padda o objeto no contexto para verificar
                var contexto = new ValidationContext(contato);

                //execurtando a validação de Objetos
               bool isValid =   Validator.TryValidateObject(contato, contexto, ListaMenssagens,true);
                if (isValid)
                {
                    /*Pega os dados apartir de uma requsição de um formulario*/
                    //string nome =   HttpContext.Request.Form["nome"];
                    //string email =    HttpContext.Request.Form["email"];
                    // string texto =  HttpContext.Request.Form["texto"];

                    //chama o método para enviar as informações
                    ContatoEmail.EnviarContatoPorEmail(contato);
                    //return new ContentResult() { Content = string.Format("nome:{0} <br> Email: {1} <br> texto:{2}", contato.Nome, contato.Email, contato.Texto), ContentType = "text/html" };
                    ViewData["MSG_S"] = "Menssagem de Contato Enviado Com sucesso";
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in ListaMenssagens)
                    {
                        sb.Append(item.ErrorMessage);
                    }

                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["Contato"]= contato;                }
              

                //utiliza a tela de contato mais no metodo de ação
                return View("Contato");

            }
            catch (Exception e)
            {
                ViewData["Contato"] = contato;
                ViewData["MSG_E"] = "Opps! tivemos um erro tente novamente mais Tarde";

                //utiliza a tela de contato mais no metodo de ação
                return View("Contato");
            }
      
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
