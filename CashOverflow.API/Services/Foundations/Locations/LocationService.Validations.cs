// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using CashOverflow.API.Models.Locations;
using CashOverflow.API.Models.Locations.Exceptions;

namespace CashOverflow.API.Services.Foundations.Locations
{
    public partial class LocationService
    {
        private static void ValidateLocationNotNull(Location location)
        {
            if (location is null)
            {
                throw new NullLocationException();
            }
        }
    }
}
