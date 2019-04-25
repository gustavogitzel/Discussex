using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webDiscussex.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o seu nome")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Digite o seu email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite uma senha")]
        public string Senha { get; set; }
        public string ImgPerfil { get; set; }
    }
}