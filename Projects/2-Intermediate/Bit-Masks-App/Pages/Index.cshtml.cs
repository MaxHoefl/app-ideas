using Bit_Masks_App.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic.CompilerServices;

namespace Bit_Masks_App.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public readonly List<TimeZoneLocation> TimeZoneLocations;

    public List<TimeZoneLocation> SearchResults { get; set; } = default!;
    
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        TimeZoneLocations = new List<TimeZoneLocation>()
        {
            new() { Location = "Moscow",           GmtOffset = 3,  Bitmask = 0b_000000000000_001000000000},
            new() { Location = "Paris",            GmtOffset = 2,  Bitmask = 0b_000000000000_010000000000 },
            new() { Location = "Berlin",           GmtOffset = 2,  Bitmask = 0b_000000000000_010000000000 },
            new() { Location = "Brussels",         GmtOffset = 2,  Bitmask = 0b_000000000000_010000000000 },
            new() { Location = "Amsterdam",        GmtOffset = 2,  Bitmask = 0b_000000000000_010000000000 },
            new() { Location = "Rome",             GmtOffset = 2,  Bitmask = 0b_000000000000_010000000000 },
            new() { Location = "London",           GmtOffset = 1,  Bitmask = 0b_000000000000_100000000000 },
            new() { Location = "Dublin",           GmtOffset = 1,  Bitmask = 0b_000000000000_100000000000 },
            new() { Location = "New York",         GmtOffset = -4, Bitmask = 0b_000000001000_000000000000 },
            new() { Location = "Washington, DC",   GmtOffset = -4, Bitmask = 0b_000000001000_000000000000 },
            new() { Location = "St. Louis",        GmtOffset = -5, Bitmask = 0b_000000010000_000000000000 },
            new() { Location = "Los Angeles",      GmtOffset = -7, Bitmask = 0b_000001000000_000000000000 },
            new() { Location = "Tokyo",            GmtOffset = 9,  Bitmask = 0b_000000000000_000000001000 },
            new() { Location = "Beijing",          GmtOffset = 8,  Bitmask = 0b_000000000000_000000010000 },
            new() { Location = "Ho Chi Minh City", GmtOffset = 7,  Bitmask = 0b_000000000000_000000100000 },
            new() { Location = "Mumbai",           GmtOffset = 5,  Bitmask = 0b_000000000000_000010000000 }
        };
    }

    public void OnGet()
    {
        var searchOffset = 0;
        try
        {
            searchOffset = int.Parse(Request.Query["searchQuery"]!);
        }
        catch (ArgumentNullException ae)
        {
            _logger.LogWarning("Cannot search for null query");
            return;
        }
        if (searchOffset is < -12 or > 12) return;
        var searchMask = (uint) 1 << (-1 * (searchOffset + 12) + 24);
        Console.WriteLine($"searchQuery {searchOffset}");
        SearchResults = TimeZoneLocations.FindAll(tzl => (tzl.Bitmask & searchMask) > 0);
    }
}