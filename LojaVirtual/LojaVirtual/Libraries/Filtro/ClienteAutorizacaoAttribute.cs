using LojaVirtual.Libraries.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Filtro
{
    //autorização de Usuário
    /*
     Tipo de Filtros
    -Autorização -> IAuthorizationFilter
    -Recurso -> IResourceFilter
    -Ação -> IActionFilter
    -Exeção -> IExceptionFilter
    -Resultado -> IResultFilter
     
     */
    public class ClienteAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        LoginCliente _loginCliente;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginCliente = (LoginCliente)context.HttpContext.RequestServices.GetService(typeof(LoginCliente));
            Cliente cliente = _loginCliente.GetCliente();
            if (cliente == null)//Quando Utiliza somente o Método Set
            {
                context.Result = new ContentResult() { Content = "Acesso Negado" };

            }
         
        }
    }
}
