using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveConsol_2
{
    class BaseVM : IDisposable
    {
        public void Dispose()
        {
            
        }
        public VMWorkspace objWprkspace;
        public BaseVM()
        {
            this.objWprkspace = new VMWorkspace();
        }
        
    }
}
