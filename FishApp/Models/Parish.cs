using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.Models
{
    public class Parish
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Kommun")]
        public string Name { get; set; }
        public ICollection<FishingGround> FishingGrounds { get; set; }


        public Parish()
        {

        }

        public Parish(string name)
        {
            Name = name;
        }
    }
}
