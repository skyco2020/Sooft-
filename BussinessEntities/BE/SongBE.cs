using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntities.BE
{
    public class SongBE
    {
        public Int64 idSong { get; set; }      
        public String name { get; set; }

        public DateTime creationDate { get; set; }
        public DateTime finalDate { get; set; }
        public Int32 state { get; set; }

        //#region Relation       
        //public Users Users { set; get; }
        //#endregion

        #region List
        //public List<SingerGenders> SingerGenders { get; set; }
        #endregion
    }
}
