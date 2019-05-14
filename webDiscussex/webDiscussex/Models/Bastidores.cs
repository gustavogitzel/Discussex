using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;



namespace webDiscussex.Models
{
    public class Bastidores
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string Img { get; set; }
    }
}
