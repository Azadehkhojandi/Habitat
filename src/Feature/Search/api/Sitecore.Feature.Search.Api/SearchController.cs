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
    using Services.Core;
    using Services.Infrastructure.Web.Http;

    /// <summary>
    /// The search controller.
    /// </summary>
    [ServicesController("Search")]
    public class SearchController : ServicesApiController
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
        public dynamic Get(string keywords)
        {
            var test  = new
            {
                Name = keywords,
                URL = "www.google.com"
            };

            return this.Ok(test);
        }
    }
}
