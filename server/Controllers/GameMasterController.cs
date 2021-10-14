using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

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

        if (!gameMasters.Any())
            return NotFound("There are no Game Masters");

        var gameMastersOutputDTO = new List<GameMasterOutputGetAllDTO>();
        gameMastersOutputDTO.AddRange(gameMasters.Select(gm => new GameMasterOutputGetAllDTO(gm.Id, gm.Name)).ToList());
        return Ok(gameMastersOutputDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GameMasterOutputGetByIdDTO>> Get(long id)
    {
        try
        {
            var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(gm => gm.Id == id);

            if (gameMaster == null)
                return NotFound("No Game Master matches the provided ID.");

            var playerDTOList = new List<CharacterOutputGetByGameMasterIdDTO>();
            var playerList = await _context.Characters.Where(pc => pc.GameMasterId == id).ToListAsync();
            playerDTOList.AddRange(playerList.Select(pc => new CharacterOutputGetByGameMasterIdDTO(pc.Id, pc.CharacterName)).ToList());

            var gameMasterDTO = new GameMasterOutputGetByIdDTO(gameMaster.Id, gameMaster.Name, playerDTOList);

            return Ok(gameMasterDTO);
        } catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<GameMasterOutputPostDTO>> Post([FromBody] GameMasterInputDTO gameMasterDTO)
    {
        try
        {
            var gameMaster = new GameMaster(gameMasterDTO.Name);
            _context.GameMasters.Add(gameMaster);
            await _context.SaveChangesAsync();

            var gameMasterOutputDTO = new GameMasterOutputPostDTO(gameMaster.Id, gameMaster.Name);

            return Ok(gameMasterOutputDTO);
        } catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<GameMasterOutputPutDTO>> Put(long id, [FromBody] GameMasterInputDTO gameMasterDTO)
    {
        try
        {
            var gmSrch = await _context.GameMasters.FirstOrDefaultAsync(gm => gm.Id == id);
            if (gmSrch == null)
                return NotFound("No Game Master matches the provided ID.");
            var gameMaster = new GameMaster(gameMasterDTO.Name);
            gameMaster.Id = id;
            _context.GameMasters.Update(gameMaster);
            await _context.SaveChangesAsync();

            var gameMasterOutputDTO = new GameMasterOutputPutDTO(id, gameMasterDTO.Name);
            return Ok(gameMasterOutputDTO);

        } catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<GameMasterOutputDeleteDTO>> Delete(long id)
    {
        var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(gameMaster => gameMaster.Id == id);
        if (gameMaster == null)
            return NotFound("No Game Master matches the provided ID.");
        var gameMasterDTO = new GameMasterOutputDeleteDTO(gameMaster.Id, gameMaster.Name);
        _context.GameMasters.Remove(gameMaster);
        await _context.SaveChangesAsync();

        return Ok(gameMasterDTO);
    }
}