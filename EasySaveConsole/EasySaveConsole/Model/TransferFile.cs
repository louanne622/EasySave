using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveConsole.Model
{
    class TransferFile
    {
        private string OriginPath;
        private string TargetPath;
        private void setOriginPath(string input)
        { this.OriginPath = input; }
        private void setTargetPath(string input)
        { this.TargetPath = input; }
        public string getOriginPath()
        { return this.OriginPath; }
        public string getTargetFile()
        { return this.TargetPath; }
    }
}
