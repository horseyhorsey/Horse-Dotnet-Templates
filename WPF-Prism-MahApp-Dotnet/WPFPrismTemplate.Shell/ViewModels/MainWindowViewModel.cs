using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace WPFPrismTemplate.Shell.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;
        private IRegionManager _regionManager;
        private string _title = nameof(MainWindowViewModel);

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

            NavigateCommand = new DelegateCommand<string>(Navigate);
            ShowFlyoutCommand = new DelegateCommand<string>(ShowFlyout);
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand<string> ShowFlyoutCommand { get; private set; }

        private void ShowFlyout(string showFlyout)
        {
            if (!_isAboutOpen)
            {
                IsAboutOpen = true;
            }                
        }

        private bool _isAboutOpen;
        public bool IsAboutOpen
        {
            get { return _isAboutOpen; }
            set { SetProperty(ref _isAboutOpen, value); }
        }

        #region Methods
        private void Navigate(string uri)
        {
            switch (uri)
            {
                case "":                    
                default:
                    break;
            }

            //_regionManager.RequestNavigate(RegionNames.ContentRegion, uri);

            //if (uri == "MasterDatabaseView")
            //{                
            //    _eventAggregator.GetEvent<DisableControlsEvent>().Publish(false);                
            //}
            //else
            //    _eventAggregator.GetEvent<DisableControlsEvent>().Publish(true);

            //
        }
        #endregion

    }
}
