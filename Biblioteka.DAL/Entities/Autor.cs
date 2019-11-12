using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteka.DAL.Entities
{
    public class Autor
    {
        public Autor()
        {
            Knjige = new List<AutorKnjiga>();
        }
        [Key]
        public int aId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Biografija { get; set; }
        public virtual IList<AutorKnjiga> Knjige { get; set; }

    }
}
