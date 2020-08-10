namespace AppNarcServer.Controllers
{
    using AppNarcServer.Context;
    using AppNarcServer.Entity;
    using Microsoft.AspNetCore.Mvc;
    using MongoDB.Entities;

    [Route("api/[controller]")]
    [ApiController]
    public class AppInfoController : ControllerBase
    {
        private AppInfoProvider appInfoProvider;

        public AppInfoController()
        {
            this.appInfoProvider = new AppInfoProvider();
        }

        /// <summary>
        /// GETs the collection of application informations we have on the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{applicationName}")]
        public AppInfo Get(string applicationName)
        {
            AppInfo appInfo = this.appInfoProvider.FindAppinfoByAlternateName(applicationName);
            return appInfo;
        }

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
