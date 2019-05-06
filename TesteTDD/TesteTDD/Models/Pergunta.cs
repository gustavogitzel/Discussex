using System;
using System.Collections.Generic;
using System.Text;

namespace TesteTDD.DAO
{
    public class Pergunta
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string PalavraChave { get; set; }
        public int? CodUsuario { get; set; }
        public int QuantidadeAcesso { get; set; }
    }
}