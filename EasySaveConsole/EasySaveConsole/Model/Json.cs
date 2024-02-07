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
        public Save[] getJsonData(string _path)
        {
            string json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<Save[]>(json);
        }
    }
}
