using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingApp.Models.Data;
using TicketingApp.Models.Domain;
using TicketingApp.Repositories.Interfaces;

namespace TicketingApp.Repositories
{
    public class UserProfilesRepository : IUserProfilesRepository
    {
        private readonly ApplicationDbContext _db;
        public UserProfilesRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(UserProfile userProfile)
        {
            await _db.UserProfiles.AddAsync(userProfile);
        }

        public async Task<UserProfile> GetByIdAsync(string id)
        {
            return await _db.UserProfiles.FindAsync(id);      
        }

        public async Task<UserProfile> GetByUserId(string userId)
        {
            return await _db.UserProfiles.SingleOrDefaultAsync(up => up.UserId == userId);
        }

        public void Remove(UserProfile userProfile)
        {
            _db.UserProfiles.Remove(userProfile);
        }

        public void Update(UserProfile userProfile)
        {
            _db.Entry(userProfile).State = EntityState.Modified;
        }
    }
}
