using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webDiscussex.Models;

namespace webDiscussex.DAO
{
    public class PerguntaDAO
    {
        public IList<Pergunta> Lista()
        {
            using (var contexto = new EducacaoSexualContext())
            {
                IList<Pergunta> ret = contexto.PP2_Pergunta.OrderByDescending(p => p.QuantidadeAcesso).ToList();

                return ret;
            }
        }

        public IList<Pergunta> BuscaPorPalavraChave(string palavraChave)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                IList<Pergunta> ret = contexto.PP2_Pergunta.Where(p => p.PalavraChave == palavraChave).ToList();

                return ret;
            }
        }

        public void Adicionar(Pergunta per)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                per.QuantidadeAcesso = 0;

                contexto.Add(per);
                contexto.SaveChanges();
            }
        }
    }
}