using BussinessEntities.BE;
using DataModal.DBClass;
using Resolver.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Patterns.Singleton
{
    public class FactoryUser
    {
        private static FactoryUser _factory;
        public static FactoryUser GetInstance()
        {
            if (_factory == null)
                _factory = new FactoryUser();
            return _factory;
        }


        #region Business
        public UserBE CreateBusiness(Users entity)
        {
            UserBE be;
            if (entity != null)
            {
                be = new UserBE()
                {
                    creationDate = entity.creationDate,
                    finalDate = entity.finalDate,
                    idUser = entity.idUser,
                    userName = entity.userName,
                    state = entity.state,
                    userPass = MD5Base.GetInstance().Decrypt(entity.userPass),
                    
                };                
                return be;
            }
            return null;
        }
        #endregion

        #region Entity
        public Users CreateEntity(UserBE be)
        {
            Users entity;
            if (be != null)
            {
                entity = new Users()
                {
                    creationDate = be.creationDate,
                    finalDate = be.finalDate,
                    idUser = be.idUser,
                    userName = be.userName,
                    state = be.state,
                    userPass = MD5Base.GetInstance().Encypt(be.userPass),
                   
                };               
                return entity;

            }
            return null;
        }
        #endregion
    }
}
