using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka.DAL.Entities
{
    public class BaznaKlasa
    {
        public BaznaKlasa()
        {
            Kreiran = DateTime.Now;
            Obrisan = false;
        }
        public DateTime Kreiran { get; set; }
        public bool Obrisan { get; set; }
    }
}
