using FishApp.Data;
using FishApp.Interfaces;
using FishApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.Repositories
{
    public class FishingGroundRepository : IFishingGroundRepository
    {
        private ApplicationDbContext _context;

        public FishingGroundRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FishingGround> FishingGrounds => _context.FishinGrounds;

        public FishingGround GetFishingGroundById(int id)
        {
            return _context.FishinGrounds.FirstOrDefault(f => f.Id == id);
        }
    }
}
