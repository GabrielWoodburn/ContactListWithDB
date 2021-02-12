using Microsoft.EntityFrameworkCore;

namespace ContactsListDBWoodburn.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=tcp:cis174gwoodburn.database.windows.net,1433;Initial Catalog=CIS174DB;Persist Security Info=False;User ID=cis174;Password=5630Pass#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 4,
                    Name = "Casablanca",
                    PhoneNumber = "555-5555",
                    Address = "100 Main Avenue",
                    CommentId = "D"
                },
                new Contact
                {
                    ContactId = 2,
                    Name = "Wonder Woman",
                    PhoneNumber = "555-5555",
                    Address = "100 Main Avenue",
                    CommentId = "A"
                },
                new Contact
                {
                    ContactId = 3,
                    Name = "Moonstruck",
                    PhoneNumber = "555-5555",
                    Address = "100 Main Avenue",
                    CommentId = "E"
                }
            );
            modelBuilder.Entity<Comment>().HasData(
                new Comment { CommentId = "A", Name = "Family" },
                new Comment { CommentId = "B", Name = "Work" },
                new Comment { CommentId = "C", Name = "Friend" },
                new Comment { CommentId = "D", Name = "Technical" },
                new Comment { CommentId = "E", Name = "Other" }
            );
        }
    }
}