// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using CashOverflow.API.Models.Locations;
using Microsoft.EntityFrameworkCore;

namespace CashOverflow.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Location> Locations { get; set; }

        public async ValueTask<Location> InsertLocationAsync(Location location) =>
            await InsertAsync(location);

        public IQueryable<Location> SelectAllLocations() =>
            SelectAll<Location>();

        public async ValueTask<Location> SelectLocationByIdAsync(Guid locationId) =>
            await SelectAsync<Location>(locationId);
    }
}
