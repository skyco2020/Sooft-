using DataModal.DBClass;
using DataModal.GenericRepository;
using DataModal.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModal.Repositories.Repository
{
    public class SingerGenderRepository : SooftRepository<SingerGenders>, ISingerGenderRepository
    {
        public SingerGenderRepository(SooftDbContext context) : base(context)
        {
        }
    }
}
