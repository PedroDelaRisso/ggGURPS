using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("[controller]")]
public class RollController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RollController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("{characterId}/{rollType}/{rollTypeId}")]
    public async Task<ActionResult<Roll>> Post(long? characterId, long? gameMasterId, int? rollType, long? rollTypeId, [FromBody] Roll roll)
    {
        roll.CharacterId = characterId;
        roll.GameMasterId = gameMasterId;
        roll.RollType = (RollType)rollType;
        roll.RollIndex = 10;
        if (roll.RollType != RollType.Success)
        {
            roll.RollTypeId = rollTypeId;
            var rand = new Random();

            roll.NumberOfDice = 3;

            for (int i = 0; i < roll.NumberOfDice; i++)
                roll.Result += rand.Next(1, 7);
            roll.Result += roll.Modififer;
        }
        else 
        {
            roll.RollTypeId = 0;
            var rand = new Random();

            roll.NumberOfDice = 3;

            for (int i = 0; i < 3; i++)
                roll.Result += rand.Next(1, 7);
            roll.Result += roll.Modififer;
        }
        if (characterId > 0 && gameMasterId > 0)
        {
            return Conflict("You can not provide IDs for both Character and Game Master when rolling dice.");
        }
        if (characterId > 0)
        {
            roll.GameMasterId = null;
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == characterId);
            if (character == null) return NotFound("No Character matches the provided ID.");
            foreach (Roll r in _context.Rolls.Where(R => R.CharacterId == characterId))
            {
                r.RollIndex -= 1;
                _context.Rolls.Update(r);

                if (r.RollIndex < 1)
                {
                    _context.Rolls.Remove(r);
                }
            }
        }
        else if (gameMasterId > 0)
        {
            roll.CharacterId = null;
            var gameMaster = await _context.GameMasters.FirstOrDefaultAsync(gm => gm.Id == gameMasterId);
            if (gameMaster == null) return NotFound("No Character matches the provided ID.");
            foreach (Roll r in _context.Rolls.Where(R => R.GameMasterId == gameMasterId))
            {
                r.RollIndex -= 1;
                _context.Rolls.Update(r);

                if (r.RollIndex < 1)
                {
                    _context.Rolls.Remove(r);
                }
            }
        }

        _context.Rolls.Add(roll);
        await _context.SaveChangesAsync();

        return Ok(roll);
    }
}