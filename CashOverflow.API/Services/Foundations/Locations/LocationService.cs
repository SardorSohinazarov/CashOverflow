// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using System.Threading.Tasks;
using CashOverflow.API.Brokers.Storages;
using CashOverflow.API.Models.Locations;

namespace CashOverflow.API.Services.Foundations.Locations
{
    public class LocationService : ILocationService
    {
        private readonly IStorageBroker storageBroker;

        public LocationService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<Location> AddLocationAsync(Location location) =>
            await storageBroker.InsertLocationAsync(location);
    }
}
