using System;
using System.Collections.Generic;

namespace BussinessEntities.BE
{
    public partial class GenderBE
    {
        public Int64 idGender { get; set; }
        public Int64 idUser { get; set; }

        public String name { get; set; }

        public DateTime creationDate { get; set; }
        public DateTime finalDate { get; set; }
        public Int32 state { get; set; }

        #region Relation
        public UserBE Users { set; get; }
        #endregion

        #region List
        public List<SingerGenderBE> SingerGenders { get; set; }
        #endregion

    }
}
