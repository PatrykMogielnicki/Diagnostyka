namespace Diagnostyka.Application.Common.Interfaces
{
    public interface IGenericManager<T> where T : class
    {
        IDiagnostykaDbContext Context { get; }
        T Add(T entity);
        T Update(T entity);
        IQueryable<T> GetAll();
        T? GetById(object key);
    }
}
