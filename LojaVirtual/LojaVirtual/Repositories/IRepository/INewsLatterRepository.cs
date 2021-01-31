using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories.IRepository
{
   public interface INewsLatterRepository
    {
        void Cadastrar(NewsLetterEmail newsLetterEmail);

        IEnumerable<NewsLetterEmail> GetAll();
    }
}
