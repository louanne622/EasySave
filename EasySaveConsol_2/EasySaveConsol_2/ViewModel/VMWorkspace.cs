using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveConsol_2
{
    class VMWorkspace
    {
        private ViewConsole objUIConsole;
        public VMWorkspace()
        {
            this.objUIConsole = new ViewConsole();
        }
        public void setLang(string input)
        {
            this.objUIConsole.setLang(input);
        }
        public void ConsoleWriteDataString(string input)
        {
            this.objUIConsole.getDataString(input);
        }
    }
}
