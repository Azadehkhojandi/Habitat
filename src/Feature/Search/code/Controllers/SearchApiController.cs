// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchApiController.cs" company="Redstuffy">
//   Copyright (c) Redstuffy. All rights reserved.
// </copyright>
// <summary>
//   Defines the SearchController.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Feature.Search.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Foundation.Indexing.Models;
    using Foundation.Indexing.Repositories;

    using Models;

    using Repositories;

    using Services.Core;
    using Services.Infrastructure.Web.Http;

    /// <summary>
    /// The search controller.
    /// </summary>
    [ServicesController]
    public class SearchApiController : ServicesApiController
    {
        public ISearchServiceRepository SearchServiceRepository { get; }
        public ISearchContextRepository SearchContextRepository { get; }
        public QueryRepository QueryRepository { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchApiController"/> class.
        /// </summary>
        public SearchApiController()
        {
            this.SearchContextRepository = new SearchContextRepository();
            this.SearchServiceRepository = new SearchServiceRepository(this.SearchContextRepository.Get());
            this.QueryRepository = new QueryRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchApiController"/> class.
        /// </summary>
        /// <param name="serviceRepository">
        /// The service repository.
        /// </param>
        /// <param name="queryRepository">
        /// The query repository.
        /// </param>
        public SearchApiController(ISearchServiceRepository serviceRepository, QueryRepository queryRepository)
        {
            this.SearchServiceRepository = serviceRepository;
            this.QueryRepository = queryRepository;
        }

        /// <summary>
        /// The test.
        /// </summary>
        /// <returns>
        /// The search results.
        /// </returns>
        [HttpGet]
        public IEnumerable<SearchFeedsModel> Get(string id)
        {
            var query = this.CreateQuery(new SearchQuery
            {
                Query = id
            });

            var results = this.SearchServiceRepository.Get().Search(query);

            return results.Results.Where(searchResult => searchResult.Item != null)
                                  .Select(searchResult => new SearchFeedsModel()
                                                              {
                                                                  Name = searchResult.Title,
                                                                  Description = searchResult.Description,
                                                                  Link = searchResult.Url.ToString(),
                                                                  ImageUrl = searchResult.ImageUrl
                                                              }).ToList();
        }

        /// <summary>
        /// The create query.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="IQuery"/>.
        /// </returns>
        private IQuery CreateQuery(SearchQuery query)
        {
            return this.QueryRepository.Get(query);
        }
    }
}

