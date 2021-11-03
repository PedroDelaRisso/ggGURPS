using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class CampaignsController : ControllerBase
{
    private readonly ICampaignsService _service;

    public CampaignsController(ICampaignsService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostCampaignDTO campaignDTO)
    {
        await _service.Create(campaignDTO);

        return Ok("Campaign created successfully!");
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
    public async Task<IActionResult> Put(long id, [FromBody] PutCampaignDTO campaignDTO)
    {
        await _service.Update(id, campaignDTO);

        return Ok("Campaign updated successfully!");
    }
}