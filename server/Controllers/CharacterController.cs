using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{
    public CharacterController()
    {
        
    }

    [HttpPost]
    public string Post()
    {
        return "post";
    }

    [HttpGet]
    public string Get()
    {
        return "get";
    }

    [HttpPut]
    public string Put()
    {
        return "put";
    }

    [HttpDelete]
    public string Delete()
    {
        return "delete";
    }
}