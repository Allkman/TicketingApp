using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketingApp.Shared.Requests
{
    public class CreateProfileRequest
    {
        public bool IsOrganizer { get; set; }
        public IFormFile ProfilePicture { get; set; }
        //Add more properties on future updates
    }
}
