// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppNarcServer.Entity
{
    using MongoDB.Entities.Core;

    /// <summary>
    /// An entity that stores user information and their associated AppUsage.
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        /// Gets or sets the user name of the user.
        /// </summary>
        public string UserName { get; set; }
    }
}
