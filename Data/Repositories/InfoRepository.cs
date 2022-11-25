using Microsoft.EntityFrameworkCore;
using SimpleCV.Data.DataContext.EF;
using SimpleCV.Data.DTO;
using SimpleCV.Data.Entities;
using SimpleCV.Data.Repositories.IRepositories;

namespace SimpleCV.Data.Repositories
{
    public class InfoRepository : GenericRepository<Info>, IInfoRepository
    {
        private readonly PgDbContext _pgDbContext;

        public InfoRepository(PgDbContext pgDbContext) : base(pgDbContext)
        {
            _pgDbContext = pgDbContext;
        }
    }
}