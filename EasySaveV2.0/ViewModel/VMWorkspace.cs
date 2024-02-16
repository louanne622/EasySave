using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Input;

namespace EasySaveV2._0
{
    class VMWorkspace
    {
        public List<Save> listSaves;

        public VMWorkspace()
        {
            this.listSaves = new List<Save>();
            EditCommand = new RelayCommand();
        }

        public ICommand EditCommand { get; }

        

        public void AddSave(Save save)
        {
            this.listSaves.Add(save);
        }
    }
}
