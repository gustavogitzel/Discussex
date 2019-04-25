using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace webDiscussex.Models
{
    public class MitosEVerdades
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Verdade { get; set; }
        public string Mentira { get; set; }
    }
}