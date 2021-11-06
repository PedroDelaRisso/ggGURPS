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
}