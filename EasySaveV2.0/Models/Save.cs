namespace EasySaveV2._0
{
    class Save
    {
        private string saveName;
        private string sourcePath;
        private string targetPath;
        private string fileType;

        public Save(string saveName, string sourcePath, string targetPath, string fileType)
        {
            this.saveName = saveName;
            this.sourcePath = sourcePath;
            this.targetPath = targetPath;
            this.fileType = fileType;
        }


        public string SaveName => GetSaveName();
        public string SourcePath => GetSourcePath();
        public string TargetPath => GetTargetPath();
        public string FileType => GetFileType();

        private string GetSaveName()
        {
            return saveName;
        }

        private string GetSourcePath()
        {
            return sourcePath;
        }

        private string GetTargetPath()
        {
            return targetPath;
        }

        private string GetFileType()
        {
            return fileType;
        }
    }
}
