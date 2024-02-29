using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveV3._0.Models
{
    public class SettingsModel
    {
        public string Language { get; set; }
        public string LogFilePath { get; set; }
        public string EncryptedExtensions { get; set; }
        public string LogExtension { get; set; }
        public string PriorityFiles { get; set; }
        public int MaxSizeFile { get; set; }

    }
}
