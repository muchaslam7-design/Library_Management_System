using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Author
{
    public int AuthorID { get; set; }
    public required string Name { get; set; }
    public required string Country { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}
}