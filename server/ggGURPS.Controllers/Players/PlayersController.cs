using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IPlayersService _service;
    
    public PlayersController(IPlayersService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostPlayerDTO playerDTO)
    {
        await _service.Create(playerDTO);

        return Ok("Player saved successfully!");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        return Ok(await _service.GetById(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] PutPlayerDTO playerDTO)
    {
        playerDTO.Id = id;
        await _service.Update(playerDTO);

        return Ok("Player updated successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _service.Delete(id);

        return Ok("Player removed successfully.");
    }
}