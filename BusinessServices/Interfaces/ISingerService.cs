using BussinessEntities.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interfaces
{
    public interface ISingerService
    {
        SingerBE GetById(Int64 Id);
        List<SingerBE> GetAll(Int32 state, String Search);
        Int64 Create(SingerBE Be);
        Int64 CreateGenderSong(SingerGenderBE Be);
        List<SingerGenderBE> DetailGenderSong(Int64 Id);
    }
}
