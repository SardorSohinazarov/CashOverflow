// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using System.Threading.Tasks;
using CashOverflow.API.Brokers.DateTimes;
using CashOverflow.API.Brokers.Loggings;
using CashOverflow.API.Brokers.Storages;
using CashOverflow.API.Models.Locations;

namespace CashOverflow.API.Services.Foundations.Locations
{
    public partial class LocationService : ILocationService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public LocationService(
            IStorageBroker storageBroker,
            IDateTimeBroker dateTimeBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.dateTimeBroker = dateTimeBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Location> AddLocationAsync(Location location) =>
        TryCatch(async () =>
        {
            ValidateLocationOnAdd(location);

            return await this.storageBroker.InsertLocationAsync(location);
        });
    }
}
