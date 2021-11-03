using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class GameMastersController : ControllerBase
{
    private readonly IGameMastersService _service;
    public GameMastersController(IGameMastersService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostGameMasterDTO gameMasterDTO)
    {
        await _service.Create(gameMasterDTO);

        return Ok("Game Master saved successfully!");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        return Ok(await _service.GetById(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] PutGameMasterDTO gameMasterDTO)
    {
        gameMasterDTO.Id = id;
        await _service.Update(gameMasterDTO);

        return Ok("Game Master updated successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _service.Delete(id);

        return Ok("Game Master removed successfully.");
    }
}