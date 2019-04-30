using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webDiscussex.Models
{
    public class TResposta
    {
        public int Id { get; set; }
        public int CodPergunta { get; set; }
        public int CodUsuario { get; set; }
        public string Resposta { get; set; }
    }
}