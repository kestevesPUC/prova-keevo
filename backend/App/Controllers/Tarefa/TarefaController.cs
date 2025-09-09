using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;


[Route("api/tarefa")]
[ApiController]
public class TarefaController
{
    private TarefaRepo _tarefaRepo;
    private KeevoDbContext _dbContext;
    public TarefaController(KeevoDbContext dbContext)
    {
        this._dbContext = dbContext;
        this._tarefaRepo = new TarefaRepo(dbContext);
    }

    [HttpGet("read")]
    public async Task<Tarefa?> Read([FromHeader] int id)
    {
        return await this._tarefaRepo.Read(id);
    }

    [HttpPost("create")]
    public async Task<dynamic> Create(Tarefa tarefa)
    {
        tarefa.dataCriacao = Util.DateTimeNow();
        return await this._tarefaRepo.Create(tarefa);
    }

    [HttpDelete("delete")]
    public Task<dynamic> Delete(int id)
    {
        throw new NotImplementedException();
    }


    
    [HttpPut("update")]
    public async Task<dynamic> Update(int id, string? titulo = null, string? descBreve = null, string? descDetalhada = null, int status_id = 0)
    {
        Tarefa tarefa = await this._tarefaRepo.Read(id);
        tarefa.dataAtualizacao = Util.DateTimeNow();

        if (titulo != null)
        {
            tarefa.titulo = titulo;
        }

        if (descBreve != null)
        {
            tarefa.descBreve = descBreve;
        }

        if (descDetalhada != null)
        {
            tarefa.descDetalhada = descDetalhada;
        }

        if (status_id != 0)
        {
            tarefa.status_id = status_id;
        }
    
        bool result = await this._tarefaRepo.Update(tarefa);

        if (result)
        {
            return new
            {
                success = true,
                status = 200,
                message = "Tarefa atualizada com sucesso"
            };
        }

        return new
        {
            success = false,
            status = 400,
            message = "Erro ao atualizar tarefa."
        };
    }
}


