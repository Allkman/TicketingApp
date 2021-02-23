using System;
using System.Collections.Generic;
using System.Text;
using TicketingApp.Infrastructure.Utilities;
using TicketingApp.Models.Domain;
using TicketingApp.Shared.Models;

namespace TicketingApp.Models.Mappers
{
    public static class UserProfileMapper
    {
        public static UserProfileDetail ToUserProfileDetail(this UserProfile userProfile)
        {
            return new UserProfileDetail
            {
                Id              = userProfile.Id,
                Country         = userProfile.Country,
                Email           = userProfile.Email,
                FirstName       = userProfile.FirstName,
                IsOrganizer     = userProfile.IsOrganizer,
                LastName        = userProfile.LastName,
                UserId          = userProfile.UserId,
                ProfilePicture  = userProfile.ProfilePicture,
                CreatedSince    = DateTimeUtilities.GetPassedTime(DateTime.UtcNow, userProfile.CreatedOn)
            };
        }

    }
}
