// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppNarcServer.Context
{
    using AppNarcServer.Entity;

    /// <summary>
    /// Interface for provider classes of the <see cref="User"/> entity.
    /// </summary>
    public interface IUserProvider
    {
        /// <summary>
        /// Finds a <see cref="User"/> by the user name associated with it.
        /// </summary>
        /// <param name="userName">A unique username that identifies a specific user's app usage.</param>
        /// <returns>The user's app usage based on the provided user name.</returns>
        User FindUserByUserName(string userName);
    }
}