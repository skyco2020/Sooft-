using BussinessEntities.BE;
using DataModal.DBClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Patterns.Singleton
{
    public class FactoryGender
    {
        private static FactoryGender _factory;
        public static FactoryGender GetInstance()
        {
            if (_factory == null)
                _factory = new FactoryGender();
            return _factory;
        }


        #region Business
        public GenderBE CreateBusiness(Genders entity)
        {
            GenderBE be;
            if (entity != null)
            {
                be = new GenderBE()
                {
                   creationDate = entity.creationDate,
                   finalDate = entity.finalDate,
                   idGender = entity.idGender,
                   idUser = entity.idUser,
                   name = entity.name,
                   state = entity.state,
                   Users = entity.Users != null ? FactoryUser.GetInstance().CreateBusiness(entity.Users): null
                };

                //if (entity.SingerGenders != null)
                //{
                //    be.SingerGenders = new List<SingerGenderBE>();

                //    foreach (SingerGenders item in entity.SingerGenders)
                //    {
                //        be.SingerGenders.Add(FactorySingerGender.GetInstance().CreateBusiness(item));
                //    }
                //}
                return be;
            }
            return null;
        }
        #endregion

        #region Entity
        public Genders CreateEntity(GenderBE be)
        {
            Genders entity;
            if (be != null)
            {
                entity = new Genders()
                {
                    creationDate = be.creationDate,
                    finalDate = be.finalDate,
                    idGender = be.idGender,
                    idUser = be.idUser,
                    name = be.name,
                    state = be.state,
                };
                if (be.SingerGenders != null)
                {
                    entity.SingerGenders = new List<SingerGenders>();

                    foreach (SingerGenderBE item in be.SingerGenders)
                    {
                        entity.SingerGenders.Add(FactorySingerGender.GetInstance().CreateEntity(item));
                    }
                }
                return entity;

            }
            return null;
        }
        #endregion
    }
}
