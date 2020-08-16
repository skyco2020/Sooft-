using BussinessEntities.BE;
using DataModal.DBClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Patterns.Singleton
{
    public class FactorySong
    {
        private static FactorySong _factory;
        public static FactorySong GetInstance()
        {
            if (_factory == null)
                _factory = new FactorySong();
            return _factory;
        }


        #region Business
        public SongBE CreateBusiness(Songs entity)
        {
            SongBE be;
            if (entity != null)
            {
                be = new SongBE()
                {
                    idSong = entity.idSong,
                    name = entity.name,
                    creationDate = entity.creationDate,
                    finalDate = entity.finalDate,
                    state = entity.state
                };
                return be;
            }
            return null;
        }
        #endregion

        #region Entity
        public Songs CreateEntity(SongBE be)
        {
            Songs entity;
            if (be != null)
            {
                entity = new Songs()
                {
                    idSong = be.idSong,
                    name = be.name,
                    creationDate = be.creationDate,
                    finalDate = be.finalDate,
                    state = be.state
                };
                return entity;

            }
            return null;
        }
        #endregion
    }
}
