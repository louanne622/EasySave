using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace EasySaveV2._0
{
        class Json
        {
            static private string savesFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Saves\Saves.json";

            static public Save[] getSavesFromJson()
            {
                if (File.Exists(savesFilePath))
                {
                    string jsonString = File.ReadAllText(savesFilePath);
                    return JsonSerializer.Deserialize<Save[]>(jsonString);
                }
                else
                {
                    return new Save[0];
                }
            }

            static public void AddSaveToJson(Save newSave)
            {
                Save[] saves = getSavesFromJson();
                List<Save> saveList = new List<Save>(saves);
                saveList.Add(newSave);
                string jsonString = JsonSerializer.Serialize(saveList.ToArray(), new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(savesFilePath, jsonString);
            }

            static public void EditSaveName(Save _save, string input)
            {
                _save.saveName = input;
                UpdateSaveInJson(_save);
            }

            static public void EditSaveSource(Save _save, string input)
            {
                _save.sourcePath = input;
                UpdateSaveInJson(_save);
            }

            static public void EditSaveTarget(Save _save, string input)
            {
                _save.targetPath = input;
                UpdateSaveInJson(_save);
            }

            static public void EditSaveType(Save _save, string input)
            {
                _save.fileType = input;
                UpdateSaveInJson(_save);
            }

            static public void UpdateSaveInJson(Save _save)
            {
                Save[] saves = getSavesFromJson();
                List<Save> saveList = new List<Save>(saves);
                int index = saveList.FindIndex(x => x.saveName == _save.saveName);
                if (index != -1)
                {
                    saveList[index] = _save;
                    string jsonString = JsonSerializer.Serialize(saveList.ToArray(), new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(savesFilePath, jsonString);
                }
                else
                {
                    Console.WriteLine("Save not found.");
                }
            }

            static public void ResetSave(Save _save)
            {
                _save.saveName = "";
                _save.sourcePath = "";
                _save.targetPath = "";
                _save.fileType = "";
                UpdateSaveInJson(_save);
            }
        }
    }
