﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace Insureme.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        long Id { get; }
        long Instances { get; }
        IUnitOfWork UnitOfWork { get; }
        IDataContext DbContext { get; }

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}