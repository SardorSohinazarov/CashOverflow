// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using CashOverflow.API.Models.Locations;

namespace CashOverflow.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Location> InsertLocationAsync(Location location);
        IQueryable<Location> SelectAllLocations();
        ValueTask<Location> SelectLocationByIdAsync(Guid locationId);
        ValueTask<Location> UpdateLocationAsync(Location location);
        ValueTask<Location> DeleteLocationAsync(Location location);
    }
}
