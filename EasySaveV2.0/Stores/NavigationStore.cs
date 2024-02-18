using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveV2._0.Stores
{
    public class NavigationStore
    {
        private VMWorkspace _currentViewModel;
        public VMWorkspace CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
            }
        }
    }
}
