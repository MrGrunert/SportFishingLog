using FishApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Catch> Catches { get; set; }
    }
}
