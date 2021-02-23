using System;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.Models.Domain;

namespace TicketingApp.Repositories.Interfaces
{
    public interface IUserProfilesRepository
    {
        Task CreateAsync(UserProfile userProfile);

        Task<UserProfile> GetByIdAsync(string id);
        Task<UserProfile> GetByUserId(string userId);
        void Remove(UserProfile userProfile);
        void Update(UserProfile userProfile);

    }
}
