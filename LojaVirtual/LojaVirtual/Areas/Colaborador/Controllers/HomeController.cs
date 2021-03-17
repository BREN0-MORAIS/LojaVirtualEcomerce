using LojaVirtual.Libraries.Login;
using LojaVirtual.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class HomeController : Controller
    {
        private readonly IColaboradorRepository _repoColaborador;
        private readonly LoginColaborador _loginColaborador;

        public HomeController(IColaboradorRepository colaborador, LoginColaborador loginColaborador)
        {
            _repoColaborador = colaborador;
            _loginColaborador = loginColaborador;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm] Models.Colaborador colaborador)
        {
            Models.Colaborador colaboradorDb = _repoColaborador.Login(colaborador.Email, colaborador.Senha);

            if (colaboradorDb != null)
            {
                //salvando na sessão
                _loginColaborador.Login(colaboradorDb);
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
        public IActionResult Painel()
        {
            return View();
        }
        public IActionResult RecuperarSenha()
        {
            return View();
        }
        public IActionResult CadastrarNovaSenha()
        {
            return View();
        }

    }
}
