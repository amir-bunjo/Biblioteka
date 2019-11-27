using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteka.Web.DAL.Entities
{
    public class Izdavac 
    {
        public Izdavac()
        {
            Knjige = new List<Knjiga>();
        }
        [Key]
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Sjediste { get; set; }
        public virtual IList<Knjiga> Knjige { get; set; }

    }
}
