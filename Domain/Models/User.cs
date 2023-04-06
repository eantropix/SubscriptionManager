namespace Domain.Models
{
    public class User : Entity
    {
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
