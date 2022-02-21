using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AdvantagesController : ControllerBase
{
    private readonly IAdvantageService _advantageService;

    public AdvantagesController(IAdvantageService advantageService)
    {
        _advantageService = advantageService;
    }
    [HttpPost]
    public async Task<IActionResult> CreateAdvantage([FromBody] PostAdvantageDTO advantageDTO)
    {
        await _advantageService.Create(advantageDTO);
        return Ok("Advantage created successfully!");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAdvantages()
    {
        return Ok(await _advantageService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAdvantageById(long id)
    {
        return Ok(await _advantageService.GetById(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditAdvantageById(long id, [FromBody] PutAdvantageDTO advantageDTO)
    {
        advantageDTO.Id = id;
        return Ok(await _advantageService.Update(advantageDTO));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdvantageById(long id)
    {
        await _advantageService.Delete(id);

        return Ok("Advantage deleted successfully!");
    }
}