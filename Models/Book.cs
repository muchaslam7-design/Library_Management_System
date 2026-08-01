using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
   public class Book
{
    public int BookID { get; set; }
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public decimal Price { get; set; } // Yeh line add karein
    public int AuthorID { get; set; }
    public Author? Author { get; set; }
}
}