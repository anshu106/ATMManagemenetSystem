using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMManagementSystem.API.Models
{
    public class UserModel
    {
        [Key]
        [Required(ErrorMessage="UserId is required")]
        public int UserId{get;set;}
        [Required(ErrorMessage="Name is required field")]
        public string FullName{get;set;}
        [Required(ErrorMessage="Valid Email address is required")]
        public string Email{get;set;}
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", 
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character (@$!%*?&).")]
        public string PasswordHash{get;set;}

        public ICollection<AccountModel> Account {get;set;}= new List<AccountModel>();
    }
}