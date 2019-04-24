using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webDiscussex.Models;

namespace webDiscussex.DAO
{
    public class GravidezDAO
    {
        public IList<Gravidez> Lista(ref IList<Imagem> imgs)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                IList<Gravidez> lista = contexto.PP2_Gravidez.ToList();

                foreach (Gravidez g in lista)
                    imgs.Add(contexto.PP2_Imagem.Where(p => p.Id == g.CodImagem).FirstOrDefault());

                return lista;
            }
        }
    }
}