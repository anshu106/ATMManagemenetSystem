using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMManagementSystem.API.Models
{
    public class TransactionModel
    {
    [Key]
    public int TransactionId { get; set; }

    [Required(ErrorMessage = "Account ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Account.")]
    public int AccountId { get; set; }

    // Navigation Property mapped to the Foreign Key above
    [ForeignKey(nameof(AccountId))]
    public virtual AccountModel Account { get; set; }

    [Required(ErrorMessage = "Transaction type is required.")]
    [RegularExpression("^(Deposit|Withdrawal|Transfer)$", ErrorMessage = "Transaction type must be 'Deposit', 'Withdrawal', or 'Transfer'.")]
    public string? TransactionType { get; set; }

    [Required(ErrorMessage = "Transaction amount is required.")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Balance after transaction is required.")]
    public decimal BalanceAfterTransaction { get; set; }

    [Required(ErrorMessage = "Transaction date is required.")]
    [DataType(DataType.DateTime)]
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

    [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
    public string Description { get; set; }

    
    }
}