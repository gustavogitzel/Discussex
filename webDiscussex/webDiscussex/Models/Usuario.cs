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

        [Required(ErrorMessage ="Digite o seu nome")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Digite o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage ="Informe um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        [DataType(DataType.Password)]
        [StringLength(30,MinimumLength = 8, ErrorMessage ="Digite, no mínimo, 8 caracteres")]
        public string Senha { get; set; }

        public string ImgPerfil { get; set; }

        public string CodigoUsuario { get; set; }

        public static Usuario GetLoginInfo(ClaimsIdentity identity)
        {
            if (identity.Claims.Count() == 0 || identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email) == null)
                return null;
            var dao = new UsuarioDAO();
            var usuarios = dao.Lista();
            string codAtual = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var usuarioAtual = usuarios.ToList().Find(u => u.CodigoUsuario == codAtual);
            string foto = null;
            /*var accessToken = identity.Claims.Where(c => c.Type.Equals("urn:google:accesstoken")).Select(c => c.Value).FirstOrDefault();
            Uri apiRequestUri = new Uri("https://www.google.com/oauth2/v2/userinfo?access token=" + accessToken);
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString(apiRequestUri);
                dynamic result = JsonConvert.DeserializeObject(json);
                foto = result.picture;
            }*/
            if (usuarioAtual == null)
            {
                usuarioAtual = new Usuario();
                usuarioAtual.CodigoUsuario = codAtual;
                usuarioAtual.NomeUsuario = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
                usuarioAtual.Email = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
                usuarioAtual.Senha = null;
                usuarioAtual.Id = dao.AddAndReturn(usuarioAtual);
            }
            else
            {
                string email = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
                string nome = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;

                if (usuarioAtual.Email != email || usuarioAtual.NomeUsuario != nome || usuarioAtual.ImgPerfil != foto)
                {
                    usuarioAtual.Email = email;
                    usuarioAtual.NomeUsuario = nome;
                    usuarioAtual.ImgPerfil = foto;
                    dao.Atualiza(usuarioAtual);
                }

            }

            return usuarioAtual;
        }
    }
}