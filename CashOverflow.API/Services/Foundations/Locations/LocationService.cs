// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using System.Threading.Tasks;
using CashOverflow.API.Brokers.Storages;
using CashOverflow.API.Models.Locations;
using CashOverflow.API.Models.Locations.Exceptions;

namespace CashOverflow.API.Services.Foundations.Locations
{
    public class LocationService : ILocationService
    {
        private readonly IStorageBroker storageBroker;

        public LocationService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<Location> AddLocationAsync(Location location)
        {
            try
            {
                if(location is null)
                {
                    throw new NullLocationException();
                }
                return await storageBroker.InsertLocationAsync(location);
            }
            catch (NullLocationException nullLocationException)
            {
                LocationValidationException locationValidationException = 
                    new LocationValidationException(nullLocationException);

                this.loggingBroker.LogError(locationValidationException);

                throw locationValidationException;
            }
        }
    }
}
