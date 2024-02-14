using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace EasySaveConsol_2
{
    class VMWorkspace
    {
        private ViewConsole objUIConsole;
        public Save[] listSaves;
        public VMWorkspace()
        {
            this.objUIConsole = new ViewConsole();
            this.setListSave();
        }
        public void setListSave()
        {
            this.listSaves = Json.getSavesFromJson();
        }
        public void setLang(string input)
        {
            this.objUIConsole.setLang(input);
        }
        public void ConsoleWriteDataString(string input)
        {
            this.objUIConsole.getDataString(input);
        }
        private bool VerifFilesExiste(Save _save)
        {
            return (Directory.Exists(_save.FilesSource) && Directory.Exists(_save.FilesTarget));
        }
        public void TransferSave(Save _save, Transfer _transfer)
        {
            /*
             * After verification of the Paths of the save if they exists
             * We transfer with the type of the save
             */
            if (!VerifFilesExiste(_save)) return;
            _transfer.setFilesFilesList(_save);
            switch (_save.Type)
            {
                case "C":
                    _transfer.TransferCom(_save);
                    break;
                case "S":
                    _transfer.TransferSeq(_save);
                    break;
            }

        }
        public void getSaveData(Save _save)
        {
            this.objUIConsole.getSaveData(_save);
        }
    }
}