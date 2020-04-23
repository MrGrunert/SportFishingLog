using FishApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.ViewModels
{
    public class MyPageViewModel
    {
        public MyPageViewModel(ApplicationUser user)
        {
            User = user;
            Catches = user.Catches;
        }

        public ApplicationUser User { get; set; }
        public IEnumerable<Catch> Catches { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
    }
}

