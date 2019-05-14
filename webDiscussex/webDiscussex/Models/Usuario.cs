using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using webDiscussex.DAO;

namespace webDiscussex.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o seu nome")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Digite o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Digite, no mínimo, 8 caracteres")]
        public string Senha { get; set; }

        public string ImgPerfil { get; set; }

    }
}