using LojaVirtual.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Login
{
    public class LoginColaborador
    {
        //Fazer Uma consulta no Banco de dados com email e senha
        //depois armazenar a informação na sessão do cliente
        private string key = "Login.Colaborador";
        private Session.Session _session;
        public LoginColaborador(Session.Session session)
        {
            _session = session;
        }
        public void Login(Colaborador colaborador)
        {
            //serializar-> Converteno para String
            var obj = JsonConvert.SerializeObject(colaborador);
            _session.Cadastrar(key, obj);
            //Armazenar na Sessão
        }

        public Colaborador GetColaborador()
        {
            if (_session.Exist(key))
            {
                //deserealizar->, pega um item que esta em formato de string e converte para Objeto
                string colaboradorJsonString = _session.Get(key);
                return JsonConvert.DeserializeObject<Colaborador>(colaboradorJsonString);
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

