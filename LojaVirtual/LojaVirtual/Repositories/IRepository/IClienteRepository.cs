using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public interface IClienteRepository
    {
        Cliente Login(string Email, string senha);
        //CRUD
        void Cadastrar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Excluir(int Id);
        Cliente GetCliente(int id);
        IEnumerable<Cliente> GetAll();
    }
}
