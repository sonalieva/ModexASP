using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Medex.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Desc { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Profession { get; set; }
        public string Icons { get; set; }
        [NotMapped]
        public IFormFile ImageFiles { get; set; }
       
    }
}
