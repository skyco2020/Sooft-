using System;

namespace BussinessEntities.BE
{
    public class UserBE
    {
        public long idUser { get; set; }

        public String userName { get; set; }

        public String userPass { get; set; }
        public DateTime creationDate { get; set; }

        public DateTime finalDate { get; set; }

        public Int32 state { get; set; }

        #region List
        public SingerBE Singers { get; set; }

        #endregion
    }
}
