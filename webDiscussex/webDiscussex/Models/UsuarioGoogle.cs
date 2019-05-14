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
    public class UsuarioGoogle
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }

        public string ImgPerfil { get; set; }
        

    }
}