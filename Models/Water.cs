namespace WellNote.Models
{
    public class Water
    {
        public int Id { get; set; }
        
        //The user logged in
        public int UserId { get; set; }
        public User User { get; set; }

        //The datetime for when the user logged it
        public DateTime DateTime { get; set; }

        //The amount of water drunk in a day
        public double Quantity { get; set; }
    }
}
