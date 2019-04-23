using System;
using System.Collections.Generic;
using System.Linq;
using webDiscussex.Models;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace webDiscussex.DAO
{
    public class ImagemDAO
    {
        public IList<Imagem> Lista()
        {
            using (var contexto = new EducacaoSexualContext())
            {
                return contexto.PP2_Imagem.ToList();
            }
        }
        
    }
}