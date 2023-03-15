// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using CashOverflow.API.Models.Locations;
using FluentAssertions;
using Force.DeepCloner;
using Moq;

namespace CashOverflow.Infrastructure.Build.Services.Foundations.Locations
{
    public partial class LocationServiceTests 
    {
        [Fact]
        public async Task ShouldAddLocationAsync()
        {
            //given
            Location randomLocation = CreateRandomLocation();
            Location inputLocation = randomLocation;
            Location persistentLocation = inputLocation;
            Location expectedLocation = persistentLocation.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertLocationAsync(inputLocation))
                    .ReturnsAsync(expectedLocation);

            //when
            Location actualLocation = await this.locationService
                .AddLocationAsync(inputLocation);

            //then
            actualLocation.Should().BeEquivalentTo(expectedLocation);

            this.storageBrokerMock.Verify(broker => 
                broker.InsertLocationAsync(inputLocation),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            
        }
    }
}