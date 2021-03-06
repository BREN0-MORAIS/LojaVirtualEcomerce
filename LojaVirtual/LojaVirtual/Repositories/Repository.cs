using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Data;
using LojaVirtual.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDataContext _db;

        internal DbSet<T> dbSet;

        public Repository(AppDataContext context)
        {
            _db = context;
            this.dbSet = context.Set<T>();
        }

        public void Cadastrar(T cliente)
        {
            dbSet.Add(cliente);
            _db.SaveChanges();
        }

        public void Excluir(int Id)
        {
            T cliente = Get(Id);
            _db.Remove(cliente);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }
    }
}
