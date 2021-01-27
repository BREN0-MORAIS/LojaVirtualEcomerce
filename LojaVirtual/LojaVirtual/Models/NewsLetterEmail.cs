using LojaVirtual.Libraries.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Models
{
    public class NewsLetterEmail
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
