using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CharacterController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<CharacterOutputGetAllDTO>>> Get()
    {
        var Characters = await _context.Characters.ToListAsync();
        var CharactersDTO = new List<CharacterOutputGetAllDTO>();
        CharactersDTO.AddRange(Characters.Select(pc => new CharacterOutputGetAllDTO(pc.Id, pc.CharacterName, pc.GameMasterId)).ToList());
        return Ok(CharactersDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CharacterOutputGetByIdDTO>> Get(long id)
    {
        var Character = await _context.Characters.FirstOrDefaultAsync(pc => pc.Id == id);

        if (Character == null)
            return NotFound("No Player Character matches the provided ID.");

        var CharacterDTO = new CharacterOutputGetByIdDTO(Character.Id,
                                                                    Character.CharacterName,
                                                                    Character.Strength,
                                                                    Character.Dexterity,
                                                                    Character.Inteligence,
                                                                    Character.Health,
                                                                    Character.FatiguePoints,
                                                                    Character.HitPoints,
                                                                    Character.GameMasterId);
        var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(gm => gm.Id == CharacterDTO.GameMasterId);
        CharacterDTO.GameMasterName = gameMaster.Name;
        return Ok(CharacterDTO);
    }

    [HttpPost]
    public async Task<ActionResult<CharacterOutputPostDTO>> Post([FromBody] CharacterInputDTO CharacterDTO)
    {
        var Character = new Character(0,
                                                    CharacterDTO.CharacterName,
                                                    CharacterDTO.Strength,
                                                    CharacterDTO.Dexterity,
                                                    CharacterDTO.Inteligence,
                                                    CharacterDTO.Health,
                                                    CharacterDTO.FatiguePoints,
                                                    CharacterDTO.HitPoints,
                                                    CharacterDTO.GameMasterId);

        var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(gm => gm.Id == Character.GameMasterId);

        if (gameMaster == null) return Conflict("ERROR 409! No Game Master found with the provided ID!");

        _context.Characters.Add(Character);
        await _context.SaveChangesAsync();

        var CharacterOutputDTO = new CharacterOutputPostDTO(Character.Id, Character.CharacterName);

        return Ok(CharacterOutputDTO);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CharacterOutputPutDTO>> Put([FromBody] CharacterInputDTO CharacterDTO, long id)
    {
        var Character = new Character(id,
                                                CharacterDTO.CharacterName,
                                                CharacterDTO.Strength,
                                                CharacterDTO.Dexterity,
                                                CharacterDTO.Inteligence,
                                                CharacterDTO.Health,
                                                CharacterDTO.FatiguePoints,
                                                CharacterDTO.HitPoints,
                                                CharacterDTO.GameMasterId);

        _context.Characters.Update(Character);
        await _context.SaveChangesAsync();

        var CharacterOutputDTO = new CharacterOutputPutDTO(id, CharacterDTO.CharacterName, Character.GameMasterId);
        return Ok(CharacterOutputDTO);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Character>> Delete(long id)
    {
        var Character = await _context.Characters.FirstOrDefaultAsync(pc => pc.Id == id);

        if(Character == null)
            return NotFound("No Player Character matches the provided ID.");

        var CharacterDTO = new CharacterOutputDeleteDTO(Character.Id, Character.CharacterName);
        _context.Characters.Remove(Character);
        await _context.SaveChangesAsync();

        return Ok();
    }
}