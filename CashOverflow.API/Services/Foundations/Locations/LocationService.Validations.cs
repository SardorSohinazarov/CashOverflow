// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using System;
using CashOverflow.API.Models.Locations;
using CashOverflow.API.Models.Locations.Exceptions;

namespace CashOverflow.API.Services.Foundations.Locations
{
    public partial class LocationService
    {
        private void ValidateLocationOnAdd(Location location)
        {
            ValidateLocationNotNull(location);

            Validate(
                (Rule: IsInvalid(location.Id), Parametr: nameof(Location.Id)),
                (Rule: IsInvalid(location.Name), Parametr: nameof(Location.Name)),
                (Rule: IsInvalid(location.CreatedDate), Parametr: nameof(Location.CreatedDate)),
                (Rule: IsInvalid(location.UpdatedDate), Parametr: nameof(Location.UpdatedDate))
                //(Rule:IsInvalid(location.Country), Parametr: nameof(Location.Country))
                );
        }

        private static void ValidateLocationNotNull(Location location)
        {
            if (location is null)
            {
                throw new NullLocationException();
            }
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private void Validate(params (dynamic Rule, string Parametr)[] validations)
        {
            var invalidLocationException = new InvalidLocationException();

            foreach ((dynamic rule, string parametr) in validations)
            {
                if (rule.Condition)
                {
                    invalidLocationException.UpsertDataList(
                        key: parametr,
                        value: rule.Message);
                }
            }

            invalidLocationException.ThrowIfContainsErrors();
        }
    }
}
