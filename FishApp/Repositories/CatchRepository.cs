using FishApp.Data;
using FishApp.Interfaces;
using FishApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.Repositories
{

    public class CatchRepository : ICatchRepository
    {
        private ApplicationDbContext _context;

        public CatchRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public Catch Add(Catch fishCatch)
        {
            _context.Add(fishCatch);
            return fishCatch;
        }

        public void DeleteCatch(Catch fishCatch)
        {
            _context.Remove(fishCatch);
        }

        public Catch Get(int id)
        {
            return _context.Catches.Include(f => f.Fish).Include(u => u.User).Include(fg => fg.FishingGround).ThenInclude(fgs => fgs.Parish).FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Catch> GetAllCatches()
        {
           return _context.Catches
                 .Include(f => f.Fish).Include(u => u.User).Include(fg => fg.FishingGround).ToList();
        }

        public void UpdateCatch(Catch fishCatch)
        {
            if (fishCatch == null)
            {
                var error = "An army of monkies broke the website...";
                throw new ArgumentNullException(error);
            }
            if (fishCatch.Id < 1)
            {
                throw new ArgumentException($"Catch id cannot be 0! {fishCatch.Id}");
            }

            _context.Catches.Update(fishCatch);
            _context.SaveChanges();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
