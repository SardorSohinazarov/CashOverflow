// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using System.Threading.Tasks;
using CashOverflow.API.Models.Locations;

namespace CashOverflow.API.Services.Foundations.Locations
{
    public interface ILocationService
    {
        ValueTask<Location> AddLocationAsync(Location location);
    }
}
