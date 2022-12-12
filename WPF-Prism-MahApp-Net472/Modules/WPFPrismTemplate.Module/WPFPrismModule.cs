using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace WPFPrismTemplate.Module
{
    public class MyModule : IModule
    {
        private readonly IRegionManager regionManager;

        public MyModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //register services, especially if just used in this module
            //containerRegistry.RegisterSingleton<IMyService, MyService>();

            //register views for navigating
            //containerRegistry.RegisterForNavigation<MySearchView>();

            //register dialogs for IDialogService
            //containerRegistry.RegisterDialog<RandomDialogView, RandomDialogViewModel>();

            //register views with regions
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(MyView));
        }
    }
}