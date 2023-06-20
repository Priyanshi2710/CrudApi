using Domain;

namespace Application
{
    public interface IService<T> where T : class
    
    {       
        IEnumerable<T> GetAll();
        T Get(int Id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
       
    }
}