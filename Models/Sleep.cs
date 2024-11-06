namespace WellNote.Models
{
    public class Sleep
    {
        public int Id { get; set; }

        //The user logged in
        public int UserId { get; set; }
        public User User { get; set; }

        //The datetime for when the user logged it
        public DateTime DateTime { get; set; }

        //The amount of sleep the user got
        public double Quantity { get; set; }
    }
}
