using Autodesk.Navisworks.Api.Plugins;
using EVerse.Navisworks.Plugin.Common.Application;
using EVerse.Navisworks.Plugin.Common.Utils;
using EVerse.Navisworks.Plugin.RevitId;
using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace EVerse.Navisworks.Plugin.Common
{
    [Plugin("SelectByRevitIdRibbon", IdentityInformation.DeveloperID, DisplayName = "Select by revit ID")]
    [RibbonLayout("PluginRibbon.xaml")]
    [RibbonTab("SelectByRevitId")]
    [Command("SelectByRevitId", LargeIcon = "RID_32.jpg", ToolTip = "Select by revit ID", DisplayName = "Select by revit ID")]
    class PluginRibbon : CommonCommandHandlerPlugin
    {
        public override int ExecuteCommand(string name, params string[] parameters)
        {
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pluginFileName = directoryName + $"\\{Assembly.GetExecutingAssembly().GetName().Name}.dll";
            Autodesk.Navisworks.Api.Application.Plugins.AddPluginAssembly(pluginFileName);
            switch (name)
            {
                case "SelectByRevitId":
                    try
                    {
                        if (!Autodesk.Navisworks.Api.Application.IsAutomated)
                        {
                            PluginBuilder pluginBuilder = new PluginBuilder("SelectByRevitId");
                            if (pluginBuilder.pluginRecord is CustomPluginRecord && pluginBuilder.pluginRecord.IsEnabled)
                            {
                                SelectByIdPlugin selectByIdPlugin = (SelectByIdPlugin)(pluginBuilder.pluginRecord.LoadedPlugin ?? pluginBuilder.pluginRecord.LoadPlugin());
                                selectByIdPlugin.Execute();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ups, something went wrong" + Environment.NewLine + ex.Message);
                    }
                    break;
            }
            return 0;
        }
    }
}