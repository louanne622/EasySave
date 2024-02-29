/*
 * 
 * This class is used to store the saves and to make a list of them later
 * 
 */

namespace EasySaveV3._0.Models
{
    public class Save
    {
        public string Name { get; set; }
        public string FilesSource { get; set; }
        public string FilesTarget { get; set; }
        public Save() { }
        public Save(string saveName, string sourcePath, string targetPath)
        {
            this.Name = saveName;
            this.FilesSource = sourcePath;
            this.FilesTarget = targetPath;
        }
    }
}
