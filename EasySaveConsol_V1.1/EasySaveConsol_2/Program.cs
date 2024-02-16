/*
 * 
 * GROUP 2 
 * -------
 * Head : Valentin LEROY
 * Members : Sebastien RICART, Lou-Anne LECOQ, Romain VASSEUR, Nathan NIGAULT
 * -------
 * Version : 1.1 
 * Interface : Console
 * Saves : 5 (static in file => no less, no more)
 * Daily log : Y
 * Status log : Y
 * Saves types : Complete or sequential
 * Stop software : N
 * Command line : Y
 * Crypto soft : N
 * 
 */

using System;
using System.Diagnostics;

namespace EasySaveConsol_2
{
    class Program
    {
        static void Main(string[] args)
        {
            IBaseVM A = new IBaseVM();
            while(true)
            {
                /* Clear the console */ Console.Clear();
                A.objWorkspace.ConsoleWriteDataString("0; 1; 2; 1; 0; 3; 4; 3; 5; 6; 7; 8; 9; 32; 3");
                Console.Write("#       ");  string choiceInterface_HomePage = Console.ReadLine();
                switch (choiceInterface_HomePage)
                {
                    /* Show the Saves for a JSON */
                    /*
                     * 
                     */
                    case "1":
                        A.objWorkspace.ConsoleWriteDataString("3; 10; 3");
                        A.objWorkspace.setListSave();
                        // Write in the console the saves
                        foreach (Save save in A.objWorkspace.listSaves)
                            A.objWorkspace.getSaveData(save);
                        A.objWorkspace.ConsoleWriteDataString("1; 3");
                        Console.ReadLine();
                        break;
                    /* Update the Saves */
                    /*
                     * 
                     */
                    case "2":
                        A.objWorkspace.ConsoleWriteDataString("3; 11; 3; 23; 29");
                        Console.Write("#       "); string id_save = Console.ReadLine();
                        int id_save2;
                        try
                        {
                             id_save2 = int.Parse(id_save);
                        } catch // In case that the customer have the right Input (a INT)
                        {
                            A.objWorkspace.ConsoleWriteDataString("1; 22; 3");
                            Console.ReadLine();
                            break;
                        }
                        if (id_save2 > 6 || id_save2 < 1)
                        {
                            A.objWorkspace.ConsoleWriteDataString("1; 22; 3");
                            Console.ReadLine();
                            break;
                        }
                        // Asking all the INPUT for updating a save
                        A.objWorkspace.ConsoleWriteDataString("24");
                        Console.Write("#       "); string nom_save = Console.ReadLine();
                        A.objWorkspace.ConsoleWriteDataString("25");
                        Console.Write("#       "); string source_save = Console.ReadLine();
                        A.objWorkspace.ConsoleWriteDataString("26");
                        Console.Write("#       "); string target_save = Console.ReadLine();
                        A.objWorkspace.ConsoleWriteDataString("27; 38");
                        Console.Write("#       "); string type_save = Console.ReadLine();
                        if (type_save != "C" && type_save != "S")
                        {
                            A.objWorkspace.ConsoleWriteDataString("1; 22; 3");
                            Console.ReadLine();
                            break;
                        }
                        // Here we change the attibute of the Save
                        // And we update the file SAVES.JSON
                        if (nom_save != "") Json.EditSaveName(A.objWorkspace.listSaves[id_save2 - 1], nom_save);
                        if (source_save != "") Json.EditSaveSource(A.objWorkspace.listSaves[id_save2 - 1], source_save);
                        if (target_save != "") Json.EditSaveTarget(A.objWorkspace.listSaves[id_save2 - 1], target_save);
                        if (type_save != "") Json.EditSaveType(A.objWorkspace.listSaves[id_save2 - 1], type_save);
                        Json.EditSavesInJson(A.objWorkspace.listSaves);
                        A.objWorkspace.ConsoleWriteDataString("1; 15; 3");
                        Console.ReadLine();
                        break;
                    /* Execute Saves */
                    /*
                     * 
                     */
                    case "3":
                        // We setup the savelist, in case that we update one before
                        A.objWorkspace.setListSave();
                        // Same for StateSave
                        A.objWorkspace.setListStateSave();
                        A.objWorkspace.ConsoleWriteDataString("3; 12; 3; 30; 31");
                        Console.Write("#       "); string id_save9 = Console.ReadLine();
                        try
                        {
                            int[] listSaveId = ClassUtility.ParseBackupNumbers(id_save9).ToArray();
                            for (int i = 0; i < listSaveId.Length; i++)
                            {
                                // StopWatch for the time in the DailyLog
                                Stopwatch stopwatch = new Stopwatch();
                                stopwatch.Start();
                                // Transfer the Save 
                                A.objWorkspace.TransferSave(A.objWorkspace.listSaves[listSaveId[i] - 1], 
                                                            A.objTransfer, 
                                                            A.objWorkspace.listeStatesSave[listSaveId[i] - 1]);
                                stopwatch.Stop();
                                TimeSpan elapsedTime = stopwatch.Elapsed;
                                string formattedTime = $"{(int)elapsedTime.TotalMinutes}min {elapsedTime.Seconds}sec";
                                // We write on the DailyLog
                                A.objWorkspace.objDailyLog.SetDailyLogDataInJson(A.objWorkspace.listSaves[listSaveId[i] - 1],
                                                                                 formattedTime,
                                                                                 A.objWorkspace.getExtension());
                            }
                            A.objWorkspace.ConsoleWriteDataString("1; 17; 3");
                        }
                        catch // In case that we have the right INPUT by the customer
                        {
                            A.objWorkspace.ConsoleWriteDataString("1; 22; 3");
                        }
                        Console.ReadLine();
                        break;
                    /* Delete Saves */
                    /*
                     * 
                     */
                    case "4":
                        A.objWorkspace.ConsoleWriteDataString("3; 13; 3; 28; 29");
                        Console.Write("#       "); string id_save4 = Console.ReadLine();
                        int id_save4_2;
                        try
                        {
                            id_save4_2 = int.Parse(id_save4);
                        }
                        catch
                        {
                            A.objWorkspace.ConsoleWriteDataString("1; 22; 3");
                            Console.ReadLine();
                            break;
                        }
                        if (id_save4_2 > 6 || id_save4_2 < 1)
                        {
                            A.objWorkspace.ConsoleWriteDataString("1; 22; 3");
                            Console.ReadLine();
                            break;
                        }
                        Json.ResetSave(A.objWorkspace.listSaves[id_save4_2 - 1]);
                        Json.EditSavesInJson(A.objWorkspace.listSaves);
                        A.objWorkspace.ConsoleWriteDataString("1; 16; 3");
                        Console.ReadLine();
                        break;
                    /* Change the language (it will be stocked in Config.cfg) */
                    /*
                     * 
                     */
                    case "5":
                        A.objWorkspace.ConsoleWriteDataString("3; 14; 3; 19; 3");
                        Console.Write("#       "); string dataUI = Console.ReadLine();
                        if (dataUI.ToLower() == "y" || dataUI.ToLower() == "yes")
                        {
                            A.objWorkspace.ConsoleWriteDataString("3; 20; 21; 3");
                            int dataUIint;
                            Console.Write("#       ");  dataUI = Console.ReadLine();
                            try
                            {
                                dataUIint = int.Parse(dataUI);
                            } catch
                            {
                                A.objWorkspace.ConsoleWriteDataString("1; 22; 3");
                                Console.ReadLine();
                                break;
                            }
                            if (dataUIint < 1 || dataUIint > 2) A.objWorkspace.ConsoleWriteDataString("22");
                            else
                            {
                                A.objWorkspace.setLang(dataUI);
                                A.objWorkspace.ConsoleWriteDataString("1; 18; 3");
                            }
                            Console.ReadLine();
                        }
                        break;
                    /* Data for extension of DailyLog (it will be stocked in Config.cfg) */
                    /*
                     * 
                     */
                    case "6":
                        A.objWorkspace.ConsoleWriteDataString("3; 14; 3; 35; 3");
                        Console.Write("#       "); string dataLog = Console.ReadLine();
                        if (dataLog.ToLower() == "y" || dataLog.ToLower() == "yes")
                        {
                            A.objWorkspace.ConsoleWriteDataString("3; 36; 37; 3");
                            Console.Write("#       "); dataLog = Console.ReadLine();
                            int dataLogint;
                            try
                            {
                                dataLogint = int.Parse(dataLog);
                            }
                            catch
                            {
                                A.objWorkspace.ConsoleWriteDataString("1; 22; 3");
                                Console.ReadLine();
                                break;
                            }
                            if (dataLogint < 1 || dataLogint > 2) A.objWorkspace.ConsoleWriteDataString("22");
                            else
                            {
                                A.objWorkspace.setExtension(dataLog);
                                A.objWorkspace.ConsoleWriteDataString("1; 34; 3");
                            }
                        }
                        Console.ReadLine();
                        break;
                    default:
                        A.objWorkspace.ConsoleWriteDataString("1; 22; 3");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
