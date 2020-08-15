// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppNarcServer.Entity
{
    using System.Collections.Generic;
    using MongoDB.Entities.Core;

    /// <summary>
    /// Entity class that defines application info.
    /// </summary>
    public class AppInfo : Entity
    {
        /// <summary>
        /// Gets or sets the friendly name.
        /// Note: this is a manual process to make the process name more firendly. Such as msedge being Microsoft Edge.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets  alist of alternate names for the application.
        /// Note: these generally match the process name - such as msedge / vscode.
        /// </summary>
        public List<string> AlternateNames { get; set; }

        /// <summary>
        /// Gets or sets the descripton of the application.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the category of the application.
        /// </summary>
        public AppCategory Category { get; set; }
    }
}
