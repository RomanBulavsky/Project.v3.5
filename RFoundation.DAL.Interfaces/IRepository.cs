using System;
using System.Collections.Generic;
using System.Linq.Expressions;


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
        void Update(int id);//TODO: Candidate --
    }
}
