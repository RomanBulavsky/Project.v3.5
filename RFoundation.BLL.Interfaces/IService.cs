using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RFoundation.BLL.Interfaces
{
    //TODO: How many services do I need? and why
    public interface IService<TEntity> where TEntity : IBllEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);//TODO: Login or Email for UserService
        TEntity GetByPredicate(Expression<Func<TEntity, bool>> f); //TODO: Do we need this?
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
        void Update(int id);
    }
}
