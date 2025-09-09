
using Microsoft.EntityFrameworkCore;

public class TarefaRepo : IMaintanable<Tarefa>
{
    private readonly KeevoDbContext _context;
    public TarefaRepo(KeevoDbContext contex)
    {
        this._context = contex;
    }

    public async Task<dynamic> Create(Tarefa tarefa)
    {
        try
        {
            this._context.Add(tarefa);

            if (this._context.SaveChanges() > 0)
            {
                return new
                {
                    success = true,
                    status = 200,
                    message = "Tarefa criada com sucesso"
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

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Tarefa?> Read(int id)
    {
        return await this._context.tarefa
            .Where(t => t.id == id)
            .FirstOrDefaultAsync();
    }

   
    public async Task<bool> Update(Tarefa tarefa)
    {
        this._context.Update(tarefa);
        return await this._context.SaveChangesAsync() > 0;
    }
}