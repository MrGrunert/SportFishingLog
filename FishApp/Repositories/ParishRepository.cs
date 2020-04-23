using FishApp.Data;
using FishApp.Interfaces;
using FishApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.Repositories
{
    public class ParishRepository : IParishRepository
    {
        private ApplicationDbContext _context;

        public ParishRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Parish> Parishes => _context.Parishes.OrderBy(p => p.Name);
    }
}
