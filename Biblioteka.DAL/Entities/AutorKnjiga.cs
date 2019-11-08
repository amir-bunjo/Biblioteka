using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka.DAL.Entities
{
    public class AutorKnjiga
    {

        public int Id { get; set; }
        public virtual Autor Autor { get; set; }
        public virtual Knjiga Knjiga { get; set; }
    }
}
