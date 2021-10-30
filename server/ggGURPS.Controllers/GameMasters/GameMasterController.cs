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
            try
            {
                var gameMaster = await _gameMasterService.GetById(id);
                if (gameMaster == null)
                    return NotFound("No Game Master matches the provided ID");
                var getGameMasterByIdDTO = new GetGameMasterByIdDTO(
                    gameMaster.Id,
                    gameMaster.Name
                );

                return Ok(getGameMasterByIdDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostGameMasterDTO gameMasterDTO)
        {
            try
            {
                await _gameMasterService.Create(gameMasterDTO);

                return Ok("Game Master saved successfully.");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}