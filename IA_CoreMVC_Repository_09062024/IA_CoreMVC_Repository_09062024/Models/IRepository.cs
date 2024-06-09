namespace IA_CoreMVC_Repository_09062024.Models
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);

        IEnumerable<T> GetAll();

        void Save();
    }
}
