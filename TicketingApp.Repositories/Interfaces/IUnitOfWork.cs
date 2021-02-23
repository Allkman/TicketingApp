using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TicketingApp.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IUserProfilesRepository UserProfiles { get; }
        //TODO ...All other Repositories will go here

        Task CommitChangesAsync();
    }

}
