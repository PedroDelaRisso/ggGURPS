using Microsoft.AspNetCore.Mvc;
using ggGURPS.Models.GameMasters;
using ggGURPS.DTOs.GameMasters;
using System.Threading.Tasks;
using System;

namespace ggGURPS.Controllers.GameMasters
{
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
    }

}