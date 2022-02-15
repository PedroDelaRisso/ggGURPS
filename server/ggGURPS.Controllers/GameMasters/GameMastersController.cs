using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class GameMastersController : ControllerBase
{
    private readonly IGameMasterService _gameMasterService;
    public GameMastersController(IGameMasterService gameMasterService)
    {
        _gameMasterService = gameMasterService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostGameMasterDTO gameMasterDTO)
    {
        await _gameMasterService.Create(gameMasterDTO);

        return Ok("Game Master saved successfully!");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _gameMasterService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        return Ok(await _gameMasterService.GetById(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] PutGameMasterDTO gameMasterDTO)
    {
        gameMasterDTO.Id = id;
        await _gameMasterService.Update(gameMasterDTO);

        return Ok("Game Master updated successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _gameMasterService.Delete(id);

        return Ok("Game Master removed successfully.");
    }
}