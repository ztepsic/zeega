using Zed.Domain;
using Zeega.Domain.GameModel;

namespace Zeega.Domain.GameProviders {
    public class GamesImport : Entity {

        #region Fields and Properties

        private readonly GameProvider gameProvider;

        public virtual GameProvider GameProvider { get { return gameProvider; } }

        private DateTime importStartDateTimeUtc;

        public virtual DateTime ImportStartDateTimeUtc {
            get { return importStartDateTimeUtc; }
            set { importStartDateTimeUtc = value.ToUniversalTime(); }
        }

        private DateTime? importEndDateTimeUtc;

        public virtual DateTime? ImportEndDateTimeUtc {
            get { return importEndDateTimeUtc; }
            set {
                if (value.HasValue) {
                    importEndDateTimeUtc = value.Value.ToUniversalTime();
                } else {
                    importEndDateTimeUtc = null;
                }
            }
        }

        public virtual int EntriesCount { get; set; }

        public virtual bool IsProcessed { get; set; }

        #endregion

        #region Constructors and Init

        protected GamesImport() { }

        public GamesImport(GameProvider gameProvider) {
            this.gameProvider = gameProvider;
            ImportStartDateTimeUtc = DateTime.UtcNow;
            EntriesCount = 0;
            IsProcessed = false;
        }

        #endregion

        #region Methods
        #endregion

    }
}
