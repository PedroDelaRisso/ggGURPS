using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class CharactersController : ControllerBase
{
    private readonly ICharacterService _characterService;

    public CharactersController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostCharacterDTO characterDTO)
    {
        await _characterService.Create(characterDTO);

        return Ok("Character created successfully!");
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _characterService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        return Ok(await _characterService.GetById(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] PutCharacterDTO characterDTO)
    {
        await _characterService.Update(id, characterDTO);
        return Ok("Character updated succcessfully.");
    }

    [HttpPut("{id}/LevelUp/{attribute}")]
    public async Task<IActionResult> LevelUp(long id, Attributes attribute, int levels)
    {
        await _characterService.LevelUp(id, attribute, levels);
        return Ok("Attribute updated successfully.");
    }

    [HttpPut("{id}/Points")]
    public async Task<IActionResult> AddPoints(long id, int points)
    {
        await _characterService.AddPoints(id, points);
        return Ok("Points added succesfully!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _characterService.Delete(id);
        return Ok("Character deleted successfully.");
    }
}