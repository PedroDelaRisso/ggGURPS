using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Models;

[ApiController]
[Route("[controller]")]
public class GameMasterController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public GameMasterController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<GameMaster>> Get()
    {
        return await _context.GameMasters.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GameMaster>> Get(long id)
    {
        return Ok(await _context.GameMasters.FirstOrDefaultAsync(gm => gm.Id == id));
    }

    [HttpPost]
    public async Task<ActionResult<GameMaster>> Post([FromBody] GameMaster gameMaster)
    {
        _context.GameMasters.Add(gameMaster);
        await _context.SaveChangesAsync();

        return Ok(gameMaster);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<GameMaster>> Put(long id, [FromBody] GameMaster gameMaster)
    {
        gameMaster.Id = id;
        _context.GameMasters.Update(gameMaster);
        await _context.SaveChangesAsync();

        return Ok(gameMaster); 
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<GameMaster>> Delete(long id)
    {
        _context.GameMasters.Remove(await _context.GameMasters.FirstOrDefaultAsync(gameMaster => gameMaster.Id == id));
        await _context.SaveChangesAsync();

        return Ok();
    }
}