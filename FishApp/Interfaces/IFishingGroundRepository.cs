﻿using FishApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishApp.Interfaces
{
    public interface IFishingGroundRepository
    {
        IEnumerable<FishingGround> FishingGrounds { get; }
        FishingGround GetFishingGroundById(int id);
    }
}
