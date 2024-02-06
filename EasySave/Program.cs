using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Bienvenue sur l'application de sauvegarde ---");
        Console.WriteLine("1- Créer un travail de sauvegarde");
        Console.WriteLine("2- Lancer un travail de sauvegarde");
        Console.WriteLine("3- Voir le fichier log");

        Console.Write("Votre choix : ");
        string userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int choice))
        {
            if (choice >= 1 && choice <= 3)
            {
                string userChoice = "rien";
                switch (choice)
                {
                    case 1:
                        userChoice = "Créer un travail de sauvegarde";
                        break;
                    case 2:
                        userChoice = "Lancer un travail de sauvegarde";
                        break;
                    case 3:
                        userChoice = "Voir le fichier log";
                        break;
                }
                Console.WriteLine($"Vous avez choisi : {userChoice}.");

                if (choice == 1)
                {
                    Console.WriteLine("Entrez le chemin du fichier source");
                    string userSource = Console.ReadLine();
                    if (File.Exists(userSource) || (Directory.Exists(userSource)))
                    {
                        Console.WriteLine("Le fichier ou le répertoire existe.");
                        Console.WriteLine("Entrez le chemin du fichier cible");
                        string userCible = Console.ReadLine();
                        if (Directory.Exists(userCible))
                        {
                            Console.WriteLine("Le répertoire existe.");
                            string path = userInput;
                            var nbFichiers = Directory.GetFiles(userCible, "*.*", SearchOption.AllDirectories).Length;
                            Console.WriteLine($"Il y a \"{nbFichiers}\" fichier(s)");
                            Console.WriteLine($"Souhaitez-vous faire une sauvegarde complète ?");
                            userInput = Console.ReadLine();
                            if (userInput.Equals("oui", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine("Vous avez décidez de faire une sauvegarde complète");
                                string typeSave = "Complète";
                                Console.WriteLine("Résumé de la création :");
                                Console.WriteLine("Nom de la sauvegarde : 1");
                                Console.WriteLine($"Source : \"{userSource}\" ");
                                Console.WriteLine($"Cible : \"{userCible}\" ");
                                Console.WriteLine($"Type : \"{typeSave}\" ");
                            }
                            else
                            {
                                Console.WriteLine("Error");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Le chemin \"{userInput}\" n'existe pas.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Le chemin \"{userInput}\" n'existe pas.");
                    }

                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Choix invalide. Veuillez sélectionner une option valide.");
            }
        }
        else
        {
            Console.WriteLine("Entrée invalide. Veuillez saisir un nombre.");
        }

        Console.ReadLine();
    }
}