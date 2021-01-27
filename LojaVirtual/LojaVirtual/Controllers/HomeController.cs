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
using LojaVirtual.Data;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private AppDataContext _banco;
        public HomeController(AppDataContext banco)
        {
            _banco = banco;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var a = new NewsLetterEmail() { Email = "Breno Fra ncisco Morais" };
            return View(a);
        }
        [HttpPost]
        //[FromForm] NewsLetterEmail -> Obetm dados do Formulário que foi passado via Post
        public IActionResult Index([FromForm] NewsLetterEmail newsLatter)
        {

            //TODO- Validações

            if (ModelState.IsValid)
            {
                TempData["MSG_S"] = "E-mail Cadastrado! Agora você ira receber Promoções especiais no seu email, fique atento as Novidades";
                _banco.NewsLetterEmails.Add(newsLatter);
                _banco.SaveChanges();
                //TODO- Adição no Banco de Dados
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult ContatoAcao()
        {
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
                bool isValid = Validator.TryValidateObject(contato, contexto, ListaMenssagens, true);
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
                    ViewData["Contato"] = contato;
                }


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
