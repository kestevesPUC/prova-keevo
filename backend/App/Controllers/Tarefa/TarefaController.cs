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

    [HttpGet("{id}")]
    public async Task<dynamic?> Read(int id)
    {
        Tarefa? tarefa = await this._tarefaRepo.Read(id);

        if (tarefa != null)
        {
            return new
            {
                success = true,
                status = 200,
                data = tarefa
            };
        }
        return new
        {
            success = false,
            status = 404,
            message = "Tarefa não encontrada."
        };
    }
    
    [HttpGet]
    public async Task<dynamic> ReadAll()
    {
        List<Tarefa> tarefas = await this._tarefaRepo.ReadAll();

        if (tarefas != null)
        {
            return new
            {
                success = true,
                status = 200,
                data = tarefas
            };
        }
        return new
        {
            success = false,
            status = 404,
            message = "Não foi possível recuperar as tarefas."
        };
    }

    [HttpPost]
    public async Task<dynamic> Create(Tarefa tarefa)
    {
        try
        {
            tarefa.dataCriacao = Util.DateTimeNow();
            bool success = await this._tarefaRepo.Create(tarefa);

            if (success)
            {
                return new
                {
                    success = true,
                    status = 200,
                    message = "Tarefa criada com sucesso!"
                };
            }

            return new
            {
                success = false,
                status = 400,
                message = "Erro ao criar tarefa."
            };
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            return new
            {
                success = false,
                status = 500,
                message = "Houve um erro interno no servidor. Tente novamente mais tarde."
            };
        }
    }

    [HttpDelete("{id}")]
    public async Task<dynamic> Delete(int id)
    {
        try
        {
            Tarefa tarefa = await this._tarefaRepo.Read(id);

            if (tarefa == null)
            {
                return new
                {
                    success = false,
                    status = 404,
                    message = "Tarefa não encontrada."
                };
            }

            bool success = await this._tarefaRepo.Delete(tarefa);

            if (success)
            {
                return new
                {
                    success = true,
                    status = 200,
                    message = "Tarefa deletada com sucesso."
                };
            }

            return new
            {
                success = false,
                status = 400,
                message = "Não foi possível deletar a tarefa."
            };
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            return new
            {
                success = false,
                status = 500,
                message = "Houve um erro interno no servidor. Tente novamente mais tarde."
            };
        }
    }

    [HttpPut("{id}")]
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
            tarefa.statusId = status_id;
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


