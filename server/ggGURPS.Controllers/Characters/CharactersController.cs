using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class CharactersController : ControllerBase
{
    private readonly ICharactersService _service;

    public CharactersController(ICharactersService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostCharacterDTO characterDTO)
    {
        await _service.Create(characterDTO);

        return Ok("Character created successfully!");
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        return Ok(await _service.GetById(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] PutCharacterDTO characterDTO)
    {
        await _service.Update(id, characterDTO);
        return Ok("Character updated succcessfully.");
    }

    [HttpPut("{id}/LevelUp/{attribute}")]
    public async Task<IActionResult> LevelUp(long id, Attributes attribute, int levels)
    {
        await _service.LevelUp(id, attribute, levels);
        return Ok("Attribute updated successfully.");
    }

    [HttpPut("{id}/Points")]
    public async Task<IActionResult> AddPoints(long id, int points)
    {
        await _service.AddPoints(id, points);
        return Ok("Points added succesfully!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _service.Delete(id);
        return Ok("Character deleted successfully.");
    }
}