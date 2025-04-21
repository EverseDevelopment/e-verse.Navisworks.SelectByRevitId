using EVerse.Navisworks.SelectByRevitId.Plugin;
using Microsoft.Deployment.WindowsInstaller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using WixSharp;
using File = WixSharp.File;

namespace EVerse.Navisworks.SelectByRevitId.Installer
{
    internal class Program
    {
        public static string versionValue = "0.0.0";
        private static void Main()
        {
            var project = new ManagedProject("e-verse.Navisworks.SelectByRevitId",
                                new Dir(@"%CommonAppDataFolder%\Autodesk\ApplicationPlugins",
                                    new Dir(@"e-verse.Navisworks.SelectByRevitId.bundle",
                                        new WixSharp.File(@"..\e-verse.Navisworks.SelectByRevitId.Common\PackageContents.xml"),
                                            new Dir(@"Contents",
                                                new Dir(@"dlls",
                                                    new Dir(@"2018",
                                                        new Files(@"..\e-verse.Navisworks.SelectByRevitId.2018\bin\Release\*.dll"),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.2018\bin\Release\Pris.SelectByRevitId.dll.config",
                                                            new FilePermission("Everyone", GenericPermission.All)),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\e-verse.Navisworks.SelectByRevitId.addin"),
                                                        new Dir(@"en-US",
                                                            new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\en-US\PluginRibbon.xaml")),
                                                        new Dir(@"Images",
                                                            new Files(@"..\e-verse.Navisworks.SelectByRevitId.Common\Images\*.*"))),
                                                    new Dir(@"2019",
                                                        new Files(@"..\e-verse.Navisworks.SelectByRevitId.2019\bin\Release\*.dll"),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.2019\bin\Release\Pris.SelectByRevitId.dll.config",
                                                            new FilePermission("Everyone", GenericPermission.All)),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\e-verse.Navisworks.SelectByRevitId.addin"),
                                                        new Dir(@"en-US",
                                                            new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\en-US\PluginRibbon.xaml")),
                                                        new Dir(@"Images",
                                                            new Files(@"..\e-verse.Navisworks.SelectByRevitId.Common\Images\*.*"))),
                                                    new Dir(@"2020",
                                                        new Files(@"..\e-verse.Navisworks.SelectByRevitId.2020\bin\Release\*.dll"),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.2020\bin\Release\Pris.SelectByRevitId.dll.config",
                                                            new FilePermission("Everyone", GenericPermission.All)),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\e-verse.Navisworks.SelectByRevitId.addin"),
                                                            new Dir(@"en-US",
                                                                new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\en-US\PluginRibbon.xaml")),
                                                            new Dir(@"Images",
                                                                new Files(@"..\e-verse.Navisworks.SelectByRevitId.Common\Images\*.*"))),
                                                    new Dir(@"2021",
                                                        new Files(@"..\e-verse.Navisworks.SelectByRevitId.2021\bin\Release\*.dll"),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.2021\bin\Release\Pris.SelectByRevitId.dll.config",
                                                            new FilePermission("Everyone", GenericPermission.All)),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\e-verse.Navisworks.SelectByRevitId.addin"),
                                                        new Dir(@"en-US",
                                                            new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\en-US\PluginRibbon.xaml")),
                                                        new Dir(@"Images",
                                                            new Files(@"..\e-verse.Navisworks.SelectByRevitId.Common\Images\*.*"))),
                                                    new Dir(@"2022",
                                                        new Files(@"..\e-verse.Navisworks.SelectByRevitId.2022\bin\Release\*.dll"),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.2022\bin\Release\Pris.SelectByRevitId.dll.config",
                                                            new FilePermission("Everyone", GenericPermission.All)),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\e-verse.Navisworks.SelectByRevitId.addin"),
                                                        new Dir(@"en-US",
                                                            new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\en-US\PluginRibbon.xaml")),
                                                        new Dir(@"Images",
                                                            new Files(@"..\e-verse.Navisworks.SelectByRevitId.Common\Images\*.*"))),
                                                    new Dir(@"2023",
                                                        new Files(@"..\e-verse.Navisworks.SelectByRevitId.2023\bin\Release\*.dll"),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.2023\bin\Release\Pris.SelectByRevitId.dll.config",
                                                            new FilePermission("Everyone", GenericPermission.All)),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\e-verse.Navisworks.SelectByRevitId.addin"),
                                                        new Dir(@"en-US",
                                                            new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\en-US\PluginRibbon.xaml")),
                                                        new Dir(@"Images",
                                                            new Files(@"..\e-verse.Navisworks.SelectByRevitId.Common\Images\*.*"))),
                                                    new Dir(@"2024",
                                                        new Files(@"..\e-verse.Navisworks.SelectByRevitId.2024\bin\Release\*.dll"),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.2024\bin\Release\Pris.SelectByRevitId.dll.config",
                                                            new FilePermission("Everyone", GenericPermission.All)),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\e-verse.Navisworks.SelectByRevitId.addin"),
                                                        new Dir(@"en-US",
                                                            new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\en-US\PluginRibbon.xaml")),
                                                        new Dir(@"Images",
                                                            new Files(@"..\e-verse.Navisworks.SelectByRevitId.Common\Images\*.*"))),
                                                    new Dir(@"2025",
                                                        new Files(@"..\e-verse.Navisworks.SelectByRevitId.2025\bin\Release\*.dll"),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.2025\bin\Release\Pris.SelectByRevitId.dll.config",
                                                            new FilePermission("Everyone", GenericPermission.All)),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\e-verse.Navisworks.SelectByRevitId.addin"),
                                                        new Dir(@"en-US",
                                                            new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\en-US\PluginRibbon.xaml")),
                                                        new Dir(@"Images",
                                                            new Files(@"..\e-verse.Navisworks.SelectByRevitId.Common\Images\*.*"))),
                                                    new Dir(@"2026",
                                                        new Files(@"..\e-verse.Navisworks.SelectByRevitId.2026\bin\Release\*.dll"),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.2026\bin\Release\Pris.SelectByRevitId.dll.config",
                                                            new FilePermission("Everyone", GenericPermission.All)),
                                                        new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\e-verse.Navisworks.SelectByRevitId.addin"),
                                                        new Dir(@"en-US",
                                                            new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\en-US\PluginRibbon.xaml")),
                                                        new Dir(@"Images",
                                                            new Files(@"..\e-verse.Navisworks.SelectByRevitId.Common\Images\*.*")))
                                )))));

            project.GUID = new Guid("5E02B8C2-2D91-472F-98B8-559227E4FB2D");
            project.Version = new Version(versionValue);
            project.ControlPanelInfo.Manufacturer = "e-verse";
            project.ControlPanelInfo.ProductIcon = "Resources\\logo.ico";

            project.ManagedUI = new ManagedUI();

            project.ManagedUI.InstallDialogs.Add<EVerse.Navisworks.SelectByRevitId.Installer.WelcomeDialog>()
                                            .Add<EVerse.Navisworks.SelectByRevitId.Installer.LicenceDialog>()
                                            .Add<EVerse.Navisworks.SelectByRevitId.Installer.ProgressDialog>()
                                            .Add<EVerse.Navisworks.SelectByRevitId.Installer.ExitDialog>();

            project.ManagedUI.ModifyDialogs.Add<EVerse.Navisworks.SelectByRevitId.Installer.MaintenanceTypeDialog>()
                                           .Add<EVerse.Navisworks.SelectByRevitId.Installer.FeaturesDialog>()
                                           .Add<EVerse.Navisworks.SelectByRevitId.Installer.ProgressDialog>()
                                           .Add<EVerse.Navisworks.SelectByRevitId.Installer.ExitDialog>();

            project.MajorUpgrade = new MajorUpgrade
            {
                AllowDowngrades = false,
                AllowSameVersionUpgrades = true,
                DowngradeErrorMessage = "A newer version of your product is already installed.",
                IgnoreRemoveFailure = true,
                Schedule = UpgradeSchedule.afterInstallInitialize
            };

            project.Actions = new WixSharp.Action[]
            {
                new ManagedAction(CustomActions.CheckNavisProcess, Return.check, When.Before, Step.LaunchConditions, Condition.NOT_Installed)
            };

            var msiFile = project.BuildMsi();
        }
    }

