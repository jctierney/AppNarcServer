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
    public class AppUsageProvider : IAppUsageProvider
    {
        /// <inheritdoc/>
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

        /// <inheritdoc/>
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
