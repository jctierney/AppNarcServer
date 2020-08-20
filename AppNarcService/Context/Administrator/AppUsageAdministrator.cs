// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppNarcServer.Context.Administrator
{
    using AppTrackerBackendService.Entity;
    using MongoDB.Entities;

    /// <summary>
    /// Administrator class for the <see cref="AppUsage"/> class. Handles saving/updating of the entity.
    /// </summary>
    public class AppUsageAdministrator
    {
        /// <summary>
        /// Saves an <see cref="AppUsage"/> to the database.
        /// </summary>
        /// <param name="appUsage">The AppUsage to save.</param>
        public virtual void SaveAppUsage(AppUsage appUsage)
        {
            appUsage.Save();
        }
    }
}
