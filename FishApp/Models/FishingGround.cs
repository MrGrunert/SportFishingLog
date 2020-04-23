using FishApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.Models
{
    public class FishingGround
    {
        public int Id { get; set; }
        [Required, MaxLength(80)]
        [Display(Name = "Vattendrag")]
        public string Name { get; set; }
        [Required]
        public FishingGroundType Type { get; set; }
        [Required]
        public int ParishId { get; set; }

        public Parish Parish { get; set; }
        public ICollection<Catch> Catches { get; set; }

        public FishingGround()
        {

        }

        public FishingGround(string name, FishingGroundType type, int parishId)
        {
            Name = name;
            Type = type;
            ParishId = parishId;
        }
    }
}
