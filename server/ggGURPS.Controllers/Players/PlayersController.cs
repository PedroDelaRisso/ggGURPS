using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;
    
    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostPlayerDTO playerDTO)
    {
        await _playerService.Create(playerDTO);

        return Ok("Player saved successfully!");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _playerService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        return Ok(await _playerService.GetById(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] PutPlayerDTO playerDTO)
    {
        await _playerService.Update(id, playerDTO);

        return Ok("Player updated successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _playerService.Delete(id);

        return Ok("Player removed successfully.");
    }
}