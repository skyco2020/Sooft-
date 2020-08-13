using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataModal.GenericRepository
{
    public interface ISoofGenericRepository<TEntity> where TEntity : class
    {
        #region Create
        void Create(TEntity entity);
        #endregion

        #region ReadOne
        TEntity GetById(Int64 ID);
        TEntity GetOneByFilters(Expression<Func<TEntity, bool>> where, params string[] include);
        #endregion

        #region ReadAll
        IQueryable<TEntity> GetAllByFilters(Expression<Func<TEntity, bool>> where, params string[] include);
        #endregion
    }
}
