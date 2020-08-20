// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppNarcServer.Context
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using AppTrackerBackendService.Entity;
    using MongoDB.Entities;

    /// <summary>
    /// Provider class for the <see cref="AppUsage"/> entity.
    /// </summary>
    public class AppUsageProvider
    {
        /// <summary>
        /// Finds a list of <see cref="AppUsage"/> based on the provided user ID.
        /// </summary>
        /// <param name="userId">The User ID used to find all of the associated <see cref="AppUsage"/>s.</param>
        /// <returns>A list of <see cref="AppUsage"/>s associated with the user ID. If none are found, this returns null.</returns>
        public virtual List<AppUsage> FindByUser(string userId)
        {
            try
            {
                return DB.Find<AppUsage>()
                    .Many(x => x.UserId == userId);
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Finds the specific <see cref="AppUsage"/> by the user Id and application name.
        /// </summary>
        /// <param name="userId">The ID of the user that is using this application.</param>
        /// <param name="appName">The name of the application to find.</param>
        /// <returns>A single <see cref="AppUsage"/> that has the specified app name and user ID.</returns>
        public virtual AppUsage FindByUserAndName(string userId, string appName)
        {
            try
            {
                return DB.Find<AppUsage>()
                    .Many(x => x.UserId.Equals(userId) && x.Name.Equals(appName))
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
