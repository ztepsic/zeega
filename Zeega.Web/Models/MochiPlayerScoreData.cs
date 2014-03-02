using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zeega.Web.Models {
    public class MochiPlayerScoreData {

        /// <summary>
        /// Authentication Data
        /// </summary>
        public string Signature { get; set; }

        public MochiScoreInformation MochiScoreInformation { get; set; }

        public MochiLeaderboardMetadata MochiLeaderboardMetadata { get; set; }

    }
}