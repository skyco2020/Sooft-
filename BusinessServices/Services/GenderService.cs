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
    public class GenderService : IGenderService
    {
        #region Dependency injection
        private readonly UnitOfWork _unitOfWork;
        public GenderService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        public long Create(GenderBE Be)
        {
            try
            {
                Genders entity = Patterns.Singleton.FactoryGender.GetInstance().CreateEntity(Be);
                List<Genders> verify = _unitOfWork.GenderRepository.GetAllByFilters(p => p.name.ToLower() == entity.name.ToLower()).ToList();
                if (verify.Count > 0)
                    throw new Exception("Ya existe un usuario con ese nombre");

                _unitOfWork.GenderRepository.Create(entity);
                _unitOfWork.Commit();
                return (Int64)System.Net.HttpStatusCode.Created;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GenderBE> GetAll(int state, string Search)
        {
            Expression<Func<DataModal.DBClass.Genders, Boolean>> predicate = u => u.state == (byte)state && (u.name == Search || Search == "");
            IQueryable<DataModal.DBClass.Genders> entities = _unitOfWork.GenderRepository.GetAllByFilters(predicate, new string[] { "SingerGenders", "SingerGenders.Singers" });

            List<GenderBE> listbe = new List<GenderBE>();
            foreach (Genders item in entities)
            {
                listbe.Add(Patterns.Singleton.FactoryGender.GetInstance().CreateBusiness(item));
            }
            return listbe;
        }

        public GenderBE GetById(long Id)
        {
            Expression<Func<DataModal.DBClass.Genders, Boolean>> predicate = u => u.idGender == Id && u.state == (byte)StateEnum.Activated;
            Genders entity = _unitOfWork.GenderRepository.GetOneByFilters(predicate, new string[] { "SingerGenders", "SingerGenders.Singers" });
            GenderBE be = null;
            if (entity != null)
            {
                be = new GenderBE();
                be = Patterns.Singleton.FactoryGender.GetInstance().CreateBusiness(entity);
            }
            return be;
        }
    }
}
