using LojaVirtual.Data;
using LojaVirtual.Models;
using LojaVirtual.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly AppDataContext _db;

        public ColaboradorRepository(AppDataContext context )
        {
            _db = context;

        }
        public void Atualizar(Colaborador cliente)
        {
            _db.Update(cliente);
            _db.SaveChanges();
        }

        public void Cadastrar(Colaborador cliente)
        {
            _db.Add(cliente);
            _db.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Colaborador cliente = Get(Id);
            _db.Remove(cliente);
        }

        public IEnumerable<Colaborador> GetAll()
        {
            return _db.Colaboradores.ToList();
        }

        public Colaborador Get(int id)
        {
            return _db.Colaboradores.Find(id);
        }

        public Colaborador Login(string Email, string senha)
        {
            return _db.Colaboradores.Where(m => m.Email == Email && m.Senha == senha).FirstOrDefault();
        }


    }
}
