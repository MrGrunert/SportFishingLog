using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.Models
{
    public class Contest
    {
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(80)]
        [Display(Name = "Tävlingens namn")]
        public string ContestName { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy}")]
        [Display(Name = "Tävlingsår")]
        public DateTime Date { get; set; }

        [Required, Range(1, int.MaxValue)]
        [Display(Name = "Längd i CM")]
        public double Length { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [Display(Name = "Fiskare")]
        public ApplicationUser User { get; set; }

        public Contest(DateTime date, double length, int userId, string contestName)
        {
            Date = date;
            Length = length;
            UserId = userId;
            ContestName = contestName;
        }
    }
}
