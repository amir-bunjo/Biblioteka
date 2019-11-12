using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Web.Models
{
    public class AutorModel
    {
        public int aId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Biografija { get; set; }

        public IEnumerable<SelectListItem> listaSvihKnjiga { get; set; }
        public List<int> Knjige { get; set; }
    }
}
