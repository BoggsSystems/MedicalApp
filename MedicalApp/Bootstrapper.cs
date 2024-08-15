using NoahMedical.Core.Services;
using Prism.Unity;
using System.Windows;
using Unity;

namespace MedicalApp
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            // Here you can add modules if your application is large and requires modular architecture
            // var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            // moduleCatalog.AddModule(typeof(YourModule));
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // Register your types with Unity
            Container.RegisterType<IScreenManager, ScreenManager>();
            // More services and types as needed
        }
    }
}
