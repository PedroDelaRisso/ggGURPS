using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<List<GameMasterOutputAllDTO>>> Get()
    {
        var gameMasters = await _context.GameMasters.ToListAsync();
        var gameMastersOutputAllDTO = new List<GameMasterOutputAllDTO>();
        foreach(GameMaster gm in gameMasters)
        {
            gameMastersOutputAllDTO.Add(new GameMasterOutputAllDTO(gm.Id, gm.Name));
        }
        return Ok(gameMastersOutputAllDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GameMasterOutputByIdDTO>> Get(long id)
    {
        var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(gm => gm.Id == id);
        var gameMasterDTO = new GameMasterOutputByIdDTO(gameMaster.Id, gameMaster.Name, gameMaster.PlayerCharacters);
        return Ok(gameMasterDTO);
    }

    [HttpPost]
    public async Task<ActionResult<GameMasterOutputPostDTO>> Post([FromBody] GameMasterInputDTO gameMasterDTO)
    {
        var gameMaster = new GameMaster(gameMasterDTO.Name);
        _context.GameMasters.Add(gameMaster);
        await _context.SaveChangesAsync();

        var gameMasterOutputDTO = new GameMasterOutputPostDTO(gameMaster.Id, gameMaster.Name);

        return Ok(gameMasterOutputDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<GameMasterOutputPutDTO>> Put(long id, [FromBody] GameMasterInputDTO gameMasterDTO)
    {
        var gameMaster = new GameMaster(gameMasterDTO.Name);
        gameMaster.Id = id;
        _context.GameMasters.Update(gameMaster);
        await _context.SaveChangesAsync();

        var gameMasterOutputDTO = new GameMasterOutputPutDTO(id, gameMasterDTO.Name);
        return Ok(gameMasterOutputDTO);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<GameMasterOutputDeleteDTO>> Delete(long id)
    {
        var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(gameMaster => gameMaster.Id == id)
        var gameMasterDTO = new GameMasterOutputDeleteDTO(gameMaster.Id, gameMaster.Name);
        _context.GameMasters.Remove(gameMaster);
        await _context.SaveChangesAsync();

        return Ok(gameMasterDTO);
    }
}