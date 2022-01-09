using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERemoto01.Models
{
    public class Livro
    {
        //Deve-se colocar o nome dos atributos igual ao do banco.
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int? QuantidadePaginas { get; set; }
        public bool Disponivel { get; set; }
    }
}
