using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webDiscussex.Models;

namespace webDiscussex.DAO
{
    public class DoencaDAO
    {
        public IList<Doenca> Lista(ref IList<Imagem> imgs)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                IList<Doenca> lista = contexto.PP2_Doenca.ToList();

                foreach (Doenca d in lista)
                    imgs.Add(contexto.PP2_Imagem.Where(p => p.Id == d.CodImagem).FirstOrDefault());

                return contexto.PP2_Doenca.ToList();
            }
        }
    }
}