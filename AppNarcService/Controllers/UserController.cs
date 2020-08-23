// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppNarcServer.Controllers
{
    using AppNarcServer.Context;
    using AppNarcServer.Entity;
    using Microsoft.AspNetCore.Mvc;
    using MongoDB.Entities;

    /// <summary>
    /// The controller class for the AppUserUsage.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserProvider userProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userProvider">Implementation to use of <see cref="IUserProvider"/>.</param>
        public UserController(IUserProvider userProvider)
        {
            this.userProvider = userProvider;
        }

        /// <summary>
        /// GET method for getting a specific user's app usage.
        /// </summary>
        /// <param name="userName">User name of the user to get their associated app usage.</param>
        /// <returns>A json formatted list of the user's app usage information.</returns>
        [HttpGet("{userName}")]
        public User Get(string userName)
        {
            User existing = this.userProvider.FindUserByUserName(userName);
            return existing;
        }

        /// <summary>
        /// Creates a new <see cref="User"/>.
        /// </summary>
        /// <param name="userAppUsage">The user app usage to add.</param>
        /// <returns>Returns the updated/created <see cref="User"/>.</returns>
        [HttpPost]
        public User Post([FromBody] User userAppUsage)
        {
            User existingUserAppUsage = this.userProvider.FindUserByUserName(userAppUsage.UserName);

            if (existingUserAppUsage != null)
            {
                existingUserAppUsage.Save();
                return existingUserAppUsage;
            }
            else
            {
                userAppUsage.Save();
                return userAppUsage;
            }
        }
    }
}
