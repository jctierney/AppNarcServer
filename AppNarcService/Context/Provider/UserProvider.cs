// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppNarcServer.Context
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using AppNarcServer.Entity;
    using MongoDB.Entities;

    /// <summary>
    /// The provider for UserAppUsage entities.
    /// </summary>
    public class UserProvider : IUserProvider
    {
        /// <inheritdoc/>
        public User FindUserByUserName(string userName)
        {
            try
            {
                return DB.Find<User>()
                               .Many(x => x.UserName == userName)
                               .First();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.StackTrace);
                return null;
            }
        }
    }
}
