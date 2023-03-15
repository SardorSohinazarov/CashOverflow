// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using Xeptions;

namespace CashOverflow.API.Models.Locations.Exceptions
{
    public class InvalidLocationException : Xeption
    {
        public InvalidLocationException()
            : base(message: "Location is invalid.")
        { }
    }
}
