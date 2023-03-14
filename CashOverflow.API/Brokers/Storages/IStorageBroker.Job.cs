﻿// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by me :)
// --------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using CashOverflow.API.Models.Jobs;

namespace CashOverflow.API.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Job> InsertJobAsync(Job job);
        IQueryable<Job> SelectAllJobs();
        ValueTask<Job> SelectJobByIDAsync(Job job);
    }
}
