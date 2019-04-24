using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webDiscussex.Models;

namespace webDiscussex.DAO
{
    public class CorpoDAO
    {
        public IList<Corpo> Lista(ref IList<Imagem> imgs)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                IList<Corpo> lista = contexto.PP2_Corpo.ToList();

                foreach (Corpo c in lista)
                    imgs.Add(contexto.PP2_Imagem.Where(p => p.Id == c.CodImagem).FirstOrDefault());

                return contexto.PP2_Corpo.ToList();
            }
        }
    }
}