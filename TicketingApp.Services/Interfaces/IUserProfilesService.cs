using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketingApp.Infrastructure.Options;
using TicketingApp.Models.Domain;
using TicketingApp.Models.Mappers;
using TicketingApp.Repositories.Interfaces;
using TicketingApp.Shared.Models;
using TicketingApp.Shared.Requests;
using TicketingApp.Shared.Responses;


namespace TicketingApp.Services.Interfaces
{
    public interface IUserProfilesService
    {
        Task<OperationResponse<UserProfileDetail>> GetProfileByUserIdAsync();

        Task<OperationResponse<UserProfileDetail>> CreateProfileAsync(CreateProfileRequest model);
    }
    public class UserProfilesService : BaseService, IUserProfilesService
    {
        private readonly IdentityOptions _identity;
        private readonly IUnitOfWork _unitOfWork;

        public UserProfilesService(IdentityOptions identity,
                                   IUnitOfWork unitOfWork)
        {
            _identity = identity;
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResponse<UserProfileDetail>> CreateProfileAsync(CreateProfileRequest model)
        {
            var user = _identity.User;

            var city = user.FindFirst("city").Value;
            var country = user.FindFirst("country").Value;
            var firstName = user.FindFirst(ClaimTypes.GivenName).Value;
            var lastName = user.FindFirst(ClaimTypes.Surname).Value;
            var fullName = user.FindFirst("name").Value;
            var email = user.FindFirst("emails").Value;


            //TODO: Upload the piicture to Azure Blob Storage
            string profilePictureUrl = "Unknown";

            var newUser = new UserProfile
            {
                Country = country,
                City = city,
                CreatedOn = DateTime.UtcNow,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Id = Guid.NewGuid().ToString(),
                UserId = _identity.UserId,
                IsOrganizer = model.IsOrganizer,
                ProfilePicture = profilePictureUrl,
            };

            await _unitOfWork.UserProfiles.CreateAsync(newUser);
            await _unitOfWork.CommitChangesAsync();

            return Success("User profile created successfully", newUser.ToUserProfileDetail());

        }

        public async Task<OperationResponse<UserProfileDetail>> GetProfileByUserIdAsync()
        {
            var userProfile = await _unitOfWork.UserProfiles.GetByUserId(_identity.UserId);
            
            if (userProfile == null)
                return Error<UserProfileDetail>("Profile not found", null);

            return Success("Profile retrieved successuflly", userProfile.ToUserProfileDetail());
        }
    }
}
