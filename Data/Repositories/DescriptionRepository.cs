using Microsoft.EntityFrameworkCore;
using SimpleCV.Data.DataContext.EF;
using SimpleCV.Data.DTO;
using SimpleCV.Data.Entities;
using SimpleCV.Data.Repositories.IRepositories;

namespace SimpleCV.Data.Repositories
{
    public class DescriptionRepository : GenericRepository<Description>, IDescriptionRepository
    {
        private readonly PgDbContext _pgDbContext;

        public DescriptionRepository(PgDbContext pgDbContext) : base(pgDbContext)
        {
            _pgDbContext = pgDbContext;
        }
    }
}