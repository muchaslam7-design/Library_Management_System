using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseMySql("Server=localhost;Database=LibraryDb;Uid=root;Pwd=MySecure@123;", ServerVersion.AutoDetect("Server=localhost;Database=LibraryDb;Uid=root;Pwd=MySecure@123;"));
}
    }
}