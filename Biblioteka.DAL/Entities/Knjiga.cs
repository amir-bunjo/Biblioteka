using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteka.DAL.Entities
{
    public class Knjiga 
    {
        public Knjiga()
        {
            Autori = new List<AutorKnjiga>();
        }
        [Key]
        public int kId { get; set; }
        public string Naslov { get; set; }
        public decimal Cijena { get; set; }
        public virtual Izdavac Izdavac { get; set; }
        public virtual IList<AutorKnjiga> Autori { get; set; }
    }
}
