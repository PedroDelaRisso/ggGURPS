using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;

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
        try
        {
            var items = await _context.Items.ToListAsync();
            if (!items.Any())
                return NotFound("There are no saved Items.");
            return items;
        } catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Item>> Post([FromBody] Item item)
    {
        try
        {
            Item newItem = new Item(
                item.Id,
                item.Name,
                item.Description,
                item.ItemType,
                item.Price,
                item.Weight,
                item.DamageReduction,
                item.SwingDamageDice,
                item.SwingDamageModifier,
                item.ThrustDamageDice,
                item.ThrustDamageModifier,
                item.Recoil,
                item.Range,
                item.RateOfFire,
                item.DamageDice,
                item.DamageModifier
            );
            if (newItem.ItemType == ItemType.Item)
            {
                newItem.DamageReduction = -999;
                newItem.SwingDamageDice = -999;
                newItem.SwingDamageModifier = -999;
                newItem.ThrustDamageDice = -999;
                newItem.ThrustDamageModifier = -999;
                newItem.Recoil = -999;
                newItem.Range = -999;
                newItem.RateOfFire = -999;
                newItem.DamageDice = -999;
                newItem.DamageModifier = -999;
            } 
            else if (newItem.ItemType == ItemType.Armor)
            {
                newItem.SwingDamageDice = -999;
                newItem.SwingDamageModifier = -999;
                newItem.ThrustDamageDice = -999;
                newItem.ThrustDamageModifier = -999;
                newItem.Recoil = -999;
                newItem.Range = -999;
                newItem.RateOfFire = -999;
                newItem.DamageDice = -999;
                newItem.DamageModifier = -999;
            }
            else if (newItem.ItemType == ItemType.Gun)
            {
                newItem.DamageReduction = -999;
                newItem.SwingDamageDice = -999;
                newItem.SwingDamageModifier = -999;
                newItem.ThrustDamageDice = -999;
                newItem.ThrustDamageModifier = -999;
            }
            else if (newItem.ItemType == ItemType.Weapon)
            {
                newItem.DamageReduction = -999;
                newItem.Recoil = -999;
                newItem.Range = -999;
                newItem.RateOfFire = -999;
                newItem.DamageDice = -999;
                newItem.DamageModifier = -999;
            }
            
            _context.Items.Add(newItem);
            await _context.SaveChangesAsync();
            return newItem;
        } catch (Exception ex)
        {
            return Conflict(ex.Message);
        }
    }
}