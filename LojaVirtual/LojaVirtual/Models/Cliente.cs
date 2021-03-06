﻿using LojaVirtual.Libraries.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }
 
        public string CPF { get; set; }

        public string Sexo { get; set; }

        public string Telefone { get; set; }
        
        public DateTime Nascimento { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
        
    }
}
