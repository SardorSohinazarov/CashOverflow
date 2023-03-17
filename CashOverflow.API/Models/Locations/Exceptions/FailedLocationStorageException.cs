// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using System;
using Xeptions;

namespace CashOverflow.API.Models.Locations.Exceptions
{
    public class FailedLocationStorageException : Xeption
    {
        public FailedLocationStorageException(Exception innerException)
            :base(message:"Failed location storage exception occured, contact support",innerException)
        {}
    }
}
