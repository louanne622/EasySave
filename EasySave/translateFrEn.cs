using System;
using System.Resources;

class translateFrEn
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choisissez la langue : \n 1. Anglais \n 2. Français ");
        string input = Console.ReadLine();

        ResourceManager resourceManager;
        string language;

        if (input == "1")
        {
            resourceManager = new ResourceManager("translate.Ressources.en", typeof(translateFrEn).Assembly);
            language = "anglais";
        }
        else if (input == "2")
        {
            resourceManager = new ResourceManager("translate.Ressources.fr", typeof(translateFrEn).Assembly);
            language = "français";
        }
        else
        {
            Console.WriteLine("Langue non valide. Choisissez '1' pour anglais ou '2' pour français.");
            return;
        }

        string welcomeMessage = resourceManager.GetString("welcomeMessage");
        Console.WriteLine($"{welcomeMessage}");
    }
}
