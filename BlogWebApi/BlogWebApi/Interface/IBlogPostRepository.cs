using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogWebApi.Interface
{
    public interface IBlogPostRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        List<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
