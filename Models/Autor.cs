using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BiblioTech.Models
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }
        public String NomeAutor { get; set; }
    }
}