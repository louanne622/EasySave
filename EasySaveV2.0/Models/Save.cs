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

        //Creation of all the attributes and using of getter and setter
        //they are necessary for all the rest of the application we gonna use them for all part in relation with the save work
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilesSource { get; set; }
        public string FilesTarget { get; set; }
        public string Type { get; set; }
    }
}