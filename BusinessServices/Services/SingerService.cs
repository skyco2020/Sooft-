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
    public class SingerService : ISingerService
    {
        #region Dependency injection
        private readonly UnitOfWork _unitOfWork;
        public SingerService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        public long Create(SingerBE Be)
        {
            try
            {
                Singers entity = Patterns.Singleton.FactorySinger.GetInstance().CreateEntity(Be);
                List<Singers> verify = _unitOfWork.SingerRepository.GetAllByFilters(u => u.Name.ToLower() == entity.Name.ToLower()).ToList();
                if (verify.Count > 0)
                    throw new Exception(System.Net.HttpStatusCode.BadRequest.ToString());

                _unitOfWork.SingerRepository.Create(entity);
                _unitOfWork.Commit();
                return (Int64)System.Net.HttpStatusCode.Created;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long CreateGenderSong(SingerGenderBE Be)
        {
            SingerGenders entity = Patterns.Singleton.FactorySingerGender.GetInstance().CreateEntity(Be);
            List<SingerGenders> verify = _unitOfWork.SingerGenderRepository.GetAllByFilters(u => u.idSinger == entity.idSinger && u.idGender == entity.idGender).ToList();
            if (verify.Count > 0)
                throw new Exception(System.Net.HttpStatusCode.BadRequest.ToString());

            _unitOfWork.SingerGenderRepository.Create(entity);
            _unitOfWork.Commit();
            return (Int64)System.Net.HttpStatusCode.Created;
        }

        public List<SingerBE> GetAll(int state, string Search)
        {
            Expression<Func<DataModal.DBClass.Singers, Boolean>> predicate = u => u.state == (byte)state && (u.Name == Search || Search == "");
            IQueryable<DataModal.DBClass.Singers> entities = _unitOfWork.SingerRepository.GetAllByFilters(predicate, new string[] { "SingerGenders", "SingerGenders.Singers" });
                      
            List<SingerBE> listbe = new List<SingerBE>();
            foreach (Singers item in entities)
            {
                listbe.Add(Patterns.Singleton.FactorySinger.GetInstance().CreateBusiness(item));
            }
            return listbe;
        }

        public SingerBE GetById(long Id)
        {
            Expression<Func<DataModal.DBClass.Singers, Boolean>> predicate = u => u.idSinger == Id && u.state == (byte)StateEnum.Activated;
            Singers entity = _unitOfWork.SingerRepository.GetOneByFilters(predicate, new string[] { "SingerGenders", "SingerGenders.Singers" });
            SingerBE be = null;
            if (entity != null)
            {
                be = new SingerBE();
                be = Patterns.Singleton.FactorySinger.GetInstance().CreateBusiness(entity);
            }
            return be;
        }
    }
}
