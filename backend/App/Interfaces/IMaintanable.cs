public interface IMaintanable<T>
{
    Task<bool> Create(T obj);
    Task<T> Read(int id);
    Task<bool> Update(T obj);
    Task<bool> Delete(T obj);
}