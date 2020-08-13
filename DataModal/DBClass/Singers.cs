namespace DataModal.DBClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Singers
    {
        [Key]
        public Int64 idSinger { get; set; }

        [Required]
        [StringLength(100)]
        public String Name { get; set; }

        public Int32 state { get; set; }

        #region List
        public  List<SingerGenders> SingerGenders { get; set; }

        #endregion
    }
}
