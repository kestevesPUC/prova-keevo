using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


[Route("api/tarefa")]
[ApiController]
public class TarefaController : IMaintanable<Tarefa>
{
    public TarefaController()
    {
        
    }
    
    [HttpGet("read")]
    public Task<Tarefa> Read(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost("create")]
    public Task<Tarefa> Create(Tarefa obj)
    {
        throw new NotImplementedException();
    }

    [HttpPost("delete")]
    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }


    
    [HttpPost("update")]
    public Task<bool> Update(Tarefa obj)
    {
        throw new NotImplementedException();
    }
}


