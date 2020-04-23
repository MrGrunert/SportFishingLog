using FishApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.Interfaces
{
    public interface IParishRepository
    {
        IEnumerable<Parish> Parishes { get; }
    }
}
