using Zed.Web.Models;

namespace Zeega.Admin.Web.Models {
    public class PageViewModel {

        #region Fields and Properties

        public PageInfoModel PageInfoModel { get; set; }

        public BreadcrumbsModel BreadcrumbsModel { get; set; }

        private readonly SidebarViewModel sidebarViewModel = new SidebarViewModel();

        public SidebarViewModel SidebarViewModel { get { return sidebarViewModel; }}

        public string Title { get; set; }
        public string TitleDescription { get; set; }

        #endregion

        #region Constructors and Init

        public PageViewModel() {
            BreadcrumbsModel = new BreadcrumbsModel();
            PageInfoModel = new PageInfoModel("Zeega");
        }

        #endregion

        #region Methods
        #endregion
    }
}