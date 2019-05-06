using System;
using System.Collections.Generic;
using System.Text;
using TesteTDD.Models;

namespace TesteTDD.DAO
{
    public class PerguntaDAO
    {
        public string Adicionar(Pergunta per)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                per.QuantidadeAcesso = 0;

                contexto.Add(per);
                contexto.SaveChanges();
                return per.Titulo;
            }
        }

    }
}
