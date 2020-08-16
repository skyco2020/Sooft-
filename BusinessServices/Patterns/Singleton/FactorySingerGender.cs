using BussinessEntities.BE;
using DataModal.DBClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Patterns.Singleton
{
    public class FactorySingerGender
    {
        private static FactorySingerGender _factory;
        public static FactorySingerGender GetInstance()
        {
            if (_factory == null)
                _factory = new FactorySingerGender();
            return _factory;
        }


        #region Business
        public SingerGenderBE CreateBusiness(SingerGenders entity)
        {
            SingerGenderBE be;
            if (entity != null)
            {
                be = new SingerGenderBE()
                {
                    idSinger = entity.idSinger,
                    idSingerGender = entity.idSingerGender,
                    idGender = entity.idGender,
                    idSong = entity.idSong,
                    state = entity.state,
                    song = entity.Songs != null ? FactorySong.GetInstance().CreateBusiness(entity.Songs): null,
                    Genders = entity.Genders != null ? FactoryGender.GetInstance().CreateBusiness(entity.Genders):null
                };
                return be;
            }
            return null;
        }
        #endregion

        #region Entity
        public SingerGenders CreateEntity(SingerGenderBE be)
        {
            SingerGenders entity;
            if (be != null)
            {
                entity = new SingerGenders()
                {
                    idSinger = be.idSinger,
                    idSingerGender = be.idSingerGender,
                    idSong = be.idSong,
                    idGender = be.idGender,
                    state = be.state
                };
                return entity;

            }
            return null;
        }
        #endregion
    }
}
