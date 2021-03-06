using LojaVirtual.Libraries.Login;
using LojaVirtual.Repositories;
using LojaVirtual.Repositories.IRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual
{
    public  class DI
    {
        public static void Injecao(IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<INewsLatterRepository, NewsLatterRepository>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<LoginColaborador>();

            //injeção de Dependencias da Sessão vai classe
            services.AddHttpContextAccessor();
            //deichando disponivel pra todas as Classes

            //Injetando Loin Cliente
            services.AddScoped<LoginCliente>();
        }
    }
}
