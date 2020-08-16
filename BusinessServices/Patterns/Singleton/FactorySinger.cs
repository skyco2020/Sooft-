using BussinessEntities.BE;
using DataModal.DBClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Patterns.Singleton
{
    public class FactorySinger
    {
        private static FactorySinger _factory;
        public static FactorySinger GetInstance()
        {
            if (_factory == null)
                _factory = new FactorySinger();
            return _factory;
        }


        #region Business
        public SingerBE CreateBusiness(Singers entity)
        {
            SingerBE be;
            if (entity != null)
            {
                be = new SingerBE()
                {
                   idSinger = entity.idSinger,
                   Name = entity.Name,
                   state = entity.state
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
        public Singers CreateEntity(SingerBE be)
        {
            Singers entity;
            if (be != null)
            {
                entity = new Singers()
                {
                    idSinger = be.idSinger,
                    Name = be.Name,
                    state = be.state
                };               
                return entity;

            }
            return null;
        }
        #endregion
    }
}
