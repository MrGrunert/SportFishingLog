using FishApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.Interfaces
{
    public interface IUserRepository
    {
        ApplicationUser GetUserByUserId(int userId);
        ApplicationUser GetUserByUserName(string userName);
    }
}
