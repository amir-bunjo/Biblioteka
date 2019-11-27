using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka.Web.DAL.Entities
{
    public class AutorKnjiga
    {

        public int Id { get; set; }
        public virtual Autor Autor { get; set; }
        public virtual Knjiga Knjiga { get; set; }
    }
}
