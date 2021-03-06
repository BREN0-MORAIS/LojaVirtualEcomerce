using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories.IRepository
{
   public interface IColaboradorRepository
    {
        Colaborador Login(string Email, string senha);
        void Cadastrar(Colaborador colaborador);
        void Atualizar(Colaborador cliente);
        void Excluir(int Id);
        IEnumerable<Colaborador> GetAll();
        Colaborador Get(int id);

    }
}
