using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;

namespace my_books.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author_Book>()
                .HasOne<Book>(b=>b.Book)
                .WithMany(ba=>ba.Author_Books)
                .HasForeignKey(ba=>ba.BookId);

            modelBuilder.Entity<Author_Book>()
                .HasOne<Author>(a => a.Author)
                .WithMany(ba => ba.Author_Books)
                .HasForeignKey(ba => ba.AuthorId);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Author_Book> Author_Books { get; set; }
    }
}
