using FishApp.Data;
using FishApp.Interfaces;
using FishApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.Repositories
{
    public class FishRepository : IFishRepository
    {
        private ApplicationDbContext _context;

        public FishRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Fish> Fishes => _context.Fish.OrderBy(f => f.Name);
    }
}
