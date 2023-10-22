namespace Bit_Masks_App.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublishedDate { get; set; }
    public Uri CoverImageUri { get; set; }
}