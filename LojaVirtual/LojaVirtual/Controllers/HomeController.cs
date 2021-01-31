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
using LojaVirtual.Repositories;
using LojaVirtual.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using LojaVirtual.Libraries.Login;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClienteRepository _repoCliente;
        private readonly INewsLatterRepository _repoNewsLatter;
        private LoginCliente _LoginCliente;//injetando login Cliente
        public HomeController(IClienteRepository repo, INewsLatterRepository reposNewsLatter, LoginCliente loginCliente)
        {
            _repoCliente = repo;
            _repoNewsLatter = reposNewsLatter;
            _LoginCliente = loginCliente;
        }

        [HttpGet]
        public IActionResult Index()
        {
        
            //HttpContext.Session.
            return View();
        }
        [HttpPost]
        //[FromForm] NewsLetterEmail -> Obetm dados do Formulário que foi passado via Post
        public IActionResult Index([FromForm] NewsLetterEmail newsLatter)
        {

            //TODO- Validações

            if (ModelState.IsValid)
            {
                TempData["MSG_S"] = "E-mail Cadastrado! Agora você ira receber Promoções especiais no seu email, fique atento as Novidades";
                _repoNewsLatter.Cadastrar(newsLatter);
               
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm]Cliente cliente)
        {
            Cliente ClienteDB = _repoCliente.Login(cliente.Email, cliente.Senha);

            if (ClienteDB != null)
            {
                //salvando na sessão
                _LoginCliente.Login(ClienteDB);
                ////Logado-> Set ("Chave",new byte[]{ID})
                //HttpContext.Session.Set("ID", new byte[] { 52});
                //HttpContext.Session.SetString("Email",cliente.Email);
                //HttpContext.Session.SetInt32("idade",20);

                return new RedirectResult(nameof(Painel));
            }
            else
            {
                return new ContentResult() { Content = "Not logado" };
                //Não pode esta Logado
            }
        }

        [HttpGet]
        public IActionResult Painel()
        {
            Cliente cliente = _LoginCliente.GetCliente();
            if (cliente!=null)//Quando Utiliza somente o Método Set
            {

            return new ContentResult() { Content = "Acesso Concedido:" + cliente.Id+" "+ cliente.Email+" " + cliente.CPF };
            }
            else
            {
               return new ContentResult() { Content = "Não concedido"};
            }
        }
        [HttpGet]
        public IActionResult CadastroCliente()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CadastroCliente([FromForm]Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                /*Salvar- EF core, SQL connection */
                _repoCliente.Cadastrar(cliente);
               
                TempData["MSG_S"] = "Usuário cadastrado com Sucesso";
                //TODO- implementar Redirecionamento diferentes
            }
            else
            {
                TempData["MSG_E"] = "Erro ao Cadastrar Usuário favor contactar o Administrador";
            }
            return View();
        }
        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}
