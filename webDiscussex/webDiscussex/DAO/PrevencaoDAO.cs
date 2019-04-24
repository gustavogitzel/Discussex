using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webDiscussex.Models;

namespace webDiscussex.DAO
{
    public class PrevencaoDAO
    {
        public IList<Prevencao> Lista(ref IList<Imagem> imgs)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                IList<Prevencao> lista = contexto.PP2_MetodoPrevencao.ToList();

                foreach (Prevencao m in lista)
                    imgs.Add(contexto.PP2_Imagem.Where(p => p.Id == m.CodImagem).FirstOrDefault());

                return lista;
            }
        }
    }
}