using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Web.Models
{
    public class GroupViewModel
    {
        public IEnumerable<SelectListItem> Schedules { get; set; }
        public int ScheduleId { get; set; }
    }
}
