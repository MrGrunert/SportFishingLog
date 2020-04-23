using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public virtual ICollection<IdentityUserClaim<int>> Claims { get; set; }
        public ICollection<Catch> Catches { get; set; }
        public string CustomTag { get; set; }
    }
}
