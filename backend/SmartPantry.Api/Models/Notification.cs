using System;


namespace SmartPantry.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // FK
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
