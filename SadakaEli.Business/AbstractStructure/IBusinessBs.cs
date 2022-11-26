using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InfraStructure.Domain;

namespace SadakaEli.Business.AbstractStructure
{
    public interface IBusinessBs<TEntity> where TEntity : BaseDomain, new()
    {
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        List<TEntity> GetAllActive(Expression<Func<TEntity, bool>> filter = null);
        TEntity GetById(int id);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        int Delete(TEntity entity);
        void Delete(int id);
    }
}
