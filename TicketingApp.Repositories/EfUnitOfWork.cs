using System.Threading.Tasks;
using TicketingApp.Models.Data;
using TicketingApp.Repositories.Interfaces;

namespace TicketingApp.Repositories
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public EfUnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        private IUserProfilesRepository _userProfiles;
        public IUserProfilesRepository UserProfiles 
        {
            //check if user profile exists/ if not then create new // if exists return _userProfiles
            get
            {
                if (_userProfiles == null) 
                    _userProfiles = new UserProfilesRepository(_db);

                return _userProfiles;
                
            }
        }
        public async Task CommitChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }

}
