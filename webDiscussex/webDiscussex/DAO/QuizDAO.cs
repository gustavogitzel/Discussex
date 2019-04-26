using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webDiscussex.Models;

namespace webDiscussex.DAO
{
    public class QuizDAO
    {
        public IList<Quiz> Lista(ref IList<string> respostas)
        {
            using (var contexto = new EducacaoSexualContext())
            {
                var listaQuiz = contexto.PP2_Quiz.ToList();

                for (int i = 0; i < listaQuiz.Count; i++)
                    respostas.Add(listaQuiz[i].Resposta);

                return listaQuiz;
            }
        }
    }
}