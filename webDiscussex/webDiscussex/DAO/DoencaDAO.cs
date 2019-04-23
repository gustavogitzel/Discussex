﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webDiscussex.Models;

namespace webDiscussex.DAO
{
    public class DoencaDAO
    {
        public IList<Doenca> Lista()
        {
            using (var contexto = new EducacaoSexualContext())
            {
                return contexto.PP2_Doenca.ToList();
            }
        }
    }
}