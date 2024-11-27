using Microsoft.EntityFrameworkCore;
using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Data
{

    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<LibraryItem> LibraryItems { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<EBook> EBooks { get; set; }
        public DbSet<AudioBook> AudioBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibraryItem>()
                .HasKey(item => item.ItemID);

            modelBuilder.Entity<Book>()
                .HasKey(book => book.BookID);

            modelBuilder.Entity<EBook>()
                .HasKey(ebook => ebook.EBookID);

            modelBuilder.Entity<AudioBook>()
                .HasKey(audiobook => audiobook.AudioBookID);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.LibraryItem)
                .WithOne()
                .HasForeignKey<Book>(b => b.ItemID);

            modelBuilder.Entity<EBook>()
                .HasOne(e => e.LibraryItem)
                .WithOne()
                .HasForeignKey<EBook>(e => e.ItemID);

            modelBuilder.Entity<AudioBook>()
                .HasOne(a => a.LibraryItem)
                .WithOne()
                .HasForeignKey<AudioBook>(a => a.ItemID);
            modelBuilder.Entity<LibraryItem>()
                .Property(i => i.ItemID)
                .ValueGeneratedOnAdd();
        }   
    }



}