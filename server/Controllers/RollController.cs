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
    public async Task<ActionResult<Roll>> Post(long characterId, int? rollType, long? rollTypeId, [FromBody] Roll roll)
    {
        roll.CharacterId = characterId;
        roll.RollType = (RollType)rollType;
        roll.RollIndex = 10;
        if (roll.RollType != RollType.Success)
            roll.RollTypeId = rollTypeId;
        else 
        {
            roll.RollTypeId = 0;
            var rand = new Random();

            roll.NumberOfDice = 3;

            for (int i = 0; i < 3; i++)
                roll.Result += rand.Next(1, 7);
            roll.Result += roll.Modififer;
        }
        foreach (Roll r in _context.Rolls.Where(R => R.CharacterId == characterId))
        {
            r.RollIndex -= 1;
            _context.Rolls.Update(r);

            if (r.RollIndex < 1)
            {
                _context.Rolls.Remove(r);
            }
        }
        _context.Rolls.Add(roll);
        await _context.SaveChangesAsync();

        return Ok(roll);
    }
}