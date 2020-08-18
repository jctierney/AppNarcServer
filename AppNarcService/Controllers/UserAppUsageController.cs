// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppNarcServer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using AppNarcServer.Context;
    using AppNarcServer.Entity;
    using AppTrackerBackendService.Entity;
    using Microsoft.AspNetCore.Mvc;
    using MongoDB.Entities;

    /// <summary>
    /// The controller class for the AppUserUsage.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserAppUsageController : ControllerBase
    {
        private UserAppUsageProvider userAppUsageProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAppUsageController"/> class.
        /// </summary>
        public UserAppUsageController()
        {
            this.userAppUsageProvider = new UserAppUsageProvider();
        }

        /// <summary>
        /// GET method for getting a specific user's app usage.
        /// </summary>
        /// <param name="userName">User name of the user to get their associated app usage.</param>
        /// <returns>A json formatted list of the user's app usage information.</returns>
        [HttpGet("{userName}")]
        public UserAppUsage Get(string userName)
        {
            UserAppUsage existing = this.userAppUsageProvider.FindUserAppUsageByUserName(userName);
            return existing;
        }

        /// <summary>
        /// Creates a new <see cref="UserAppUsage"/>.
        /// </summary>
        /// <param name="userAppUsage">The user app usage to add.</param>
        [HttpPost]
        public void Post([FromBody] UserAppUsage userAppUsage)
        {
            UserAppUsage existingUserAppUsage = this.userAppUsageProvider.FindUserAppUsageByUserName(userAppUsage.UserName);

            if (existingUserAppUsage != null)
            {
                existingUserAppUsage.Save();
            }
            else
            {
                userAppUsage.Save();
            }
        }
    }
}
