
using Microsoft.EntityFrameworkCore;

public class TarefaRepo : IMaintanable<Tarefa>
{
    private readonly KeevoDbContext _context;
    public TarefaRepo(KeevoDbContext contex)
    {
        this._context = contex;
    }

    public async Task<bool> Create(Tarefa tarefa)
    {
        this._context.tarefa.Add(tarefa);
        return await this._context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Tarefa tarefa)
    {
        this._context.tarefa.Remove(tarefa);
        return await this._context.SaveChangesAsync() > 0;
    }

    public async Task<Tarefa?> Read(int id)
    {
        return await this._context.tarefa
            .Include(t => t.Status)
            .Where(t => t.id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Tarefa>> ReadAll()
    {
        return await this._context.tarefa   
            .OrderBy(t => t.id)
            .OrderBy(t => t.statusId)
            .Include(t => t.Status)
            .ToListAsync();
    }

   
    public async Task<bool> Update(Tarefa tarefa)
    {
        this._context.Update(tarefa);
        return await this._context.SaveChangesAsync() > 0;
    }
}