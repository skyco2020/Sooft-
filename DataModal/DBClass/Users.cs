using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModal.DBClass
{
    public class Users
    {
        [Key]
        public long idUser { get; set; }

        public String userName { get; set; }

        public String userPass { get; set; }
        public DateTime creationDate { get; set; }

        public DateTime finalDate { get; set; }

        public Int32 state { get; set; }

        #region List
        public Singers Singers { get; set; }

        #endregion
    }
}
