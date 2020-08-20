// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppTrackerBackendService.Entity
{
    using System;
    using MongoDB.Entities.Core;

    /// <summary>
    /// An entity that defines the usage of an application.
    /// This entity is used to track the time and the environment where the application was used, not the application itself.
    /// Any information on a specific application should be stored inside of the <see cref="AppInfo"/> entity.
    /// </summary>
    public class AppUsage : Entity
    {
        /// <summary>
        /// Gets or sets the name of the application that's being used.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the time the application was used.
        /// </summary>
        public int TimeUsed { get; set; }

        /// <summary>
        /// Gets or sets the user id associated with this application usage.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the environment the application is used in.
        /// </summary>
        public AppEnvironment Environment { get; set; }

        /// <summary>
        /// Determines if two <see cref="AppUsage"/>s are equal.
        /// </summary>
        /// <param name="obj">The other <see cref="AppUsage"/> to check for equality with this particular instance.</param>
        /// <returns>True if the two objects are equal. False if they are not equal.</returns>
        public override bool Equals(object obj)
        {
            return obj is AppUsage usage &&
                   this.ID == usage.ID &&
                   this.ModifiedOn == usage.ModifiedOn &&
                   this.Name == usage.Name &&
                   this.TimeUsed == usage.TimeUsed &&
                   this.UserId == usage.UserId &&
                   this.Environment == usage.Environment;
        }

        /// <summary>
        /// Returns the HashCode for the <see cref="AppUsage"/>.
        /// </summary>
        /// <returns>HashCode as an int of the <see cref="AppUsage"/>.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.ID, this.ModifiedOn, this.Name, this.TimeUsed, this.UserId, this.Environment);
        }
    }
}
