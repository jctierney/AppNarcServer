// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppNarcServer.Context.Administrator
{
    using AppTrackerBackendService.Entity;

    /// <summary>
    /// Interface for the administration of the <see cref="AppUsage"/> entity.
    /// </summary>
    public interface IAppUsageAdministrator
    {
        /// <summary>
        /// Saves an <see cref="AppUsage"/> to the database.
        /// </summary>
        /// <param name="appUsage">The AppUsage to save.</param>
        void SaveAppUsage(AppUsage appUsage);
    }
}