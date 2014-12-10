using System.ComponentModel.DataAnnotations;

namespace TransactionService.Models
{
    public class Transaction
    {
        [Required]
        public decimal? Amount { get; set;  }

        public string Description { get; set; }

        [Required]
        public bool? WasPlanned { get; set; }

        [Required]
        public bool? WasNecessary { get; set; }

        public Data_Access.Transaction ToDataAccessTransaction()
        {
            return new Data_Access.Transaction
            {
                Amount = Amount.Value,
                Description = Description,
                WasNecessary = WasNecessary.Value,
                WasPlanned = WasPlanned.Value
            };
        }
    }
}