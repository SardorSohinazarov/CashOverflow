using System;
using System.ComponentModel.DataAnnotations;

namespace CashOverflow.API.Models.Languages
{
    public class Language
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
