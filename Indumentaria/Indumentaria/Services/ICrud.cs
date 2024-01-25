namespace Indumentaria.Services
{
    public interface ICrud<T, TI, TU>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(TI insertDTO);
        Task<T> Update(int id, TU updateDTO);
        Task<T> Delete(int id);
    }
}
