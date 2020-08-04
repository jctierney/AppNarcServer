// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppTrackerBackendService.Controllers
{
    using System.Collections.Generic;
    using System.Text.Json;
    using AppTrackerBackendService.Entity;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The controller that handles all of the GET/POST/DELETE for <see cref="AppUsage"/>.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsageController : ControllerBase
    {
        private static readonly string JsonFilePath = "./AppUsage.json";

        /// <summary>
        /// The GET method for returning a list of all AppUsages in the system.
        /// </summary>
        /// <returns>A <see cref="List{AppUsage}"/> of all App Usages in the system formatted as JSON.</returns>
        [HttpGet]
        public List<AppUsage> Get()
        {
            List<AppUsage> appUsages = this.LoadAppUsages();
            return appUsages;
        }

        /// <summary>
        /// GET method to get an individual <see cref="AppUsage"/> based on the provided Id.
        /// </summary>
        /// <param name="id">The ID of the <see cref="AppUsage"/> to return.</param>
        /// <returns>If an AppUsage is found with the provided ID, it will return that specific AppUsage in JSON format. If no AppUsage is found with the provided ID, it will currently return an empty response body.</returns>
        [HttpGet("{id}")]
        public AppUsage Get(int id)
        {
            List<AppUsage> appUsages = this.LoadAppUsages();
            AppUsage existingAppUsage = appUsages.Find(x => x.Id == id);
            if (existingAppUsage != null)
            {
                return existingAppUsage;
            }

            return null;
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
            List<AppUsage> appUsages = this.LoadAppUsages();
            foreach (AppUsage appUsage in appUsagesToAdd)
            {
                AppUsage existingAppUsage = appUsages.Find(x => x.Name.Equals(appUsage.Name) && x.Environment.Equals(appUsage.Environment));
                if (existingAppUsage != null)
                {
                    existingAppUsage.TimeUsed += appUsage.TimeUsed;
                }
                else
                {
                    appUsages.Add(appUsage);
                }
            }

            this.SaveAppUsages(appUsages);
            return appUsagesToAdd;
        }

        /// <summary>
        /// Loads the app usages from our JSON file.
        /// </summary>
        /// <returns>A list of <see cref="AppUsage"/>s loaded from the JSON file.</returns>
        protected List<AppUsage> LoadAppUsages()
        {
            string jsonData = System.IO.File.ReadAllText(JsonFilePath);
            return JsonSerializer.Deserialize<List<AppUsage>>(jsonData);
        }

        /// <summary>
        /// Saves a list of app usages to the JSON file.
        /// </summary>
        /// <param name="appUsagesToSave">The list of app usages to save to the file.</param>
        protected void SaveAppUsages(List<AppUsage> appUsagesToSave)
        {
            string jsonData = JsonSerializer.Serialize(appUsagesToSave);
            System.IO.File.WriteAllText(JsonFilePath, jsonData);
        }
    }
}
