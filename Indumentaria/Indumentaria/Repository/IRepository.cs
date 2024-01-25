namespace Indumentaria.Repository
{
    public interface IRepository<TEntidad>
    {
        Task<IEnumerable<TEntidad>> Get();
        Task<TEntidad> GetById(int id);
        Task Add(TEntidad entidad);
        void Update(TEntidad entidad);
        void Delete(TEntidad entidad);
        Task Save();
    }
}
