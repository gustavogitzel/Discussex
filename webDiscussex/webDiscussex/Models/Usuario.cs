using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webDiscussex.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Pontuacao { get; set; }
        public string ImgPerfil { get; set; }
    }
}