using Microsoft.EntityFrameworkCore;
using WellNote.Models;

namespace WellNote.Data
{
    public class WellNoteContext:DbContext
    {
        //Constructor for the context
        public WellNoteContext(DbContextOptions<WellNoteContext> options) : base(options){ }

        //Specify the relationship between the user, the water and the sleep models
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {     
            //User and Sleep Relationship
            modelBuilder.Entity<Sleep>()
                .HasOne(u => u.User)
                .WithMany(u => u.Sleep)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //User and Water Relationship
            modelBuilder.Entity<Water>()
                .HasOne(u => u.User)
                .WithMany(u => u.Water)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        //Make the DBSets now
        public DbSet<User> Users { get; set; }
        public DbSet<Sleep> Sleep { get; set; }
        public DbSet<Water> Water { get; set; }

    }
}
