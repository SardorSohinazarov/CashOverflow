// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using CashOverflow.API.Brokers.Storages;
using CashOverflow.API.Models.Locations;
using CashOverflow.API.Services.Foundations.Locations;
using Moq;
using Tynamix.ObjectFiller;

namespace CashOverflow.Infrastructure.Build.Services.Foundations.Locations
{
    public partial class LocationServiceTests
    {
        private readonly Mock<IStorageBroker> mockStorageBroker;
        private readonly ILocationService locationService;

        public LocationServiceTests()
        {
            this.mockStorageBroker = new Mock<IStorageBroker>();

            this.locationService = new LocationService(this.mockStorageBroker.Object);
        }


        private static Location CreateRandomLocation() =>
            CreateLocationFiller(dates: GetRandomDatetimeOffset()).Create();

        private static Filler<Location> CreateLocationFiller(DateTimeOffset dates)
        {
            var filler = new Filler<Location>();

            filler.Setup().OnType<DateTimeOffset>().Use(dates);

            return filler;
        }

        private static DateTimeOffset GetRandomDatetimeOffset() =>
            new DateTimeRange(earliestDate:DateTime.UnixEpoch).GetValue();
    }
}
