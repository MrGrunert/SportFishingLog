using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.Models
{
    public class Fish
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Fish()
        {

        }

        public Fish(string name)
        {
            Name = name;
        }
    }
}
