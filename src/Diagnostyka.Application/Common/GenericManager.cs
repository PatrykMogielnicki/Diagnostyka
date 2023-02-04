using Diagnostyka.Application.Common.Interfaces;

namespace Diagnostyka.Application.Common
{
    public class GenericManager<T> : IGenericManager<T> where T : class
    {
        public IDiagnostykaDbContext Context { get; private set; }
        public GenericManager(IDiagnostykaDbContext context)
        {
            Context = context;
        }
        public T Add(T entity)
        {
            Context.Set<T>().Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            Context.Set<T>().Update(entity);
            return entity;
        }

        public T Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            return entity;
        }

        public T? GetById(object key)
        {
            return Context.Set<T>().Find(key);
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }
    }
}
