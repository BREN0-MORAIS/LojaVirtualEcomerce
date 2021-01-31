using LojaVirtual.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDataContext _db;

        public ClienteRepository(AppDataContext db)
        {
            _db = db;
        }
        public void Atualizar(Cliente cliente)
        {
            _db.Update(cliente);
            _db.SaveChanges();
        }

        public void Cadastrar(Cliente cliente)
        {
            _db.Add(cliente);
            _db.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Cliente cliente = GetCliente(Id);
            _db.Remove(cliente);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _db.Clientes.ToList();
        }

        public Cliente GetCliente(int id)
        {
           return _db.Clientes.Find(id);
        }

        public Cliente Login(string Email, string senha)
        {
           return _db.Clientes.Where(m => m.Email == Email && m.Senha == senha).FirstOrDefault();
        }
    }
}
