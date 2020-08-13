using DataModal.DBClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataModal.GenericRepository
{
    public class SooftRepository<TEntity> where TEntity : class
    {
        #region Member
        internal SooftDbContext dbcontext;
        internal DbSet<TEntity> dbSet;
        #endregion

        #region Contructor
        public SooftRepository(SooftDbContext context)
        {
            this.dbcontext = context;
            this.dbSet = context.Set<TEntity>();
        }
        #endregion

        #region CUD
        public virtual void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }    


        #endregion

        #region ReadOne
        public virtual TEntity GetById(Int64 ID)
        {
            return dbSet.Find(ID);
        }

        public virtual TEntity GetOneByFilters(Expression<Func<TEntity, bool>> where, params string[] include)
        {
            IQueryable<TEntity> query = this.dbSet;
            if (include != null)
                query = include.Aggregate(query, (current, inc) => current.Include(inc));
            if (where != null)
                query = query.Where(where);
            return query.FirstOrDefault<TEntity>();
        }

        #endregion

        #region ReadAll

        public virtual IQueryable<TEntity> GetAllByFilters(Expression<Func<TEntity, bool>> where, params string[] include)
        {
            IQueryable<TEntity> query = this.dbSet;
            if (include != null)
                query = include.Aggregate(query, (current, inc) => current.Include(inc));
            if (where != null)
                query = query.Where(where);
            return query;
        }
        #endregion
    }
}
