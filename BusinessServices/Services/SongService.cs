using BusinessServices.Interfaces;
using BussinessEntities.BE;
using DataModal.DBClass;
using DataModal.UnitOfWork;
using Resolver.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Services
{
    public class SongService : ISongService
    {
        #region Dependency injection
        private readonly UnitOfWork _unitOfWork;
        public SongService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        public long Create(SongBE Be)
        {
            try
            {
                Songs entity = Patterns.Singleton.FactorySong.GetInstance().CreateEntity(Be);
                List<Songs> verify = _unitOfWork.SongRepository.GetAllByFilters(p => p.name.ToLower() == entity.name.ToLower()).ToList();
                if (verify.Count > 0)
                    throw new Exception(((Int32)System.Net.HttpStatusCode.BadRequest).ToString());

                _unitOfWork.SongRepository.Create(entity);
                _unitOfWork.Commit();
                return (Int64)System.Net.HttpStatusCode.Created;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SongBE> GetAll(int state, string Search)
        {
            Expression<Func<DataModal.DBClass.Songs, Boolean>> predicate = u => u.state == (byte)state && (u.name == Search || Search == "");
            IQueryable<DataModal.DBClass.Songs> entities = _unitOfWork.SongRepository.GetAllByFilters(predicate, null);

            List<SongBE> listbe = new List<SongBE>();
            foreach (Songs item in entities)
            {
                listbe.Add(Patterns.Singleton.FactorySong.GetInstance().CreateBusiness(item));
            }
            return listbe;
        }

        public SongBE GetById(long Id)
        {
            Expression<Func<DataModal.DBClass.Songs, Boolean>> predicate = u => u.idSong == Id && u.state == (byte)StateEnum.Activated;
            Songs entity = _unitOfWork.SongRepository.GetOneByFilters(predicate, null);
            SongBE be = null;
            if (entity != null)
            {
                be = new SongBE();
                be = Patterns.Singleton.FactorySong.GetInstance().CreateBusiness(entity);
            }
            return be;
        }
    }
}
