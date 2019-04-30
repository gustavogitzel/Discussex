using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webDiscussex.Models;

namespace webDiscussex.DAO
{
    public class RespostaDAO
    {
        public IList<TResposta> BuscaPorPergunta(int codPergunta)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                IList<TResposta> ret = contexto.PP2_Resposta.Where(p => p.CodPergunta == codPergunta).ToList();

                return ret;
            }
        }

        public void Adiciona(TResposta res)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                contexto.Add(res);
                contexto.SaveChanges();
            }
        }
    }
}