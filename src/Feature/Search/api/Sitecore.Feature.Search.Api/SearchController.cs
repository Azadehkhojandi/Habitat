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
    using System.Collections.Generic;
    using System.Web.Http;
    using Services.Core;
    using Services.Infrastructure.Web.Http;

    using Sitecore.Feature.Search.Api.Models;

    /// <summary>
    /// The search controller.
    /// </summary>
    [ServicesController]
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
        public IEnumerable<SearchFeedsModel> Get(string keywords)
        {
            return new List<SearchFeedsModel>()
                           {
                               new SearchFeedsModel() { Name = keywords, Description = "Test1", Link = "www.google.com" },
                               new SearchFeedsModel() { Name = keywords, Description = "Test2", Link = "www.google.com" },
                           };
        }
    }
}
