using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioTech.Models
{
    public class Livro
    {
        public int IdLivo {get; set;}
        public String NomeLivro { get; set; }
        public int IdGenero { get; set; }
        public int QuantidadePaginas { get; set; }
        public int IdAutor {get; set;}
    }
}