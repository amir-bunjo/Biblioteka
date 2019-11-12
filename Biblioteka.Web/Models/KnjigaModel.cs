using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Web.Models
{
    public class KnjigaModel
    {
        public int kId { get; set; }
        public string Naslov { get; set; }
        public decimal Cijena { get; set; }

        public IEnumerable<SelectListItem> listaSvihAutora { get; set; }
        public List<int> Autori { get; set; }

        public IEnumerable<SelectListItem> listaSvihIzdavaca { get; set; }
        public int Izdavac { get; set; }
    }
}
