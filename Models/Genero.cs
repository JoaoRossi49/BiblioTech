using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BiblioTech.Models
{
    public class Genero
    {
        [Key]
        public int IdAutor { get; set; }
        public String DescricaoGenero { get; set; }
    }
}