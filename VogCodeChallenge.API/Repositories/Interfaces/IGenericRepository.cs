using System.Collections.Generic;

namespace VogCodeChallenge.API.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public IList<T> ListAll();
        public int Add(T entityObj);
        public T GetById(int id);
    }
}
