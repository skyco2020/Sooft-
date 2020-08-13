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
    public class SingerRepository : SooftRepository<Singers>, ISingerRepository
    {
        public SingerRepository(SooftDbContext context) : base(context)
        {
        }
    }
}
