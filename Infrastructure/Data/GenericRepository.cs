using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            //save changes here instead of unit of work to avoid conflicts
            _dbContext.SaveChanges();
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            _dbContext.SaveChanges();
        }

        public virtual T Get(Expression<Func<T, bool>> predicate, bool asNoTracking = false, string includes = null)
        {
            //no tables to join
            if (includes == null)
            {
                if (asNoTracking)
                {
                    return _dbContext.Set<T>()
                           .AsNoTracking()
                          .Where(predicate)
                          .FirstOrDefault();
                }
                else
                {
                    return _dbContext.Set<T>().Where(predicate).FirstOrDefault();
                }

            }
            else
            {
                IQueryable<T> queryable = _dbContext.Set<T>();
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
                if (asNoTracking)
                {
                    return _dbContext.Set<T>()
                           .AsNoTracking()
                          .Where(predicate)
                          .FirstOrDefault();
                }
                else
                {
                    return _dbContext.Set<T>().Where(predicate).FirstOrDefault();
                }
            }
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false, string includes = null)
        {
            //no tables to join
            if (includes == null)
            {
                if (asNoTracking)
                {
                    return await _dbContext.Set<T>()
                           .AsNoTracking()
                          .Where(predicate)
                          .FirstOrDefaultAsync();
                }
                else
                {
                    return await _dbContext.Set<T>().Where(predicate).FirstOrDefaultAsync();
                }

            }
            else
            {
                IQueryable<T> queryable = _dbContext.Set<T>();
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
                if (asNoTracking)
                {
                    return await _dbContext.Set<T>()
                           .AsNoTracking()
                          .Where(predicate)
                          .FirstOrDefaultAsync();
                }
                else
                {
                    return await _dbContext.Set<T>().Where(predicate).FirstOrDefaultAsync();
                }
            }
        }

        //allows method to be overriden by derived class
        public virtual T GetById(int id)
        {
            //connects to db and returns a set of T objects with id
            return _dbContext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> List()
        {
            return _dbContext.Set<T>().ToList().AsEnumerable();
        }

        public virtual IEnumerable<T> List(Expression<Func<T, bool>> predicate, Expression<Func<T, string>> orderBy = null, bool asNoTracking = false, string includes = null)
        {
            IQueryable<T> queryable = _dbContext.Set<T>();
            if (predicate != null && includes == null)
            {
                return _dbContext.Set<T>()
                    .Where(predicate)
                    .AsEnumerable();
            }
            else if (includes != null)
            {
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
            }

            if (predicate == null)
            {

                if (orderBy == null)
                {
                    return queryable.AsEnumerable();
                }
                else
                {
                    // return queryable.Where(predicate).ToList().AsEnumerable();
                    return queryable.OrderBy(orderBy).ToList().AsEnumerable();
                }

            }
            else
            {
                if (orderBy == null)
                {
                    return queryable.Where(predicate).ToList().AsEnumerable();
                }
                else
                {
                    // 
                    return queryable.Where(predicate).OrderBy(orderBy).ToList().AsEnumerable();
                }
            }

        }


        public virtual async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy = null, bool asNoTracking = false, string includes = null)
        {
            IQueryable<T> queryable = _dbContext.Set<T>();
            if (predicate != null && includes == null)
            {
                return _dbContext.Set<T>()
                    .Where(predicate)
                    .AsEnumerable();
            }
            else if (includes != null)
            {
                foreach (var includeProperty in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(includeProperty);
                }
            }

            if (predicate == null)
            {

                if (orderBy == null)
                {
                    return queryable.AsEnumerable();
                }
                else
                {
                    // return queryable.Where(predicate).ToList().AsEnumerable();
                    return await queryable.OrderBy(orderBy).ToListAsync();
                }

            }
            else
            {
                if (orderBy == null)
                {
                    return await queryable.Where(predicate).ToListAsync();
                }
                else
                {
                    // can't use enumerate because you don't get the list at once
                    return await queryable.Where(predicate).OrderBy(orderBy).ToListAsync();
                }
            }

        }

        public void Update(T entity)
        {
            //use State = EntityState.Modified to mark entity as modified for simultaneous updates of entity
            _dbContext.Entry(entity).State = EntityState.Modified;


            //much safer than doing it inside unit of work
            _dbContext.SaveChanges();
        }
    }
}
