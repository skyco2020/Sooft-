using DataModal.DBClass;
using DataModal.GenericRepository;
using DataModal.Repositories.Interface;
using DataModal.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModal.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Member
        private SooftDbContext context = null;
        private bool disposed = false;
        #endregion

        #region Constructor
        public UnitOfWork()
        {
            context = new SooftDbContext();
        }

        public SooftDbContext GetNewContext()
        {
            return new SooftDbContext();
        }

        public SooftRepository<T> getRepository<T>() where T : class
        {
            return new SooftRepository<T>(context);
        }

        #endregion

        #region Commit
        public void Commit()
        {
            context.SaveChanges();
        }
        #endregion

        #region Dispose
        protected virtual void Dispose(bool disposed)
        {
            if (!this.disposed)
            {
                if (disposed)
                {
                    context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Relation Repository

        #region Members 
        private IGenderRepository _GenderRepository;
        private ISingerGenderRepository _SingerGenderRepository;
        private ISingerRepository _SingerRepository;
        private IUserRepository _UserRepository;
        private ISongRepository _SongRepository;

        #endregion


        #region Properties

        public ISingerGenderRepository SingerGenderRepository
        {
            get
            {
                if (_SingerGenderRepository == null)
                {
                    return _SingerGenderRepository = new SingerGenderRepository(context);
                }
                return _SingerGenderRepository;
            }

            set
            {
                _SingerGenderRepository = value;
            }
        }

        public IGenderRepository GenderRepository
        {
            get
            {
                if (_GenderRepository == null)
                {
                    return _GenderRepository = new GenderRepository(context);
                }
                return _GenderRepository;
            }

            set
            {
                _GenderRepository = value;
            }
        }

        public ISingerRepository SingerRepository
        {
            get
            {
                if (_SingerRepository == null)
                {
                    return _SingerRepository = new SingerRepository(context);
                }
                return _SingerRepository;
            }

            set
            {
                _SingerRepository = value;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_UserRepository == null)
                {
                    return _UserRepository = new UserRepository(context);
                }
                return _UserRepository;
            }

            set
            {
                _UserRepository = value;
            }
        }

        public ISongRepository SongRepository
        {
            get
            {
                if (_SongRepository == null)
                {
                    return _SongRepository = new SongRepository(context);
                }
                return _SongRepository;
            }

            set
            {
                _SongRepository = value;
            }
        }
        #endregion

        #endregion
    }
}
