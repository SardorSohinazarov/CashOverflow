// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using System;
using System.Data;
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
                (Rule: IsInvalid(location.UpdatedDate), Parametr: nameof(Location.UpdatedDate)),
                (Rule: IsNotRecent(location.CreatedDate), Parametr: nameof(Location.CreatedDate)),
                (Rule: IsInvalid(
                    location.CreatedDate,
                    location.UpdatedDate,
                    nameof(location.UpdatedDate)),
                Parametr: nameof(Location.CreatedDate)));
        }

        private static void ValidateLocationNotNull(Location location)
        {
            if (location is null)
            {
                throw new NullLocationException();
            }
        }

        private dynamic IsNotRecent(DateTimeOffset date) => new
        {
            Condition = IsDateNotRecent(date),
            Message = "Date is not recent"
        };

        private bool IsDateNotRecent(DateTimeOffset date)
        {
            DateTimeOffset currentDate =
                this.dateTimeBroker.GetCurrentDateTimeOffSet();

            TimeSpan timeDifference = currentDate.Subtract(date);

            return timeDifference.TotalSeconds is > 60 or < 0;
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

        private static dynamic IsInvalid(
            DateTimeOffset firstDate,
            DateTimeOffset secondDate,
            string secondDateName) 
        => new{
                Condition = firstDate != secondDate,
                Message = $"Date is not same as {secondDateName}"
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
