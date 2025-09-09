public interface IMaintanable<T>
{
    Task<dynamic> Create(T obj);
    Task<T> Read(int id);
    Task<dynamic> Update(T id);
    Task<bool> Delete(int id);
}