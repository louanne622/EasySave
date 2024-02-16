using System;
using System.IO;
using System.Text.Json;

namespace EasySaveConsol_2
{
    class VMWorkspace
    {
        private ViewConsole objUIConsole;
        public Save[] listSaves;
        public StateSave[] listeStatesSave;
        public DailyLog objDailyLog;
        public VMWorkspace()
        {
            this.objUIConsole = new ViewConsole();
            this.setListSave();
            this.setListStateSave();
            this.objDailyLog = new DailyLog();
        }
        public void setListSave()
        {
            this.listSaves = Json.getSavesFromJson();
        }
        public void setListStateSave()
        {
            this.listeStatesSave = Json.getStateSavesFromJson();
        }
        public void setLang(string input)
        {
            this.objUIConsole.setLang(input);
        }
        public void setExtension(string input)
        {
            this.objUIConsole.setExtension(input);
        }
        public string getExtension()
        {
            return this.objUIConsole.getExtension();
        }
        public void ConsoleWriteDataString(string input)
        {
            this.objUIConsole.getDataString(input);
        }
        private bool VerifFilesExiste(Save _save)
        {
            return (Directory.Exists(_save.FilesSource) && Directory.Exists(_save.FilesTarget));
        }
        public void TransferSave(Save _save, Transfer _transfer, StateSave _stateSave)
        {
            /*
             * After verification of the Paths of the save if they exists
             * We transfer with the type of the save
             */
            if (!VerifFilesExiste(_save)) return;
            _transfer.setFilesFilesList(_save);
            _stateSave.SetStateSave(_save);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"Log\StateLog\StateLog.json", JsonSerializer.Serialize(this.listeStatesSave, new JsonSerializerOptions { WriteIndented = true }));
            switch (_save.Type)
            {
                case "C":
                    _transfer.TransferCom(_save, _stateSave, this.listeStatesSave);
                    break;
                case "S":
                    _transfer.TransferSeq(_save, _stateSave, this.listeStatesSave);
                    break;
            }

        }
        public void getSaveData(Save _save)
        {
            this.objUIConsole.getSaveData(_save);
        }
    }
}