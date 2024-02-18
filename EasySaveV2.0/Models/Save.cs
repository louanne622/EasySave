namespace EasySaveV2._0
{
    public class Save
    {
        public string saveName { get; set; }
        public string sourcePath { get; set; }
        public string targetPath { get; set; }
        public FileType FileType { get; set; }


        public Save(string saveName, string sourcePath, string targetPath, FileType fileType)
        {
            this.saveName = saveName;
            this.sourcePath = sourcePath;
            this.targetPath = targetPath;
            FileType = fileType;
        }
    }
}


