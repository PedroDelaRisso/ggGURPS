using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class CharacterManager : ICharacterManager
{
    private readonly ApplicationDbContext _context;

    public CharacterManager(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Character> Create(Character character)
    {
        // character.Inventory = null;
        // character.Skills = null;
        // character.Spells = null;
        _context.Characters.Add(character);
        await _context.SaveChangesAsync();
        return character;
    }

    public async Task<Character>  GetById(int id)
    {
        return await _context.Characters.Where(c => c.Id == id)
            .Include(c => c.Skills)
            .Include(c => c.Items)
            .Include(c => c.CustomRolls)
            .FirstOrDefaultAsync();
    }

    public async Task<Item> AddItem(int characterId, Item item)
    {
        var character = await _context.Characters.Where(c => c.Id == characterId).Include(i => i.Items).FirstOrDefaultAsync();
        if (character is null)
            throw new System.Exception("Character not found.");
        character.Items.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<Skill> AddSkill(int characterId, Skill skill)
    {
        var character = await _context.Characters.Where(c => c.Id == characterId).Include(c => c.Skills).FirstOrDefaultAsync();
        if (character is null)
            throw new System.Exception("Character not found.");
        character.Skills.Add(skill);
        _context.Characters.Update(character);
        await _context.SaveChangesAsync();
        return skill;
    }

    public async Task<CustomRoll> AddCustomRoll(int characterId, CustomRoll customRoll)
    {
        var character = await _context.Characters.Where(c => c.Id == characterId).Include(c => c.Skills).FirstOrDefaultAsync();
        if (character is null)
            throw new System.Exception("Character not found.");
        character.CustomRolls.Add(customRoll);
        _context.Characters.Update(character);
        await _context.SaveChangesAsync();
        return customRoll;
    }
}