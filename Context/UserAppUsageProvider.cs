// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppNarcServer.Context
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using AppNarcServer.Entity;
    using MongoDB.Entities;

    /// <summary>
    /// The provider for UserAppUsage entities.
    /// </summary>
    public class UserAppUsageProvider
    {
        /// <summary>
        /// Finds a <see cref="UserAppUsage"/> by the user name associated with it.
        /// </summary>
        /// <param name="userName">A unique username that identifies a specific user's app usage.</param>
        /// <returns>The user's app usage based on the provided user name.</returns>
        public UserAppUsage FindUserAppUsageByUserName(string userName)
        {
            try
            {
                return DB.Find<UserAppUsage>()
                               .Many(x => x.UserName == userName)
                               .First();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.StackTrace);
                return null;
            }
        }
    }
}
