using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using server.Models;

[ApiController]
[Route("[controller]")]
public class SkillController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SkillController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<Skill>> Get()
    {
        return await _context.Skills.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Skill>> Get(long id)
    {
        return Ok(await _context.Skills.FirstOrDefaultAsync(skill => skill.Id == id));
    }

    [HttpPost]
    public async Task<ActionResult<Skill>> Post([FromBody] Skill skill)
    {
        _context.Skills.Add(skill);
        await _context.SaveChangesAsync();

        return Ok(skill);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Skill>> Put([FromBody] Skill skill, long id)
    {
        skill.Id = id;
        _context.Skills.Update(skill);
        await _context.SaveChangesAsync();
        return Ok(skill);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Skill>> Delete(long id)
    {
        _context.Skills.Remove(await _context.Skills.FirstOrDefaultAsync(skill => skill.Id == id));
        await _context.SaveChangesAsync();

        return Ok();
    }
}