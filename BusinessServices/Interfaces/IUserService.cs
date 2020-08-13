using BussinessEntities.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interfaces
{
    public interface IUserService
    {
        UserBE GetById(Int64 Id);
        List<UserBE> GetAll(Int32 state, String Search);
        UserBE Login(String Username, String userpass);
        Int64 Create(UserBE Be);
    }
}
