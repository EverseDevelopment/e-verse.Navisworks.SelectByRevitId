using Autodesk.Navisworks.Api.Plugins;
using EVerse.Navisworks.SelectByRevitId.Common.Application;
using EVerse.Navisworks.SelectByRevitId.Plugin.Utils;


namespace EVerse.Navisworks.SelectByRevitId.Plugin
{
    [Plugin("SelectByRevitId", IdentityInformation.DeveloperID, ToolTip = "Select by revit element ID", DisplayName = "Pris")]
    public class SelectByIdPlugin : CustomPlugin
    {
        public int Execute(params string[] parameters)
        {
            Tools.SelectedIds = "";

            if (!Tools.IsRevitModelLoaded())
            {
                MessageWindow.Show("Warning", "You don't have a Revit model loaded, please load one");
            }
            else
            {
                SelectByIdWindow selectByIdWindow = new SelectByIdWindow();
                selectByIdWindow.ShowDialog();
            }

            return 0;
        }
    }
}