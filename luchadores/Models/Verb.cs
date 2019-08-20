using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace luchadores.Models
{
    [Table("verb", Schema = "prod")]
    public class Verb
    {
        public long ID { get; set; }
        public string FirstLetter { get; set; }
        public string Name { get; set; }
        public string Tense { get; set; }
        public string Form1 { get; set; }
        public string Form2 { get; set; }
        public string Form3 { get; set; }
        public string Form4 { get; set; }
        public string Form5 { get; set; }
        public string Form6 { get; set; }

    }

    public enum Letter
    {
        a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,r,s,t,u,v,x,y,z
    }
}
