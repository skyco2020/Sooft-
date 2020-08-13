namespace DataModal.DBClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SingerGenders
    {
        [Key]
        public Int64 idSingerGender { get; set; }

        public Int64 idSinger { get; set; }

        public Int64 idGender { get; set; }

        public Int32 state { get; set; }

        #region Relation
        [ForeignKey("idGender")]
        public Genders Genders { get; set; }

        [ForeignKey("idSinger")]
        public Singers Singers { get; set; }

        #endregion
    }
}
