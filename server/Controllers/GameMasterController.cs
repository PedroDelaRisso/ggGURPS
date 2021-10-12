using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
    public async Task<ActionResult<List<GameMasterOutputGetAllDTO>>> Get()
    {
        var gameMasters = await _context.GameMasters.ToListAsync();
        var gameMastersOutputDTO = new List<GameMasterOutputGetAllDTO>();
        gameMastersOutputDTO.AddRange(gameMasters.Select(gm => new GameMasterOutputGetAllDTO(gm.Id, gm.Name)).ToList());
        return Ok(gameMastersOutputDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GameMasterOutputGetByIdDTO>> Get(long id)
    {
        var playerDTOList = new List<PlayerCharacterOutputGetByGameMasterIdDTO>();
        var playerList = await _context.PlayerCharacters.Where(pc => pc.GameMasterId == id).ToListAsync();
        playerDTOList.AddRange(playerList.Select(pc => new PlayerCharacterOutputGetByGameMasterIdDTO(pc.Id, pc.CharacterName)).ToList());

        var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(gm => gm.Id == id);
        var gameMasterDTO = new GameMasterOutputGetByIdDTO(gameMaster.Id, gameMaster.Name, playerDTOList);

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
        var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(gameMaster => gameMaster.Id == id);
        var gameMasterDTO = new GameMasterOutputDeleteDTO(gameMaster.Id, gameMaster.Name);
        _context.GameMasters.Remove(gameMaster);
        await _context.SaveChangesAsync();

        return Ok(gameMasterDTO);
    }
}