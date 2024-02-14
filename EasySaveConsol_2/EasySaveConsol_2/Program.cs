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
using System.IO;

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
                        foreach (Save save in A.objWorkspace.listSaves)
                        {
                            A.objWorkspace.getSaveData(save);
                        }
                        A.objWorkspace.ConsoleWriteDataString("1; 3");
                        Console.ReadLine();
                        break;
                    /* Update the Saves */
                    /*
                     * 
                     */
                    case "2":
                        Console.ReadLine();
                        break;
                    /* Execute Saves */
                    /*
                     * 
                     */
                    case "3":
                        Console.ReadLine();
                        break;
                    /* Delete Saves */
                    /*
                     * 
                     */
                    case "4":
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
                            Console.Write("#       ");  dataUI = Console.ReadLine();
                            if (int.Parse(dataUI) < 1 || int.Parse(dataUI) > 2) A.objWorkspace.ConsoleWriteDataString("22");
                            else
                            {
                                A.objWorkspace.setLang(dataUI);
                                A.objWorkspace.ConsoleWriteDataString("1; 18; 3");
                            }
                            Console.WriteLine();
                        }
                        Console.ReadLine();
                        break;
                    /* Data for extension of DailyLog (it will be stocked in Config.cfg) */
                    /*
                     * 
                     */
                    case "6":
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
