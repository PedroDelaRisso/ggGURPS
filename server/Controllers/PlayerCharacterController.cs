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
    public async Task<ActionResult<List<PlayerCharacterOutputAllDTO>>> Get()
    {
        var playerCharacters = await _context.PlayerCharacters.ToListAsync();
        var playerCharactersDTO = new List<PlayerCharacterOutputAllDTO>();
        foreach(PlayerCharacter pc in playerCharacters)
        {
            playerCharactersDTO.Add(new PlayerCharacterOutputAllDTO(pc.Id, pc.CharacterName, pc.GameMasterId));
        }
        return Ok(playerCharactersDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlayerCharacterOutputByIdDTO>> Get(long id)
    {
        var playerCharacter = await _context.PlayerCharacters.FirstOrDefaultAsync(pc => pc.Id == id);
        var playerCharacterDTO = new PlayerCharacterOutputByIdDTO(playerCharacter.Id,
                                                                    playerCharacter.CharacterName,
                                                                    playerCharacter.Strength,
                                                                    playerCharacter.Dexterity,
                                                                    playerCharacter.Inteligence,
                                                                    playerCharacter.Health,
                                                                    playerCharacter.FatiguePoints,
                                                                    playerCharacter.HitPoints,
                                                                    playerCharacter.GameMasterId);

        return Ok(playerCharacterDTO);
    }

    [HttpPost]
    public async Task<ActionResult<PlayerCharacterOutputPostDTO>> Post([FromBody] PlayerCharacterInputDTO playerCharacterDTO)
    {
        var playerCharacter = new PlayerCharacter(playerCharacterDTO.Id,
                                                    playerCharacterDTO.CharacterName,
                                                    playerCharacterDTO.Strength,
                                                    playerCharacterDTO.Dexterity,
                                                    playerCharacterDTO.Inteligence,
                                                    playerCharacterDTO.Health,
                                                    playerCharacterDTO.FatiguePoints,
                                                    playerCharacterDTO.HitPoints,
                                                    playerCharacterDTO.GameMasterId);
        _context.PlayerCharacters.Add(playerCharacter);
        await _context.SaveChangesAsync();

        var playerCharacterOutputDTO = new PlayerCharacterOutputPostDTO(playerCharacter.Id, playerCharacter.CharacterName);

        return Ok(playerCharacterOutputDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PlayerCharacterOutputPutDTO>> Put([FromBody] PlayerCharacterInputDTO playerCharacterDTO, long id)
    {
        var playerCharacter = new PlayerCharacter(playerCharacterDTO.Id,
                                                    playerCharacterDTO.CharacterName,
                                                    playerCharacterDTO.Strength,
                                                    playerCharacterDTO.Dexterity,
                                                    playerCharacterDTO.Inteligence,
                                                    playerCharacterDTO.Health,
                                                    playerCharacterDTO.FatiguePoints,
                                                    playerCharacterDTO.HitPoints,
                                                    playerCharacterDTO.GameMasterId);
        playerCharacter.Id = id;
        _context.PlayerCharacters.Update(playerCharacter);
        await _context.SaveChangesAsync();

        var playerCharacterOutputDTO = new PlayerCharacterOutputPutDTO(id, playerCharacterDTO.CharacterName, playerCharacter.GameMasterId);
        return Ok(playerCharacterOutputDTO);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PlayerCharacter>> Delete(long id)
    {
        var playerCharacter = await _context.PlayerCharacters.FirstOrDefaultAsync(pc => pc.Id == id);
        var playerCharacterDTO = new PlayerCharacterOutputDeleteDTO(playerCharacter.Id, playerCharacter.CharacterName);
        _context.PlayerCharacters.Remove(playerCharacter);
        await _context.SaveChangesAsync();

        return Ok();
    }
}