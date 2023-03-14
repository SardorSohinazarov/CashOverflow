﻿// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using CashOverflow.API.Models.Jobs;
using CashOverflow.API.Models.Locations;

namespace CashOverflow.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Location> InsertLocationAsync(Location location);
        IQueryable<Location> SelectAllLocations();
    }
}
