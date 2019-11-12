using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Web.Models
{
    public class IzdavacModel
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Sjediste { get; set; }

        public IEnumerable<SelectListItem> listaSvihKnjiga { get; set; }
        public List<int> Knjige { get; set; }
    }
}
