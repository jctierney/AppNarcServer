// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppNarcServer.Entity
{
    using System;
    using System.Collections.Generic;
    using AppTrackerBackendService.Entity;
    using MongoDB.Entities.Core;

    /// <summary>
    /// An entity that stores user information and their associated AppUsage.
    /// </summary>
    public class UserAppUsage : Entity
    {
        /// <summary>
        /// Gets or sets the user name of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the list of apps the user uses.
        /// </summary>
        public List<AppUsage> AppUsages { get; set; }

        public DateTime LastAppUsageUpdateTime { get; set; }
    }
}
