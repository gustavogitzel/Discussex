using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace webDiscussex.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Pergunta { get; set; }
        public string Resposta { get; set; }
        public string OpcaoA { get; set; }
        public string OpcaoB { get; set; }
        public string OpcaoC { get; set; }
        public string OpcaoD { get; set; }
        public string OpcaoE { get; set; }
    }
}