// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppNarcServer.Controllers
{
    using AppNarcServer.Context;
    using AppNarcServer.Entity;
    using Microsoft.AspNetCore.Mvc;
    using MongoDB.Entities;

    /// <summary>
    /// Controller class for the <see cref="AppInfo"/> entity.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AppInfoController : ControllerBase
    {
        private AppInfoProvider appInfoProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppInfoController"/> class.
        /// </summary>
        public AppInfoController()
        {
            this.appInfoProvider = new AppInfoProvider();
        }

        /// <summary>
        /// GETs the collection of application informations we have on the system.
        /// </summary>
        /// <param name="applicationName">The name of the application to get.</param>
        /// <returns>A <see cref="AppInfo"/> formatted as JSON based on the provided application name. If not application name is found, it returns null.</returns>
        [HttpGet("{applicationName}")]
        public AppInfo Get(string applicationName)
        {
            AppInfo appInfo = this.appInfoProvider.FindAppinfoByAlternateName(applicationName);
            return appInfo;
        }

        /// <summary>
        /// POST method for a new / updated <see cref="AppInfo"/>.
        /// </summary>
        /// <param name="appInfoToAdd">The <see cref="AppInfo"/> to be added or updated.</param>
        [HttpPost]
        public void Post([FromBody] AppInfo appInfoToAdd)
        {
            string alternateName = appInfoToAdd.AlternateNames[0];
            AppInfo existingAppInfo = this.appInfoProvider.FindAppinfoByAlternateName(alternateName);
            if (existingAppInfo == null)
            {
                appInfoToAdd.Save();
                return;
            }
        }
    }
}
