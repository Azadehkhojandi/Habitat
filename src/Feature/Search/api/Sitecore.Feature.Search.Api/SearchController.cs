// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchController.cs" company="Redstuffy">
//   Copyright (c) Redstuffy. All rights reserved.
// </copyright>
// <summary>
//   Defines the SearchController.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Feature.Search.Api
{
    using System.Web.Http;

    /// <summary>
    /// The search controller.
    /// </summary>
    public class SearchController : Services.Infrastructure.Web.Http.ServicesApiController
    {
        /// <summary>
        /// The test.
        /// </summary>
        /// <param name="keywords">
        /// The keywords.
        /// </param>
        /// <returns>
        /// The search results.
        /// </returns>
        [HttpGet]
        public IHttpActionResult Get(string keywords)
        {
            return this.Ok(new
            {
                Name = keywords,
                URL = "www.google.com"
            });
        }
    }
}
