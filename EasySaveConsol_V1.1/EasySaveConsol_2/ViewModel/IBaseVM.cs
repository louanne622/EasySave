﻿using System;

namespace EasySaveConsol_2
{
    class IBaseVM : IDisposable
    {
        public void Dispose()
        {
            
        }
        public VMWorkspace objWorkspace;
        public Transfer objTransfer;
        public IBaseVM()
        {
            this.objWorkspace = new VMWorkspace();
            this.objTransfer = new Transfer();
        }
    }
}
