using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using server.Models;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ItemController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<Item>> Get()
    {
        return await _context.Items.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> Get(long id)
    {
        return Ok(await _context.Items.FirstOrDefaultAsync(item => item.Id == id));
    }

    [HttpPost]
    public async Task<ActionResult<Item>> Post([FromBody] Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();

        return Ok(item);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Item>> Put([FromBody] Item item, long id)
    {
        item.Id = id;
        _context.Items.Update(item);
        await _context.SaveChangesAsync();
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Item>> Delete(long id)
    {
        _context.Items.Remove(await _context.Items.FirstOrDefaultAsync(item => item.Id == id));
        await _context.SaveChangesAsync();

        return Ok();
    }
}