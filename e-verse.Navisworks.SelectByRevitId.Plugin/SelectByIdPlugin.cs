using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using EVerse.Navisworks.SelectByRevitId.Common.Application;
using EVerse.Navisworks.SelectByRevitId.Plugin.Utils;

namespace EVerse.Navisworks.SelectByRevitId.Plugin
{
    [Plugin("SelectByRevitId", IdentityInformation.DeveloperID, ToolTip = "Pris - Select by ID", DisplayName = "Pris - Select by ID")]
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