// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppTrackerBackendService.Entity
{
    /// <summary>
    /// An entity that defines the usage of an application.
    /// This entity is used to track the time and the environment where the application was used, not the application itself.
    /// Any information on a specific application should be stored inside of the <see cref="AppInfo"/> entity.
    /// </summary>
    public class AppUsage
    {
        /// <summary>
        /// Gets or sets the ID of the individual App Usage.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the application that's being used.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the time the application was used.
        /// </summary>
        public int TimeUsed { get; set; }

        /// <summary>
        /// Gets or sets the environment the application is used in.
        /// </summary>
        public AppEnvironment Environment { get; set; }
    }
}
