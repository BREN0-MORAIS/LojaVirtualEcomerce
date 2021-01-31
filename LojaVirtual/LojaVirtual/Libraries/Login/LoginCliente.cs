using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Login
{
    public class LoginCliente
    {
        //Fazer Uma consulta no Banco de dados com email e senha
        //depois armazenar a informação na sessão do cliente
        private string key = "Login.Cliente";
        private Session.Session _session;
        public LoginCliente(Session.Session session)
        {
            _session = session;
        }
        public void Login(Cliente cliente)
        {
            //serializar-> Converteno para String
            var obj = JsonConvert.SerializeObject(cliente);
            _session.Cadastrar(key, obj);
            //Armazenar na Sessão
        }

        public Cliente GetCliente()
        {
            if (_session.Exist(key))
            {

                //deserealizar->, pega um item que esta em formato de string e converte para Objeto
                string clienteJsonString = _session.Get(key);

                return JsonConvert.DeserializeObject<Cliente>(clienteJsonString);
            }
            else
            {
                return null;
            }
        }

        public void Logout()
        {
            _session.RemoverTodos();
        }
    }
}
