using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Web.Models { 

    public class RoleModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }

        public string RoleId { get; set; }
    }
}