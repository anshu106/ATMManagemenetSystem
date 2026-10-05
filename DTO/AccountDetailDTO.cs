namespace ATMManagementSystem.API.DTO
{
    public class AccountDetailDTO
    {
        public string AccountNumber{get;set;}
        public decimal Balance { get; set; }
        public int AccountId { get; set; }
        public bool IsActive { get; set; } = true; 
        public string FullName{get;set;}
    }
}