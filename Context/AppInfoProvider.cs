// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppNarcServer.Context
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using AppNarcServer.Entity;
    using MongoDB.Driver;
    using MongoDB.Entities;

    /// <summary>
    /// Provider for the <see cref="AppInfo"/> entity.
    /// </summary>
    public class AppInfoProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppInfoProvider"/> class.
        /// </summary>
        public AppInfoProvider()
        {
            string database = Environment.GetEnvironmentVariable("Database");
            string databaseHost = Environment.GetEnvironmentVariable("DatabaseHost");
            int.TryParse(Environment.GetEnvironmentVariable("DatabasePort"), out int databasePort);
            new DB(database, databaseHost, databasePort);
        }

        /// <summary>
        /// Finds information on a specific application.
        /// </summary>
        /// <param name="alternateName">The process name of the application.</param>
        /// <returns>The AppInfo found that corresponds to the alternate name passed in.</returns>
        public AppInfo FindAppinfoByAlternateName(string alternateName)
        {
            try
            {
                return DB.Find<AppInfo>()
                               .Many(x => x.AlternateNames.Contains(alternateName))
                               .First();
            }
            catch (Exception exc)
            {
                Debug.WriteLine("There was an exception finding the AppInfo.");
                Debug.WriteLine(exc.StackTrace);
                return null;
            }
        }
    }
}
