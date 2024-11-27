using LibraryManagementAPI.Data;
using LibraryManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class LibraryController : ControllerBase
{
    private readonly LibraryDbContext _context;

    public LibraryController(LibraryDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetItems()
    {
        var items = await _context.LibraryItems.ToListAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItem(int id)
    {
        var item = await _context.LibraryItems.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> AddItem([FromBody] LibraryItem item)
    {
        _context.LibraryItems.Add(item);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetItem), new { id = item.ItemID }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, [FromBody] LibraryItem updatedItem)
    {
        var item = await _context.LibraryItems.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }

        item.Title = updatedItem.Title;
        item.Author = updatedItem.Author;
        item.ItemType = updatedItem.ItemType;
        item.IsBorrowed = updatedItem.IsBorrowed;
        item.Borrower = updatedItem.Borrower;
        item.BorrowedDate = updatedItem.BorrowedDate;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var item = await _context.LibraryItems.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }

        _context.LibraryItems.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
