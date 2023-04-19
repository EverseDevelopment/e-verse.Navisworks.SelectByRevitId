using Autodesk.Navisworks.Api.Plugins;
using EVerse.Navisworks.SelectByRevitId.Common.Application;
using EVerse.Navisworks.SelectByRevitId.Common.Utils;
using EVerse.Navisworks.SelectByRevitId.Plugin;
using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace EVerse.Navisworks.Plugin.Common
{
    [Plugin("SelectByRevitIdRibbon", IdentityInformation.DeveloperID, DisplayName = "Select by ID")]
    [RibbonLayout("PluginRibbon.xaml")]
    [RibbonTab("SelectByRevitId")]
    [Command("SelectByRevitId", LargeIcon = "RID_32.jpg", ToolTip = "Select by Revit ID\n\nPris is a Select by Revit ID add-in for Autodesk® Navisworks®. It allows users to easily select specific element in a Navisworks model based on its unique Revit ID.", DisplayName = "Select by ID")]
    class PluginRibbon : CommonCommandHandlerPlugin
    {
        public const string PRIS = "pris";
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

        public override bool TryShowCommandHelp(string name)
        {
            bool result = base.TryShowCommandHelp($"https://e-verse.com/{PRIS}");
            return result;
        }
    }
}