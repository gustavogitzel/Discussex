﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;



namespace webDiscussex.Models
{
    public class Corpo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        [Key]
        [ForeignKey("Imagem")]
        public int CodImagem { get; set; }

        public virtual Imagem Link { get; set; }
    }
}
