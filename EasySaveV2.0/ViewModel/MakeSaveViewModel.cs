using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EasySaveV2._0
{
    public class MakeSaveViewModel : VMWorkspace
    {
        private string _saveName;
        public string SaveName
        {
            get
            {
                return _saveName;
            }
            set
            {
                _saveName = value;
                OnPropertyChanged(nameof(SaveName));
            }
        }

        private string _sourcePath;
        public string SourcePath
        {
            get
            {
                return _sourcePath;
            }
            set
            {
                _sourcePath = value;
                OnPropertyChanged(nameof(SourcePath));
            }
        }

        private string _targetPath;
        public string TargetPath
        {
            get
            {
                return _targetPath;
            }
            set
            {
                _targetPath = value;
                OnPropertyChanged(nameof(TargetPath));
            }
        }

        private string _fileType;
        public string FileType
        {
            get
            {
                return _fileType;
            }
            set
            {
                _fileType = value;
                OnPropertyChanged(nameof(FileType));
            }
        }

        public ICommand SubmitCommand { get; }

        public MakeSaveViewModel()
        {
            SubmitCommand = new MakeSaveCommand(this);
        }
    }
}
