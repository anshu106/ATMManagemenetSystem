
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ATMManagementSystem.API.Models
{
    public class AccountModel
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")] 
        public string AccountNumber { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")] 
        public decimal Balance { get; set; }

        [Required]
        public DateTime? CreatedAt { get; set; } 

        [Required]
        public bool IsActive { get; set; } = true; 
        
        public virtual UserModel User { get; set; } //why virtual

        public ICollection<TransactionModel> Transaction {get;set;} = new List<TransactionModel>();
    }
}   