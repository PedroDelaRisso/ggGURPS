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
    public async Task<ActionResult<List<PlayerCharacterOutputGetAllDTO>>> Get()
    {
        var playerCharacters = await _context.PlayerCharacters.ToListAsync();
        var playerCharactersDTO = new List<PlayerCharacterOutputGetAllDTO>();
        playerCharactersDTO.AddRange(playerCharacters.Select(pc => new PlayerCharacterOutputGetAllDTO(pc.Id, pc.CharacterName, pc.GameMasterId)).ToList());
        return Ok(playerCharactersDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlayerCharacterOutputGetByIdDTO>> Get(long id)
    {
        var playerCharacter = await _context.PlayerCharacters.FirstOrDefaultAsync(pc => pc.Id == id);

        if (playerCharacter == null)
            return NotFound("No Player Character matches the provided ID.");

        var playerCharacterDTO = new PlayerCharacterOutputGetByIdDTO(playerCharacter.Id,
                                                                    playerCharacter.CharacterName,
                                                                    playerCharacter.Strength,
                                                                    playerCharacter.Dexterity,
                                                                    playerCharacter.Inteligence,
                                                                    playerCharacter.Health,
                                                                    playerCharacter.FatiguePoints,
                                                                    playerCharacter.HitPoints,
                                                                    playerCharacter.GameMasterId);
        var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(gm => gm.Id == playerCharacterDTO.GameMasterId);
        playerCharacterDTO.GameMasterName = gameMaster.Name;
        return Ok(playerCharacterDTO);
    }

    [HttpPost]
    public async Task<ActionResult<PlayerCharacterOutputPostDTO>> Post([FromBody] PlayerCharacterInputDTO playerCharacterDTO)
    {
        var playerCharacter = new PlayerCharacter(0,
                                                    playerCharacterDTO.CharacterName,
                                                    playerCharacterDTO.Strength,
                                                    playerCharacterDTO.Dexterity,
                                                    playerCharacterDTO.Inteligence,
                                                    playerCharacterDTO.Health,
                                                    playerCharacterDTO.FatiguePoints,
                                                    playerCharacterDTO.HitPoints,
                                                    playerCharacterDTO.GameMasterId);

        var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(gm => gm.Id == playerCharacter.GameMasterId);

        if (gameMaster == null) return Conflict("ERROR 409! No Game Master found with the provided ID!");

        _context.PlayerCharacters.Add(playerCharacter);
        await _context.SaveChangesAsync();

        var playerCharacterOutputDTO = new PlayerCharacterOutputPostDTO(playerCharacter.Id, playerCharacter.CharacterName);

        return Ok(playerCharacterOutputDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PlayerCharacterOutputPutDTO>> Put([FromBody] PlayerCharacterInputDTO playerCharacterDTO, long id)
    {
        var playerCharacter = new PlayerCharacter(id,
                                                playerCharacterDTO.CharacterName,
                                                playerCharacterDTO.Strength,
                                                playerCharacterDTO.Dexterity,
                                                playerCharacterDTO.Inteligence,
                                                playerCharacterDTO.Health,
                                                playerCharacterDTO.FatiguePoints,
                                                playerCharacterDTO.HitPoints,
                                                playerCharacterDTO.GameMasterId);

        _context.PlayerCharacters.Update(playerCharacter);
        await _context.SaveChangesAsync();

        var playerCharacterOutputDTO = new PlayerCharacterOutputPutDTO(id, playerCharacterDTO.CharacterName, playerCharacter.GameMasterId);
        return Ok(playerCharacterOutputDTO);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PlayerCharacter>> Delete(long id)
    {
        var playerCharacter = await _context.PlayerCharacters.FirstOrDefaultAsync(pc => pc.Id == id);

        if(playerCharacter == null)
            return NotFound("No Player Character matches the provided ID.");

        var playerCharacterDTO = new PlayerCharacterOutputDeleteDTO(playerCharacter.Id, playerCharacter.CharacterName);
        _context.PlayerCharacters.Remove(playerCharacter);
        await _context.SaveChangesAsync();

        return Ok();
    }
}