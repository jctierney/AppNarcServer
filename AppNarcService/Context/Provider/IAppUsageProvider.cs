// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppNarcServer.Context
{
    using System.Collections.Generic;
    using AppTrackerBackendService.Entity;

    /// <summary>
    /// Interface for the provider of <see cref="AppUsage"/> entities.
    /// Handles finding entities based on predefined parameters.
    /// </summary>
    public interface IAppUsageProvider
    {
        /// <summary>
        /// Finds a list of <see cref="AppUsage"/> based on the provided user ID.
        /// </summary>
        /// <param name="userId">The User ID used to find all of the associated <see cref="AppUsage"/>s.</param>
        /// <returns>A list of <see cref="AppUsage"/>s associated with the user ID. If none are found, this returns null.</returns>
        List<AppUsage> FindByUser(string userId);

        /// <summary>
        /// Finds the specific <see cref="AppUsage"/> by the user Id and application name.
        /// </summary>
        /// <param name="userId">The ID of the user that is using this application.</param>
        /// <param name="appName">The name of the application to find.</param>
        /// <returns>A single <see cref="AppUsage"/> that has the specified app name and user ID.</returns>
        AppUsage FindByUserAndName(string userId, string appName);
    }
}