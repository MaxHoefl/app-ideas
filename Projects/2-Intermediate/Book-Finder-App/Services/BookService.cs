using Bit_Masks_App.Models;

namespace Book_Finder_App.Services;

public class BookService
{
    private readonly List<Book> _books = new()
    {
        new()
        {
            Id = 0, 
            Title = "Animal Farm", 
            Author = "George Orwell", 
            PublishedDate = new DateTime(1945, 8, 17), 
            CoverImageUri = new Uri("https://m.media-amazon.com/images/I/91LUbAcpACL._AC_UF894,1000_QL80_.jpg")
        },
        new()
        {
            Id = 1, 
            Title = "1984", 
            Author = "George Orwell", 
            PublishedDate = new DateTime(1949, 6, 8), 
            CoverImageUri = new Uri("https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQBqrcxiqPOZZDuez9cZGTj9emlw1oMN35nes1Ox-ykKfLyPkLj")
        },
        new()
        {
            Id = 2, 
            Title = "Pride and Prejudice", 
            Author = "Jane Austin", 
            PublishedDate = new DateTime(1813, 1, 28), 
            CoverImageUri = new Uri("https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1320399351i/1885.jpg")
        },
        new()
        {
            Id = 3, 
            Title = "The Picture of Dorian Gray", 
            Author = "Oscar Wilde", 
            PublishedDate = new DateTime(1890, 6, 1), 
            CoverImageUri = new Uri("https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1546103428i/5297.jpg")
        },
        new()
        {
            Id = 5, 
            Title = "Brave New World", 
            Author = "Aldous Huxley", 
            PublishedDate = new DateTime(1932, 1, 1), 
            CoverImageUri = new Uri("https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1575509280i/5129.jpg")
        }
    };
    
    public IEnumerable<Book> GetBooks(string? searchTerm)
    {
        if (searchTerm == null) return _books;
        return _books.FindAll(b =>
            b.Title.Contains(searchTerm) || 
            b.Author.Contains(searchTerm) ||
            b.PublishedDate.ToLongDateString().Contains(searchTerm));
    }
}