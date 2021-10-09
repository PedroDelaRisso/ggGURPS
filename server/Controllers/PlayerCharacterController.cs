using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PlayerCharacterController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PlayerCharacterController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<PlayerCharacter>> Get()
    {
        return await _context.PlayerCharacters.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlayerCharacter>> Get(long id)
    {
        return Ok(await _context.PlayerCharacters.FirstOrDefaultAsync(pc => pc.Id == id));
    }

    [HttpPost]
    public async Task<ActionResult<PlayerCharacter>> Post([FromBody] PlayerCharacter playerCharacter)
    {
        _context.PlayerCharacters.Add(playerCharacter);
        await _context.SaveChangesAsync();

        return Ok(playerCharacter);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PlayerCharacter>> Put([FromBody] PlayerCharacter playerCharacter, long id)
    {
        playerCharacter.Id = id;
        _context.PlayerCharacters.Update(playerCharacter);
        await _context.SaveChangesAsync();
        return Ok(playerCharacter);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PlayerCharacter>> Delete(long id)
    {
        _context.PlayerCharacters.Remove(await _context.PlayerCharacters.FirstOrDefaultAsync(pc => pc.Id == id));
        await _context.SaveChangesAsync();

        return Ok();
    }
}