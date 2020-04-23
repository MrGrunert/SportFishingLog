using FishApp.Models;
using System.Collections.Generic;

namespace FishApp.Interfaces
{
    public interface ICatchRepository
    {
        Catch Add(Catch fishCatch);
        Catch Get(int id);
        void UpdateCatch(Catch fishCatch);
        void DeleteCatch(Catch fishCatch);
        IEnumerable<Catch> GetAllCatches();
        void Commit();
    }
}
