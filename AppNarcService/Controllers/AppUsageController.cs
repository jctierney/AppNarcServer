// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppTrackerService.Controllers
{
    using System.Collections.Generic;
    using AppNarcServer.Context;
    using AppNarcServer.Context.Administrator;
    using AppTrackerBackendService.Entity;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The controller that handles all of the GET/POST/DELETE for <see cref="AppUsage"/>.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsageController : ControllerBase
    {
        private readonly IAppUsageProvider appUsageProvider;

        private readonly IAppUsageAdministrator appUsageAdministrator;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppUsageController"/> class.
        /// </summary>
        /// <param name="appUsageProvider">The <see cref="AppUsageProvider"/> implementation to use.</param>
        /// <param name="appUsageAdministrator">The <see cref="AppUsageAdministrator"/> implementation to use.</param>
        public AppUsageController(IAppUsageProvider appUsageProvider, IAppUsageAdministrator appUsageAdministrator)
        {
            this.appUsageProvider = appUsageProvider;
            this.appUsageAdministrator = appUsageAdministrator;
        }

        /// <summary>
        /// The GET method for returning a list of all AppUsages in the system.
        /// </summary>
        /// <returns>A <see cref="List{AppUsage}"/> of all App Usages in the system formatted as JSON.</returns>
        [HttpGet]
        public List<AppUsage> Get()
        {
            return null;
        }

        /// <summary>
        /// GET method to get an individual <see cref="AppUsage"/> based on the provided Id.
        /// </summary>
        /// <param name="userId">The ID of the user that is using the application for the <see cref="AppUsage"/> to return.</param>
        /// <returns>If an AppUsage is found with the provided ID, it will return that specific AppUsage in JSON format.
        /// If no AppUsage is found with the provided ID, it will currently return an empty response body.</returns>
        [HttpGet("user/{userId}")]
        public List<AppUsage> Get(string userId = "")
        {
            return this.appUsageProvider.FindByUser(userId);
        }

        /// <summary>
        /// Updates <see cref="List{AppUsage}"/> passed in with the new times.
        /// This is an incremental update not a complete update - that is the time values passed in will be added to the existing time used.
        /// </summary>
        /// <param name="appUsagesToAdd">A <see cref="List{AppUsage}"/> containing the App Usages to update.</param>
        /// <returns>A list of updated <see cref="AppUsage"/>s.</returns>
        [HttpPost]
        public List<AppUsage> Post([FromBody] List<AppUsage> appUsagesToAdd)
        {
            List<AppUsage> updatedAppUsages = new List<AppUsage>();
            foreach (AppUsage appUsage in appUsagesToAdd)
            {
                AppUsage updatedAppUsage = this.CreateOrUpdateAppUsage(appUsage);
                updatedAppUsages.Add(updatedAppUsage);
            }

            return updatedAppUsages;
        }

        /// <summary>
        /// Creates or updates an <see cref="AppUsage"/>.
        /// If the AppUsage does not already exist, then it will be created. Otherwise, the time will be updated.
        /// </summary>
        /// <param name="appUsage">The <see cref="AppUsage"/> to update or create.</param>
        /// <returns>The created or updated <see cref="AppUsage"/>.</returns>
        protected AppUsage CreateOrUpdateAppUsage(AppUsage appUsage)
        {
            string userId = appUsage.UserId;
            string appName = appUsage.Name;
            AppUsage updatedAppUsage = this.appUsageProvider.FindByUserAndName(userId, appName);
            if (updatedAppUsage != null)
            {
                updatedAppUsage = this.UpdateAndSaveAppUsageTime(updatedAppUsage, appUsage.TimeUsed);
            }
            else
            {
                updatedAppUsage = this.SaveAppUsage(appUsage);
            }

            return updatedAppUsage;
        }

        /// <summary>
        /// Updates an <see cref="AppUsage"/>'s time used and saves the entity.
        /// </summary>
        /// <param name="appUsage">The AppUsage to update and save.</param>
        /// <param name="additionalTimeUsed">The additional time the application was used - this is added to the time used of the AppUsage.</param>
        /// <returns>The updated <see cref="AppUsage"/>.</returns>
        protected AppUsage UpdateAndSaveAppUsageTime(AppUsage appUsage, int additionalTimeUsed)
        {
            AppUsage updatedAppUsage = appUsage;
            updatedAppUsage.TimeUsed += additionalTimeUsed;
            this.SaveAppUsage(updatedAppUsage);

            return updatedAppUsage;
        }

        /// <summary>
        /// Saves an <see cref="AppUsage"/>.
        /// </summary>
        /// <param name="appUsage">The <see cref="AppUsage"/> to save.</param>
        /// <returns>The updated <see cref="AppUsage"/> record.</returns>
        protected AppUsage SaveAppUsage(AppUsage appUsage)
        {
            this.appUsageAdministrator.SaveAppUsage(appUsage);
            return appUsage;
        }
    }
}