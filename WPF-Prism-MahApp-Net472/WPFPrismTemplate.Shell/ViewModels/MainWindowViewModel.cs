using Prism.Mvvm;
using PropertyChanged;

namespace WPFPrismTemplate.Shell.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainWindowViewModel : BindableBase
    {
        public string Title { get; set; } = "WPFPrismTemplate.Shell";

        public MainWindowViewModel() { }
    }
}