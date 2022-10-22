using Microsoft.EntityFrameworkCore;
using SimpleCV.Data.DataContext.EF;
using SimpleCV.Data.DTO;
using SimpleCV.Data.Entities;
using SimpleCV.Data.Repositories.IRepositories;

namespace SimpleCV.Data.Repositories 
{
    public class UserRepository : GenericRepository<User>, IUserRepository 
    {
        private readonly PgDbContext _pgDbContext;

        public UserRepository (PgDbContext pgDbContext) : base(pgDbContext)
        {
            _pgDbContext = pgDbContext;
        }

        public async Task<User> UpdateUserProperties(User user, int Id, List<UserPatchDTO> userPatchDTOs)
        {
            var pairsOfProVal = userPatchDTOs.ToDictionary(a => a.PropertyName, a => a.PropertyValue);
            var entry = _pgDbContext.Entry(user);

            entry.CurrentValues.SetValues(pairsOfProVal);
            entry.State = EntityState.Modified;

            await _pgDbContext.SaveChangesAsync();

            return entry.Entity;
        }
    }
}