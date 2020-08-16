using BusinessServices.Interfaces;
using BussinessEntities.BE;
using DataModal.DBClass;
using DataModal.UnitOfWork;
using Resolver.Cryptography;
using Resolver.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Services
{
    public class UserService : IUserService
    {
        #region Dependency injection
        private readonly UnitOfWork _unitOfWork;
        public UserService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        public long Create(UserBE Be)
        {
            try
            {
                Users entity = Patterns.Singleton.FactoryUser.GetInstance().CreateEntity(Be);
                List<Users> verify = _unitOfWork.UserRepository.GetAllByFilters(p => p.userName.ToLower() == entity.userName.ToLower()).ToList();
                if (verify.Count > 0)
                    throw new Exception(((Int32)System.Net.HttpStatusCode.BadRequest).ToString());

                _unitOfWork.UserRepository.Create(entity);
                _unitOfWork.Commit();
                return (Int64)System.Net.HttpStatusCode.Created;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserBE> GetAll(int state, string Search)
        {
            Expression<Func<DataModal.DBClass.Users, Boolean>> predicate = u => u.state == (byte)state && (u.userName == Search || Search == "");
            IQueryable<DataModal.DBClass.Users> entities = _unitOfWork.UserRepository.GetAllByFilters(predicate, null);

            List<UserBE> listbe = new List<UserBE>();
            foreach (Users item in entities)
            {
                listbe.Add(Patterns.Singleton.FactoryUser.GetInstance().CreateBusiness(item));
            }
            return listbe;
        }

        public UserBE GetById(long Id)
        {
            Expression<Func<DataModal.DBClass.Users, Boolean>> predicate = u => u.idUser == Id && u.state == (byte)StateEnum.Activated;
            Users entity = _unitOfWork.UserRepository.GetOneByFilters(predicate, null);
            UserBE be = null;
            if (entity != null)
            {
                be = new UserBE();
                be = Patterns.Singleton.FactoryUser.GetInstance().CreateBusiness(entity);
            }
            return be;
        }
        public UserBE Login(string Username, string userpass)
        {
            String passEncrypt = MD5Base.GetInstance().Encypt(userpass);
            Expression<Func<DataModal.DBClass.Users, Boolean>> predicate = u => u.userName == Username && u.userPass == passEncrypt && u.state == (byte)StateEnum.Activated;
            Users entity = _unitOfWork.UserRepository.GetOneByFilters(predicate, null);
            UserBE be = null;
            if (entity != null)
            {
                be = new UserBE();
                be = Patterns.Singleton.FactoryUser.GetInstance().CreateBusiness(entity);
            }
            return be;
        }
    }
}
