namespace DataModal.DBClass
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Genders
    {
        [Key]
        public Int64 idGender { get; set; }
        public Int64 idUser { get; set; }

        [Required]
        [StringLength(100)]
        public String name { get; set; }

        public DateTime creationDate { get; set; }
        public DateTime finalDate { get; set; }
        public Int32 state { get; set; }

        #region Relation
        [ForeignKey("idUser")]
        public Users Users { set; get; }
        #endregion

        #region List
        public List<SingerGenders> SingerGenders { get; set; }
        #endregion

    }
}
