namespace Zeega.Admin.Web.Models {
    public class SidebarViewModel {

        public enum Section {
            Dashboard,
            Games,
            GameInstances
        }

        private Section activeSection;


        public void SetActiveSection(Section section) { activeSection = section; }

        public bool IsActiveSection(Section section) { return activeSection == section; }

        public string GetCssClassIfActiveSection(string cssClass, Section section) {
            return IsActiveSection(section) ? cssClass : string.Empty;
        }


    }
}