using EVerse.Navisworks.SelectByRevitId.Plugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using WixSharp;
using WixSharp.Nsis;

namespace EVerse.Navisworks.SelectByRevitId.Installer
{
    internal class Program
    {
        private static void Main()
        {
            // Get the directory path of the solution
            // Get the directory path of the current executable
            var exeDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            // Get the solution directory path by finding the first .sln file in the parent directories
            var solutionDirectory = Directory.GetParent(exeDirectory).Parent.Parent.FullName;

            // Get the folder path by combining the solution directory path with the folder name
            var sourceFolder = Path.Combine(solutionDirectory, "e-verse.Navisworks.SelectByRevitId.bundle");

            var files = Files.FromBuildDir(@sourceFolder, ".dll|.xml|.json|.jpg|.png|.xaml|.addin");
            files.Attributes.Add("Component:SharedDllRefCount", "yes");

            var destinationDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Autodesk", "ApplicationPlugins");

            // Create the project
            var project = new ManagedProject("e-verse.Navisworks.SelectByRevitId", new Dir(@destinationDirectory, new Dir(@"e-verse.Navisworks.SelectByRevitId.bundle", files)))
            {
                GUID = new Guid("5E02B8C2-2D91-472F-98B8-559227E4FB2D"),
                Version = new Version(SelectByIdWindow.PRODUCT_VERSION),
            };

            project.ControlPanelInfo.Manufacturer = "e-verse";

            // project.ManagedUI = ManagedUI.DefaultWpf; // all stock UI dialogs

            //custom set of UI WPF dialogs
            project.ManagedUI = new ManagedUI();

            project.ManagedUI.InstallDialogs.Add<EVerse.Navisworks.SelectByRevitId.Installer.WelcomeDialog>()
                                            .Add<EVerse.Navisworks.SelectByRevitId.Installer.LicenceDialog>()
                                            .Add<EVerse.Navisworks.SelectByRevitId.Installer.ProgressDialog>()
                                            .Add<EVerse.Navisworks.SelectByRevitId.Installer.ExitDialog>();

            project.ManagedUI.ModifyDialogs.Add<EVerse.Navisworks.SelectByRevitId.Installer.MaintenanceTypeDialog>()
                                           .Add<EVerse.Navisworks.SelectByRevitId.Installer.FeaturesDialog>()
                                           .Add<EVerse.Navisworks.SelectByRevitId.Installer.ProgressDialog>()
                                           .Add<EVerse.Navisworks.SelectByRevitId.Installer.ExitDialog>();

            //project.SourceBaseDir = "<input dir path>";
            //project.OutDir = "<output dir path>";

            var msiFile = project.BuildMsi();

            var bootstrapper = new NsisBootstrapper
            {
                Primary = { FileName = msiFile },

                OutputFile = "e-verse.Navisworks.SelectByRevitId.exe",
                IconFile = "Resources\\logo.ico",

                VersionInfo = new VersionInformation("1.0.0.0")
                {
                    ProductName = "Test Application",
                    LegalCopyright = "Copyright Test company",
                    FileDescription = "Test Application",
                    FileVersion = "1.0.0",
                    CompanyName = "Test company",
                    InternalName = "setup.exe",
                    OriginalFilename = "setup.exe"
                },
            };

            bootstrapper.Build();

            //#endif
        }
    }
}