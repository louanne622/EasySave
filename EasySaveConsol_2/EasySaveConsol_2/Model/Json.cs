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

    }
}
