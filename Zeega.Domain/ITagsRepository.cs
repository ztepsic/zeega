﻿using System.Collections.Generic;
using Zed.Core.Domain;

namespace Zeega.Domain {
    /// <summary>
    /// Tags repository interface
    /// </summary>
    public interface ITagsRepository : ICrudRepository<Tag> {
        /// <summary>
        /// Gets tags in particular language for provided tags
        /// </summary>
        /// <param name="tags">Tags in other language</param>
        /// <param name="languageCode">Language for which we want tags</param>
        /// <returns>Tags in particular language if they exists, otherwise empty collection</returns>
        IEnumerable<Tag> GetTagsFor(IList<Tag> tags, LanguageCode languageCode);
    }
}
