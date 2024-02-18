namespace EasySaveV2._0
{
    public class Save
    {
        public string saveName { get; }
        public string sourcePath { get; }
        public string targetPath { get; }
        public string fileType { get; }


        public Save(string saveName, string sourcePath, string targetPath, string fileType)
        {
            this.saveName = saveName;
            this.sourcePath = sourcePath;
            this.targetPath = targetPath;
            this.fileType = fileType;
        }
    }
}
