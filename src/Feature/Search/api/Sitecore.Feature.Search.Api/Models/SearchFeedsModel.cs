// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchFeedsModel.cs" company="Redstuffy">
//   Copyright (c) Redstuffy. All rights reserved.
// </copyright>
// <summary>
//   Defines the SearchFeedsModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Feature.Search.Api.Models
{
    /// <summary>
    /// The search feeds model.
    /// </summary>
    public class SearchFeedsModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        public string Link { get; set; }
    }
}
