using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace EasySaveV2._0
{
    public class SaveListingViewModel : VMWorkspace
    {
        private readonly ObservableCollection<SaveViewModel> _saves;

        public ObservableCollection<SaveViewModel> Saves => _saves;
        public ICommand MakeSaveCommand { get; }

        public SaveListingViewModel()
        {
            _saves = new ObservableCollection<SaveViewModel>();

            MakeSaveCommand = new NavigateCommand();

            _saves.Add(new SaveViewModel(new Save("test", "test", "test", "test")));
            _saves.Add(new SaveViewModel(new Save("test", "test", "test", "test")));
            _saves.Add(new SaveViewModel(new Save("test", "test", "test", "test")));
            _saves.Add(new SaveViewModel(new Save("test", "test", "test", "test")));
        }
    }
}
