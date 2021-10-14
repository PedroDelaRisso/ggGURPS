using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;

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
        try
        {
            var characters = await _context.Characters.ToListAsync();
            var characterDTOList = new List<CharacterOutputGetAllDTO>();
            characterDTOList.AddRange(characters.Select(chrctr => new CharacterOutputGetAllDTO(chrctr.Id, chrctr.CharacterName, chrctr.GameMasterId)).ToList());

            if (!characters.Any()) return NotFound("There are no saved Characters.");

            return characterDTOList;
        } catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CharacterOutputGetByIdDTO>> Get(long id)
    {
        var Character = await _context.Characters.FirstOrDefaultAsync(chrctr => chrctr.Id == id);

        if (Character == null)
            return NotFound("No Character matches the provided ID.");

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
    public async Task<ActionResult<CharacterOutputPostDTO>> Post([FromBody] CharacterInputDTO characterDTO)
    {
        try
        {
            var character = new Character(0,
                                            characterDTO.CharacterName,
                                            characterDTO.Strength,
                                            characterDTO.Dexterity,
                                            characterDTO.Inteligence,
                                            characterDTO.Health,
                                            characterDTO.FatiguePoints,
                                            characterDTO.HitPoints,
                                            characterDTO.GameMasterId);

            var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(gm => gm.Id == character.GameMasterId);

            if (gameMaster == null) return Conflict("ERROR 409! No Game Master found with the provided ID!");

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            var characterOutputDTO = new CharacterOutputPostDTO(character.Id, character.CharacterName);

            return Ok(characterOutputDTO);
        } catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
        
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CharacterOutputPutDTO>> Put([FromBody] CharacterInputDTO characterDTO, long id)
    {
        try
        {
            var chrSrch = await _context.Characters.FirstOrDefaultAsync(chrctr => chrctr.Id == id);
            if (chrSrch == null)
                return NotFound("No Character matches the provided ID.");
            var character = new Character(id,
                                            characterDTO.CharacterName,
                                            characterDTO.Strength,
                                            characterDTO.Dexterity,
                                            characterDTO.Inteligence,
                                            characterDTO.Health,
                                            characterDTO.FatiguePoints,
                                            characterDTO.HitPoints,
                                            characterDTO.GameMasterId);

            _context.Characters.Update(character);
            await _context.SaveChangesAsync();

            var characterOutputDTO = new CharacterOutputPutDTO(id, characterDTO.CharacterName, character.GameMasterId);
            return Ok(characterOutputDTO);
        } catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Character>> Delete(long id)
    {
        try
        {
            var character = await _context.Characters.FirstOrDefaultAsync(chrctr => chrctr.Id == id);

            if(character == null)
                return NotFound("No Character matches the provided ID.");

            var characterDTO = new CharacterOutputDeleteDTO(character.Id, character.CharacterName);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return Ok("Character deleted successfully.");

        } catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }
}