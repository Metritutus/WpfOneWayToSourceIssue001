namespace WpfOneWayToSourceIssue001.ViewModels
{
    public class HolderViewModel : ViewModelBase
    {
        public string ExampleViewModelProperty
        {
            get => _ExampleViewModelProperty;
            set
            {
                System.Diagnostics.Debug.WriteLine($"Supplied value: {(value != null ? $"\"{value}\"" : "null")}");
                _ExampleViewModelProperty = value;
                OnPropertyChanged();
            }
        }
        private string _ExampleViewModelProperty;

        public HolderViewModel()
        { }
    }
}
