// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using System.Threading.Tasks;
using CashOverflow.API.Brokers.Loggings;
using CashOverflow.API.Brokers.Storages;
using CashOverflow.API.Models.Locations;

namespace CashOverflow.API.Services.Foundations.Locations
{
    public partial class LocationService : ILocationService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public LocationService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Location> AddLocationAsync(Location location) =>
        TryCatch(async () =>
        {
            ValidateLocationNotNull(location);

            return await this.storageBroker.InsertLocationAsync(location);
        });
    }
}
