using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using EVerse.Navisworks.Plugin.Common.Application;
using EVerse.Navisworks.Plugin.RevitId.Utils;

namespace EVerse.Navisworks.Plugin.RevitId
{
    [Plugin("SelectByRevitId", IdentityInformation.DeveloperID, ToolTip = "Select by ID", DisplayName = "Select by ID")]
    public class SelectByIdPlugin : CustomPlugin
    {
        public int Execute(params string[] parameters)
        {
            Tools.SelectedIds = "";
            SelectByIdWindow selectByIdWindow = new SelectByIdWindow();
            selectByIdWindow.ShowDialog();

            return 0;
        }
    }
}