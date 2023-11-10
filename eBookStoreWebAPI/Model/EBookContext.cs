using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Model
{
    public class EBookContext : DbContext
    {
        //public EBookContext() { }
        public EBookContext(DbContextOptions<EBookContext> options) : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var builder = new ConfigurationBuilder()
        //         .SetBasePath(Directory.GetCurrentDirectory())
        //         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //    IConfigurationRoot configuration = builder.Build();
        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("eBookStore"));
        //}
        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<BookAuthor> BookAuthors { get; set; }

        public virtual DbSet<Publisher> Publishers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
           .HasKey(j => new { j.BookId, j.AuthorId });
            modelBuilder.Entity<User>().HasNoKey();

            modelBuilder.Entity<BookAuthor>()
           .HasOne(j => j.Book)
           .WithMany(f => f.BookAuthors)
           .HasForeignKey(j => j.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(j => j.Author)
                .WithMany(f => f.BookAuthors)
                .HasForeignKey(j => j.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
            .HasKey(u => u.UserId);

            modelBuilder.Entity<User>()
                .HasOne(j => j.Role)
                .WithMany(f => f.Users)
                .HasForeignKey(j => j.RoleId);

            modelBuilder.Entity<User>()
                .HasOne(j => j.Publisher)
                .WithMany(f => f.Users)
                .HasForeignKey(j => j.PubId);

            modelBuilder.Entity<Book>()
                .HasOne(j => j.Publisher)
                .WithMany(f => f.Books)
                .HasForeignKey(j => j.PubId);

        }
    }
}
