using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;

namespace EasySaveConsol_2
{
    class Json
    {
        static public Save[] getSavesFromJson()
        {
            return JsonSerializer.Deserialize<Save[]>
                (File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Saves\Saves.json"));
        }
        static public StateSave[] getStateSavesFromJson()
        {
            return JsonSerializer.Deserialize<StateSave[]>
                (File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Log\StateLog\StateLog.json"));
        }
        static public void EditSaveName(Save _save, string input)
        {
            _save.Name = input;
        }
        static public void EditSaveSource(Save _save, string input)
        {
            _save.FilesSource = input;
        }
        static public void EditSaveTarget(Save _save, string input)
        {
            _save.FilesTarget = input;
        }
        static public void EditSaveType(Save _save, string input)
        {
            _save.Type = input;
        }
        static public void EditSavesInJson(Save[] _saves)
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"Saves\Saves.json", 
                JsonSerializer.Serialize(_saves, new JsonSerializerOptions { WriteIndented = true }));
        }
        static public void ResetSave(Save _save)
        {
            _save.Name = "";
            _save.FilesSource = "";
            _save.FilesTarget = "";
            _save.Type = "";
        }
       
    }
}
