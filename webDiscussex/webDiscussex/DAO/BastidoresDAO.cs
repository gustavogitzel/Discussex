using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webDiscussex.Models;

namespace webDiscussex.DAO
{
    public class BastidoresDAO
    {
        public IList<Bastidores> Lista()
        {
            using (var contexto = new EducacaoSexualContext())
            {
                return  contexto.PP2_Bastidores.ToList();
            }
        }
    }
}