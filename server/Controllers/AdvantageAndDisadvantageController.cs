using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using server.Models;

[ApiController]
[Route("[controller]")]
public class AdvantageAndDisadvantageController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AdvantageAndDisadvantageController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<AdvantageAndDisadvantage>> Get()
    {
        return await _context.AdvantagesAndDisadvantages.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AdvantageAndDisadvantage>> Get(long id)
    {
        return Ok(await _context.AdvantagesAndDisadvantages.FirstOrDefaultAsync(adv => adv.Id == id));
    }

    [HttpPost]
    public async Task<ActionResult<AdvantageAndDisadvantage>> Post([FromBody] AdvantageAndDisadvantage advantageAndDisadvantage)
    {
        _context.AdvantagesAndDisadvantages.Add(advantageAndDisadvantage);
        await _context.SaveChangesAsync();

        return Ok(advantageAndDisadvantage);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AdvantageAndDisadvantage>> Put([FromBody] AdvantageAndDisadvantage advantageAndDisadvantage, long id)
    {
        advantageAndDisadvantage.Id = id;
        _context.AdvantagesAndDisadvantages.Update(advantageAndDisadvantage);
        await _context.SaveChangesAsync();
        return Ok(advantageAndDisadvantage);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<AdvantageAndDisadvantage>> Delete(long id)
    {
        _context.AdvantagesAndDisadvantages.Remove(await _context.AdvantagesAndDisadvantages.FirstOrDefaultAsync(adv => adv.Id == id));
        await _context.SaveChangesAsync();

        return Ok();
    }
}