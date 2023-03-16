// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using System.Linq.Expressions;
using CashOverflow.API.Brokers.DateTimes;
using CashOverflow.API.Brokers.Loggings;
using CashOverflow.API.Brokers.Storages;
using CashOverflow.API.Models.Locations;
using CashOverflow.API.Services.Foundations.Locations;
using Moq;
using Tynamix.ObjectFiller;
using Xeptions;

namespace CashOverflow.Infrastructure.Build.Services.Foundations.Locations
{
    public partial class LocationServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ILocationService locationService;

        public LocationServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();

            this.locationService = new LocationService(
                this.storageBrokerMock.Object,
                this.dateTimeBrokerMock.Object,
                this.loggingBrokerMock.Object);
        }


        private static Location CreateRandomLocation() =>
            CreateLocationFiller(dates: GetRandomDatetimeOffset()).Create();

        private static Filler<Location> CreateLocationFiller(DateTimeOffset dates)
        {
            var filler = new Filler<Location>();

            filler.Setup().OnType<DateTimeOffset>().Use(dates);

            return filler;
        }

        private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        private static DateTimeOffset GetRandomDatetimeOffset() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();
    }
}
