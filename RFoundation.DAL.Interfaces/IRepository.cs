using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RFoundation.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IDalEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        TEntity GetByPredicate(Expression<Func<TEntity, bool>> f);
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
        void Update(int id);
    }
}
