using FishApp.Data;
using FishApp.Interfaces;
using FishApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUserByUserId(int userId)
        {
            return _context.Users
                .Include(c => c.Catches).ThenInclude(f => f.Fish)
                .Include(c => c.Catches).ThenInclude(fg => fg.FishingGround).FirstOrDefault(u => u.Id == userId);
        }

        public ApplicationUser GetUserByUserName(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName);
        }
    }
}


//_context.Users.FirstOrDefault(u => u.Id == userId);