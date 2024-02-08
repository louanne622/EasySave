using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using EasySaveConsole.Model;

namespace EasySaveConsole.Model
{
    class Json
    {
        //initialisation of our methods enabling attributes to be used
        public Save[] getJsonData(string _path)
        {
            string json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<Save[]>(json);
        }
        public void UpdateJsonName(Save _save, string input)
        {
            _save.Name = input;
        }
        public void UpdateJsonFileSource(Save _save, string input)
        {
            _save.FilesSource = input;
        }
        public void UpdateJsonFileTarget(Save _save, string input)
        {
            _save.FilesTarget = input;
        }
        public void UpdateJsonType(Save _save, string input)
        {
            _save.Type = input;
        }
        public void DeleteJsonSaveData(Save _save)
        {
            _save.Name = "";
            _save.FilesSource = "";
            _save.FilesTarget = "";
            _save.Type = "";
        }
    }
}
