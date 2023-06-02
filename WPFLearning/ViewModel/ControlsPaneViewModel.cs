using WPFLearning.Model;
using WPFLearning.MVVM;

namespace WPFLearning.ViewModel
{
    internal class ControlsPaneViewModel : ViewModelBase
    {
        public ControlsPaneViewModel()
        {
            
        }

        private ControlsSettings settings;

        public ControlsSettings Settings
        {
            get { return settings; }
            set
            {
                settings = value;
                OnPropertyChanged();
            }
        }
    }
}
