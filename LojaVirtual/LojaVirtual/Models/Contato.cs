using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LojaVirtual.Libraries;
using LojaVirtual.Libraries.Lang;

namespace LojaVirtual.Models
{
    public class Contato
    {

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessage ="MSG_V001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Mensagem), ErrorMessage = "MSG_V002")]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessage = "MSG_V001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Mensagem), ErrorMessage = "MSG_V004")]
        public string Email { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessage = "MSG_V001")]
        [MinLength(10, ErrorMessageResourceType = typeof(Mensagem), ErrorMessage = "MSG_V002")]
        [MaxLength(500, ErrorMessageResourceType = typeof(Mensagem), ErrorMessage = "MSG_V003")]
        public string Texto { get; set; }
    }
}
