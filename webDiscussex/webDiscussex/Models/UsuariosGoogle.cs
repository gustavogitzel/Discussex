using System;
using System.Collections.Generic;
using System.Linq;
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
        public string CodigoUsuario { get; set; }
        public string ImgPerfil { get; set; }

        public static UsuarioGoogle GetLoginInfo(ClaimsIdentity identity)
        {
            if (identity.Claims.Count() == 0 || identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email) == null)
                return null;
            var dao = new UsuarioGoogleDAO();
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
                usuarioAtual = new UsuarioGoogle();
                usuarioAtual.CodigoUsuario = codAtual;
                usuarioAtual.Nome = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
                usuarioAtual.Email = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
                usuarioAtual.Id = dao.AddAndReturn(usuarioAtual);
            }
            else
            {
                string email = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
                string nome = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;

                if (usuarioAtual.Email != email || usuarioAtual.Nome != nome || usuarioAtual.ImgPerfil != foto)
                {
                    usuarioAtual.Email = email;
                    usuarioAtual.Nome = nome;
                    usuarioAtual.ImgPerfil = foto;
                    dao.Atualiza(usuarioAtual);
                }

            }

            return usuarioAtual;
        }
    }
}