using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webDiscussex.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string PalavraChave { get; set; }
        public int CodUsuario { get; set; }
    }
}