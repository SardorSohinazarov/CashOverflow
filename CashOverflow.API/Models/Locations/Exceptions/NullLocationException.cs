// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using Xeptions;

namespace CashOverflow.API.Models.Locations.Exceptions
{
    public class NullLocationException : Xeption
    {
        public NullLocationException() :
            base(message:"Location is null.")
        {}
    }
}
