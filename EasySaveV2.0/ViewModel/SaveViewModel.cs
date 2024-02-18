using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveV2._0
{
    public class SaveViewModel : VMWorkspace
    {
        private readonly Save _save;

        public string saveName => _save.saveName;
        public string sourcePath => _save.sourcePath;
        public string targetPath => _save.targetPath;
        public string fileType => _save.fileType;

        public SaveViewModel(Save save)
        {
            _save = save;
        }
    }
}
