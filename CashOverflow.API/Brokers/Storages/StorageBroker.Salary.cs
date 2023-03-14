// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using CashOverflow.API.Models.Salaries;
using Microsoft.EntityFrameworkCore;

namespace CashOverflow.API.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Salary> Salaries { get; set; }

        public async ValueTask<Salary> InsertSalaryAsync(Salary salary) =>
            await InsertAsync(salary);

        public IQueryable<Salary> SelectAllSalaries() =>
            SelectAll<Salary>();
    }
}
