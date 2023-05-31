using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiblioTech.Models
{
    public class Livro
    {
        [Key]
        public int IdLivo {get; set;}
        public String NomeLivro { get; set; }

        [ForeignKey("Genero")]
        public int IdGenero { get; set; }
        public int QuantidadePaginas { get; set; }

        [ForeignKey("Autor")]
        public int IdAutor {get; set;}
    }
}