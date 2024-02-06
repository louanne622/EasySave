using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace EasySaveConsole.Model
{
    class HardDisk
    {
        /*  ATTRIBUTS  */
        private string[] ListeHardDisk;
        /*  CONSTRUCTOR  */
        public HardDisk()
        {
            setListeHardDisk();
        }
        /*  METHODES  */
        public string[] getListHardDisk() { return this.ListeHardDisk; }
        private void setListeHardDisk()
        {
            // On récupères les infos de nos Disques Durs (Nom)
            // Et on les stock dans la variable ListeHardDisk
            DriveInfo[] drives = DriveInfo.GetDrives();
            ListeHardDisk = new string[drives.Length];
            for (int i = 0; i < drives.Length; i++)
            {
                ListeHardDisk[i] = drives[i].Name;
            }
        }
    }
}
