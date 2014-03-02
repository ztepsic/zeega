using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zeega.Web.Models {
    /// <summary>
    /// Scoring information of player score in Mochi Game
    /// </summary>
    public class MochiScoreInformation {

        /// <summary>
        /// "Score" will be passed here. This is used to filter score submissions.
        /// </summary>
        public string Submission { get; set; }

        /// <summary>
        /// Unique ID of the logged-in player. This will be what you supplied in the embed parameters.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Username the user input for the score.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Username you supplied in the embed parameters
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Returned Id provided through the embed parameters to identify the unique user playing the game.
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Integer indicationg the score the player is submitting
        /// </summary>
        public string Score { get; set; }

    }
}