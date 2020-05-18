using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.ViewModels
{
    public class DeleteCatchViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Fångstdatum")]
        public string Date { get; set; }

        [Display(Name = "Art")]
        public string FishName { get; set; }

        [Display(Name = "Fångstplats")]
        public string FishingGround { get; set; }
    }
}
