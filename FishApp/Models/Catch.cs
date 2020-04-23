using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.Models
{
    public class Catch
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, Range(1, int.MaxValue)]
        [Display(Name = "Längd i CM")]
        public double Length { get; set; }

        [Required, Range(0, Int32.MaxValue)]
        [Display(Name = "Vikt i KG")]
        public double Weight { get; set; }

        [MaxLength(512)]
        [Display(Name = "Anteckningar")]
        public string Notes { get; set; }

        [Required]
        public int FishId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [Required]
        public int FishingGroundId { get; set; }

        public ApplicationUser User { get; set; }
        public FishingGround FishingGround { get; set; }
        public Fish Fish { get; set; }

        public Catch()
        {

        }

        public Catch(DateTime date, double length, double weight, string notes, int fishId, int userId, int fishingGroundId)
        {
            Date = date;
            Length = length;
            Weight = weight;
            Notes = notes;
            FishId = fishId;
            UserId = userId;
            FishingGroundId = fishingGroundId;
        }
    }
}
