using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webDiscussex.Models;

namespace webDiscussex.DAO
{
    public class HivDAO
    {
        public IList<Hiv> Lista(ref IList<Imagem> imgs)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                IList<Hiv> lista = contexto.PP2_HIV.ToList();

                foreach (Hiv h in lista)
                    imgs.Add(contexto.PP2_Imagem.Where(p => p.Id == h.CodImagem).FirstOrDefault());

                return lista;
            }
        }
    }
}