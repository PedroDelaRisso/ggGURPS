using Microsoft.AspNetCore.Mvc;
using ggGURPS.Services.GameMasters;
using ggGURPS.DTOs.GameMasters;
using System.Threading.Tasks;
using System;

namespace ggGURPS.Controllers.GameMasters
{
    [ApiController]
    [Route("[controller]")]
    public class GameMasterController : ControllerBase
    {
        private readonly IGameMasterService _gameMasterService;
        public GameMasterController(IGameMasterService gameMasterService)
        {
            _gameMasterService = gameMasterService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var gameMaster = await _gameMasterService.GetById(id);

            var getGameMasterByIdDTO = new GetGameMasterByIdDTO(
                gameMaster.Id,
                gameMaster.Name
            );

            return Ok(getGameMasterByIdDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostGameMasterDTO gameMasterDTO)
        {
            await _gameMasterService.Create(gameMasterDTO);

            return Ok("Game Master saved successfully.");
        }
    }
}