using Bit_Masks_App.Models;
using Book_Finder_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_Finder_App.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly BookService _service;
    public IEnumerable<Book> BookSearchResult { get; set; }

    [BindProperty(SupportsGet = true)]
    public string SearchQuery { get; set; }

    public IndexModel(ILogger<IndexModel> logger, BookService service)
    {
        _logger = logger;
        _service = service;
    }

    public void OnGet()
    {
        Console.WriteLine(SearchQuery);
        BookSearchResult = _service.GetBooks(SearchQuery);
    }
}