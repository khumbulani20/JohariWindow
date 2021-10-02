using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //get object by it's id
        T GetById(int id);

        //uses link expression
        //bool tells you if there is anything is returned
        T Get(Expression<Func<T, bool>> predicate, bool asNoTracking = false, string includes = null);


        Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false, string includes = null);
        //returns an enumerable list of results
        IEnumerable<T> List();

        IEnumerable<T> List(Expression<Func<T, bool>> predicate, Expression<Func<T, string>> orderBy = null, bool asNoTracking = false, string includes = null);

        //same as the above method but difference is asynchronous and returns a Task
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy = null, bool asNoTracking = false, string includes = null);
        void Add(T entity);

        //delete single record
        void Delete(T entity);

        //delete multiple objects
        void Delete(IEnumerable<T> entities);

        //update all changes in an object
        void Update(T entity);
    }
}
