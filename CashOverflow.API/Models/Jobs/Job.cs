using System;
using System.ComponentModel.DataAnnotations;

namespace CashOverflow.API.Models.Jobs
{
    public class Job
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Level Level { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
