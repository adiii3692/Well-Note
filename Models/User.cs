namespace WellNote.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string username { get; set; }
        public required string password { get; set; }

        //A list to track the user's water intake and sleep
        public List<Water>? Water { get; set; }
        public List<Sleep>? Sleep { get; set; }

        //Whem the user was created
        public DateTime createdAt { get; set; } = DateTime.UtcNow;
    }
}
