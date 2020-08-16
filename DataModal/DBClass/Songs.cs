using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModal.DBClass
{
    public class Songs
    {
        [Key]
        public Int64 idSong { get; set; }
        [Required]
        [StringLength(100)]
        public String name { get; set; }

        public DateTime creationDate { get; set; }
        public DateTime finalDate { get; set; }
        public Int32 state { get; set; }

        //#region Relation       
        //public Users Users { set; get; }
        //#endregion

        #region List
        public List<SingerGenders> SingerGenders { get; set; }
        #endregion
    }
}
