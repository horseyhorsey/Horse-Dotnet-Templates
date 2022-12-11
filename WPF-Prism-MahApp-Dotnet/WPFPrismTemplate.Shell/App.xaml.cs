using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using WPFPrismTemplate.Module;
using WPFPrismTemplate.Shell.Views;

namespace WPFPrismTemplate.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// Load prism modules from here
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule(typeof(MyModule));
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
        }

        protected override Window CreateShell() => Container.Resolve<MainWindow>();

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //todo service
        }

        /// <summary>
        /// UnhandledExceptions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrismApplication_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if (!e.Exception.Message.Contains("Prism.Mvvm.ViewModelLocator.AutoWireViewModel"))
            {
                MessageBox.Show(e.Exception.ToString());
                var result = MessageBox.Show("Shutdown Application?", "", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No)
                    e.Handled = true;
            }
        }
    }
}
