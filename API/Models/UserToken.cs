namespace DATN.Models
{
    public class UserToken
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
