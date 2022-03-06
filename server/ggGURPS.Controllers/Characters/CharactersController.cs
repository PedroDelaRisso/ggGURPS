using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly ICharacterManager _characterManager;
    private readonly IMapper _mapper;

    public CharactersController(ICharacterManager characterManager,
                                IMapper mapper)
    {
        _characterManager = characterManager;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostCharacterDTO characterDTO)
    {
        var character = _mapper.Map<Character>(characterDTO);
        await _characterManager.Create(character);
        return Ok(character);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _characterManager.GetById(id));
    }

    [HttpPost("{id}/Skills")]
    public async Task<IActionResult> AddSkil(int id, [FromBody] PostSkillDTO skillDTO)
    {
        var skill = _mapper.Map<Skill>(skillDTO);
        return Ok(await _characterManager.AddSkill(id, skill));
    }

    [HttpPost("{id}/Items")]
    public async Task<IActionResult> AddItem(int id, [FromBody] PostItemDTO itemDTO)
    {
        var item = _mapper.Map<Item>(itemDTO);
        return Ok(await _characterManager.AddItem(id, item));
    }

    [HttpPost("{id}/CustomRolls")]
    public async Task<IActionResult> AddCustomRoll(int id, [FromBody] PostCustomRollDTO customRollDTO)
    {
        var customRoll = _mapper.Map<CustomRoll>(customRollDTO);

        return Ok(await _characterManager.AddCustomRoll(id, customRoll));
    }
}