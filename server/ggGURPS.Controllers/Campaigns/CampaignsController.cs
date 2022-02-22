using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CampaignsController : ControllerBase
{
    private readonly ICampaignService _campaignService;

    public CampaignsController(ICampaignService campaignService)
    {
        _campaignService = campaignService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostCampaignDTO campaignDTO)
    {
        await _campaignService.Create(campaignDTO);

        return Ok("Campaign created successfully!");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _campaignService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        return Ok(await _campaignService.GetById(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] PutCampaignDTO campaignDTO)
    {
        await _campaignService.Update(id, campaignDTO);

        return Ok("Campaign updated successfully!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _campaignService.Delete(id);

        return Ok("Campaign removed successfully.");
    }
}