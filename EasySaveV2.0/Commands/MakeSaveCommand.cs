using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveV2._0
{
    public class MakeSaveCommand : BaseCommand
    {
        private readonly MakeSaveViewModel _makeSaveViewModel;
        private readonly SaveList _saveList;

        public MakeSaveCommand(MakeSaveViewModel makeSaveViewModel)
        {
            _makeSaveViewModel = makeSaveViewModel;
        }
        public override void Execute(object parameter)
        {
            Save save = new Save(_makeSaveViewModel.SaveName, _makeSaveViewModel.SourcePath, _makeSaveViewModel.TargetPath, _makeSaveViewModel.FileType);
            _saveList.AddSave(save);
        }
    }
}
