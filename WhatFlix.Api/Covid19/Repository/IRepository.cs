using System.Collections.Generic;
using System.Threading.Tasks;
using Covid19.Domain;

namespace Covid19.Repository
{
    public interface IRepository<T> where T : class
    { 
        Task<IEnumerable<T>> GetAll();
        void Add(T obj);
    }
}