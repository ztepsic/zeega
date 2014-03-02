using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zeega.Web.Models {
    /// <summary>
    /// Each leaderboard contains metadata to describe how the score should be tracked and displayed.
    /// The Bridge will supply the meta data for game leaderboards each time a score is submitted.
    /// It is up to the publisher to store this metadata in order to properly display leaderboards on their site.
    /// </summary>
    public class MochiLeaderboardMetadata {

        /// <summary>
        /// Unique Id of the game the leaderboard belongs to
        /// </summary>
        public string GameId { get; set; }

        /// <summary>
        /// Unique Id of the leaderboard
        /// </summary>
        public string BoardId { get; set; }

        /// <summary>
        /// Title of the leaderboard
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Text decription of the leaderboard (optionally supplied)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Value indicationg the type of score. Values are either "number" or "time".
        /// Note: time is supplied in milliseconds
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// Value indicationg the sort direction of the scores.
        /// Values are either "asc" or "desc"
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// Label to indicate what the score represents.
        /// Ex: "Track time", "Gems" or "Points"
        /// </summary>
        public string ScoreLabel { get; set; }

    }
}