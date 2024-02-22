namespace EasySaveV2._0
{
    public class Save
    {
        public string saveName { get; set; }
        public string sourcePath { get; set; }
        public string targetPath { get; set; }

        private FileType fileType;

        public string FileTypeAsString => FileType.ToString();

        public FileType FileType
        {
            get { return fileType; }
            set { fileType = value; }
        }

        public Save(string saveName, string sourcePath, string targetPath, FileType _fileType)
        {
            this.saveName = saveName;
            this.sourcePath = sourcePath;
            this.targetPath = targetPath;
            this.fileType = _fileType;
        }
    }
}


