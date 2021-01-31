using LojaVirtual.Data;
using LojaVirtual.Models;
using LojaVirtual.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class NewsLatterRepository : INewsLatterRepository
    {
        public readonly AppDataContext _db;

        public NewsLatterRepository(AppDataContext db)
        {
            _db = db;
        }
        public void Cadastrar(NewsLetterEmail newsLetterEmail)
        {
            _db.Add(newsLetterEmail);
            _db.SaveChanges();
        }

        public IEnumerable<NewsLetterEmail> GetAll()
        {
            return _db.NewsLetterEmails.ToList();
        }
    }
}
