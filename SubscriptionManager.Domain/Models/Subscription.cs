namespace SubscriptionManager.Domain.Models
{
    public class Subscription : Entity
    {
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}