    public class CustomActions
    {
        [CustomAction]
        public static ActionResult CheckNavisProcess(Session session)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName("Navisworks");
                if (processes.Length > 0)
                {
                    var result = MessageBox.Show("Navisworks is currently running. Would you like to close it to continue with the installation?", "Revit is running", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        foreach (var process in processes)
                        {
                            process.Kill();
                            process.WaitForExit();
                        }

                        string basePath = Environment.ExpandEnvironmentVariables("%ProgramData%\\Autodesk\\ApplicationPlugins\\e-verse.Navisworks.SelectByRevitId.bundle\\Contents\\dlls");
                        List<string> filePaths = new List<string>();

                        for (int year = 2018; year <= 2026; year++)
                        {
                            string filePath = $"{basePath}\\{year}\\Leia_glTF_Exporter.dll";
                            bool overwrittable = WaitForFilesToBeOverwritable(filePath);
                            if (!overwrittable)
                            {
                                MessageBox.Show($"The file Select By Id {year} is still in use", "Warning");
                                return ActionResult.Failure;
                            }
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        return ActionResult.UserExit;
                    }
                    else
                    {
                        return ActionResult.Failure;
                    }
                }
            }
            catch (Exception ex)
            {
                session.Log("Error checking Revit process: " + ex.Message);
                return ActionResult.Failure;
            }
            return ActionResult.Success;
        }

        public static bool WaitForFilesToBeOverwritable(string filePath, int waitTimeMilliseconds = 1000, int maxAttempts = 10)
        {
            int attempts = 0;
            while (IsFileInUse(filePath) && attempts < maxAttempts)
            {
                Thread.Sleep(waitTimeMilliseconds);
                attempts++;
            }

            return attempts < maxAttempts;
        }

        public static bool IsFileInUse(string filePath)
        {
            try
            {
                using (FileStream stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return false;
                }
            }
            catch (IOException)
            {
                return true;
            }
        }
    }
}
