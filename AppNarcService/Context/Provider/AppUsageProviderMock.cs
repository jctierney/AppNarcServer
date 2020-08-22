// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppNarcServer.Context.Provider
{
    using System.Collections.Generic;
    using AppTrackerBackendService.Entity;

    /// <summary>
    /// Mock class for the <see cref="IAppUsageProvider"/> interface.
    /// </summary>
    public class AppUsageProviderMock : IAppUsageProvider
    {
        /// <inheritdoc/>
        public List<AppUsage> FindByUser(string userId)
        {
            List<AppUsage> appUsages = new List<AppUsage>();
            AppUsage appUsage = new AppUsage
            {
                Name = "MockApp",
                TimeUsed = 37,
                UserId = "MockUser",
                Environment = AppEnvironment.Windows,
            };

            appUsages.Add(appUsage);

            return appUsages;
        }

        /// <inheritdoc/>
        public AppUsage FindByUserAndName(string userId, string appName)
        {
            AppUsage appUsage = new AppUsage
            {
                Name = "MockApp",
                TimeUsed = 37,
                UserId = "MockUser",
                Environment = AppEnvironment.Windows,
            };

            return appUsage;
        }
    }
}
