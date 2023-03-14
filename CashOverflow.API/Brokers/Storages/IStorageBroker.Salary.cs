// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using CashOverflow.API.Models.Salaries;

namespace CashOverflow.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Salary> InsertSalaryAsync(Salary salary);
        IQueryable<Salary> SelectAllSalaries();
        ValueTask<Salary> SelectSalaryByIdAsync(Guid salaryId);
    }
}
