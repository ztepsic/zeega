using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zeega.Web.Models {
    /// <summary>
    /// Medal information
    /// </summary>
    public class MochiPlayerAwardsData {

        /// <summary>
        /// Authentication Data
        /// </summary>
        public string Signature { get; set; }

        #region Award Information

        /// <summary>
        /// "medal" will be passed here. This is used to filter medal submissions.
        /// </summary>
        public string Submission { get; set; }

        /// <summary>
        /// Plain text  name of the medal achieved
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This value will be "leaderboards" in the case of a leaderboad medal
        /// and "ingame" for an achievement
        ///  </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Plain text description of the award achieved
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Fully qualified URL to a 64x64 pixel image of the award
        /// </summary>
        public string Thumbnail { get; set; }

        /// <summary>
        /// Unique Id of the game that this award is associated with
        /// </summary>
        public string GameId { get; set; }

        /// <summary>
        /// Unique Id of the logged-in player. This will be what you supplied in the embed parameters.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Username of the player. This will be what you supplied in the embed parameters
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Returned Id provided through the embed parameters to identify the unique user playing the game,
        /// </summary>
        public string SessionId { get; set; }

        #endregion
    }
}