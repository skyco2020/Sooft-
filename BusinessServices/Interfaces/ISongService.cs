using BussinessEntities.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interfaces
{
    public interface ISongService
    {
        SongBE GetById(Int64 Id);
        List<SongBE> GetAll(Int32 state, String Search);
        Int64 Create(SongBE Be);
    }
}
