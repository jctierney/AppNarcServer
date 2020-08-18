// Copyright (c) WinQuire. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.
namespace AppTrackerBackendService.Filters
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// A basic attribute that checks whether an API key is present in the header of the request.
    /// This can be added to a Controller or method of a controller.
    /// </summary>
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeaderName = "ApiKey";

        /// <summary>
        /// Handles the action to validate the API key right before executing the controller method.
        /// </summary>
        /// <param name="context">This is the context that's executing the call.</param>
        /// <param name="next">This is the delegate that we will relay to if the call is successful. In most cases, this will be the <see cref="Controllers"/> method.</param>
        /// <returns>A <see cref="Task"/> after the async request completes.</returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var potentialApiKey))
            {
                return;
            }

            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = configuration.GetValue<string>(ApiKeyHeaderName);

            if (!apiKey.Equals(potentialApiKey))
            {
                return;
            }

            await next();
        }
    }
}
