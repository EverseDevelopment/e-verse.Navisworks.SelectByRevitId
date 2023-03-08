using System;
using WixSharp;
using WixSharp.Nsis;

namespace EVerse.Navisworks.SelectByRevitId.Installer
{
    internal class Program
    {
        private static void Main()
        {
            string bundleDirectory = @"%AppData%\Autodesk\ApplicationPlugins\e-verse.Navisworks.SelectByRevitId.bundle";
            var sourceDirectory = @"..\e-verse.Navisworks.SelectByRevitId.bundle\";
            //var project = new ManagedProject("e -verse.Navisworks.SelectByRevitId",
            //                  new Dir(@"%AppData%\Autodesk\ApplicationPlugins\",
            //                      new Dir(@"2018",new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\e-verse.Navisworks.SelectByRevitId.addin"),new Dir(@"e-verse.Navisworks.SelectByRevitId",new Files(@"..\e-verse.Navisworks.SelectByRevitId.2018\bin\Release\*.*"))),
            //                      new Dir(@"2019",new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\e-verse.Navisworks.SelectByRevitId.addin"),new Dir(@"e-verse.Navisworks.SelectByRevitId",new Files(@"..\e-verse.Navisworks.SelectByRevitId.2019\bin\Release\*.*"))),
            //                      new Dir(@"2020",new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\e-verse.Navisworks.SelectByRevitId.addin"),new Dir(@"e-verse.Navisworks.SelectByRevitId",new Files(@"..\e-verse.Navisworks.SelectByRevitId.2020\bin\Release\*.*"))),
            //                      new Dir(@"2021",new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\e-verse.Navisworks.SelectByRevitId.addin"),new Dir(@"e-verse.Navisworks.SelectByRevitId",new Files(@"..\e-verse.Navisworks.SelectByRevitId.2021\bin\Release\*.*"))),
            //                      new Dir(@"2022",new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\e-verse.Navisworks.SelectByRevitId.addin"),new Dir(@"e-verse.Navisworks.SelectByRevitId",new Files(@"..\e-verse.Navisworks.SelectByRevitId.2022\bin\Release\*.*"))),
            //                      new Dir(@"2023",new File(@"..\e-verse.Navisworks.SelectByRevitId.Common\e-verse.Navisworks.SelectByRevitId.addin"),new Dir(@"e-verse.Navisworks.SelectByRevitId",new Files(@"..\e-verse.Navisworks.SelectByRevitId.2023\bin\Release\*.*")))
            //                      ));
            var project = new ManagedProject("e-verse.Navisworks.SelectByRevitId", new Dir(bundleDirectory, new Files(sourceDirectory))
            {
                AttributesDefinition = "Component:SharedDllRefCount=yes", // set the shared DLL ref count attribute
                                                                          // add any additional files or subdirectories to be included in the installation directory
            });
            project.GUID = new Guid("97F50AF1-8856-4A5A-BD4B-7B62A451A6F0");

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