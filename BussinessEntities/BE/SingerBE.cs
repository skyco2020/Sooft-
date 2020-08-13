using System;
using System.Collections.Generic;

namespace BussinessEntities.BE
{
    public partial class SingerBE
    {
        public Int64 idSinger { get; set; }

        public String Name { get; set; }

        public Int32 state { get; set; }

        #region List
        public  List<SingerGenderBE> SingerGenders { get; set; }

        #endregion
    }
}
