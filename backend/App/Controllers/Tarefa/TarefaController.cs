using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


[Route("api/tarefa")]
[ApiController]
public class NomeController : ControllerBase
{

    [HttpPost("tarefa")]
    public async Task<dynamic> Index([FromBody] string teste)
    {
        return teste;
    }
}


