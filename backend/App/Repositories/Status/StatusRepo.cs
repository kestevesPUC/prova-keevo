using Microsoft.EntityFrameworkCore;

public class StatusRepo : IMaintanable<Status>
{

    private readonly KeevoDbContext _context;
    public StatusRepo(KeevoDbContext contex)
    {
        this._context = contex;
    }
    public async Task<bool> Create(Status status)
    {
        this._context.status.Add(status);
        return await this._context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Status status)
    {
        this._context.status.Remove(status);
        return await this._context.SaveChangesAsync() > 0;
    }

    public async Task<Status> Read(int id)
    {
        return await this._context.status
            .Where(t => t.id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Status>> ReadAll()
    {
        return await this._context.status
            .OrderBy(s => s.id)
            .ToListAsync();
    }

    public async Task<bool> Update(Status status)
    {
        this._context.Update(status);
        return await this._context.SaveChangesAsync() > 0;
    }
}