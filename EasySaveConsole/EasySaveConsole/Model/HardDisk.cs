﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace EasySaveConsole.Model
{
    class HardDisk
    {
        private string[] ListeHardDisk;
        public HardDisk()
        {
            setListeHardDisk();
        }
        public string[] getListHardDisk() { return this.ListeHardDisk; }
        private void setListeHardDisk()
        {
            // We retrieve the information of our Hard Disks (Name)
            // And store them in the variable "ListHardDisk"
            DriveInfo[] drives = DriveInfo.GetDrives();
            ListeHardDisk = new string[drives.Length];
            for (int i = 0; i < drives.Length; i++)
            {
                ListeHardDisk[i] = drives[i].Name;
            }
        }
    }
}
