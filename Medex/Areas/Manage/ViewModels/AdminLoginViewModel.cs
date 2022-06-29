using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medex.Areas.Manage.ViewModels
{
    public class AdminLoginViewModel
    {
        [Required]
        [MaxLength(25)]
        [MinLength(8)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
