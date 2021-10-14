using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ItemController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Item>>> Get()
    {
        var items = await _context.Items.ToListAsync();
        return Ok(items);
    }

    [HttpPost]
    public async Task<ActionResult<Item>> Post([FromBody] Item item)
    {
        Item newItem = new Item();
        // Generic Item
        if (item.ItemType == ItemType.Item)
        {
            newItem = new Item(
                item.Id,
                item.Name,
                item.Description,
                item.ItemType,
                item.Price,
                item.Weight
            );
        }

        // Armor
        else if (item.ItemType == ItemType.Armor)
        {
            newItem = new Item(
                item.Id,
                item.Name,
                item.Description,
                item.ItemType,
                item.DamageReduction,
                item.Price,
                item.Weight
            );
        }

        // Weapon
        else if (item.ItemType == ItemType.Weapon)
        {
            newItem = new Item(
                item.Id,
                item.Name,
                item.Description,
                item.ItemType,
                item.SwingDamageDice,
                item.SwingDamageModifier,
                item.ThrustDamageDice,
                item.ThrustDamageModifier,
                item.Price,
                item.Weight
            );
        }

        // Gun
        else if (item.ItemType == ItemType.Gun)
        {
            newItem = new Item(
                item.Id,
                item.Name,
                item.Description,
                item.ItemType,
                item.Recoil,
                item.RateOfFire,
                item.DamageDice,
                item.DamageModifier,
                item.Price,
                item.Weight
            );
        }
        _context.Items.Add(newItem);
        await _context.SaveChangesAsync();
        return Ok(newItem);
    }
}