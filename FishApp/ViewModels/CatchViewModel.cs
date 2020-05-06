using FishApp.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.ViewModels
{
    public class CatchViewModel
    {
        public int Id { get; set; }

        public int FishingGroundId { get; set; }

        //TODO: Add class for custom date range.
        //[CustomDateRange]
        [Display(Name = "Datum")]
        public DateTime Date { get; set; } = DateTime.Now.Date;

        [Required, Range(1, 600, ErrorMessage = "Längd måste vara mellan 1-600cm")]
        [Display(Name = "Längd i CM")]
        public double Length { get; set; }

        [Required, Range(0.1, 1100.0, ErrorMessage = "vikt måste vara mellan 1-1100kg")]
        [Display(Name = "Vikt i KG")]
        public double Weight { get; set; }

        [MaxLength(512)]
        [Display(Name = "Anteckningar")]
        public string Notes { get; set; }

        [Required]
        public int FishId { get; set; }

        [Required]
        public int ParishId { get; set; }

        [Required, MaxLength(80)]
        [Display(Name = "Vattendrag")]
        public string FishingGroundName { get; set; }
        [Required]
        [Display(Name = "Typ av vattendrag")]
        public FishingGroundType FishingGroundType { get; set; }

        public string FishName { get; set; }

        [Display(Name = "Fisk")]
        public List<SelectListItem> FishesSelectListItems { get; set; }

        [Display(Name = "Kommun")]
        public List<SelectListItem> ParishesSelectListItems { get; set; }
    }
}
