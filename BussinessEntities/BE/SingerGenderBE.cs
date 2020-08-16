
using System;
namespace BussinessEntities.BE
{

    public partial class SingerGenderBE
    {
        public Int64 idSingerGender { get; set; }

        public Int64 idSinger { get; set; }

        public Int64 idGender { get; set; }
        public Int64 idSong { get; set; }

        public Int32 state { get; set; }

        #region Relation
        public GenderBE Genders { get; set; }

        public SingerBE Singers { get; set; }

        public SongBE song { get; set; }

        #endregion
    }
}
