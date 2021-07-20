using Microsoft.Xaml.Behaviors.Core;
using System.Windows.Input;

namespace WpfOneWayToSourceIssue001.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public HolderViewModel Holder
        {
            get => _Holder;
            set
            {
                _Holder = value;
                OnPropertyChanged();
            }

        }
        private HolderViewModel _Holder;

        public ICommand TestCommand { get; }

        public MainViewModel()
        {
            TestCommand = new ActionCommand(() => HandleTestCommand());
        }

        private void HandleTestCommand()
        {
            if (Holder == null)
            {
                Holder = new HolderViewModel();
            }
            else
            {
                Holder = null;
            }
        }
    }
}
