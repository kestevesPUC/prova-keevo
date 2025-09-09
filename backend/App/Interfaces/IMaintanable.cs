public interface IMaintanable<T>
{
    Task<T> Create(T obj);
    Task<T> Read(int id);
    Task<bool> Update(T obj);
    Task<bool> Delete(int id);
}