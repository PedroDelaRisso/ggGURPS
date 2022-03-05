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
        return Ok(await _characterManager.Create(character));
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
}