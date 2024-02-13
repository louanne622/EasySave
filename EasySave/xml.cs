using System;
using System.IO;
using System.Xml;

namespace LoggingSystem
{
    public class XmlLogger
    {
        private readonly string logFilePath; // Chemin du fichier de journalisation XML

        // Constructeur de la classe XmlLogger
        public XmlLogger(string logFilePath)
        {
            this.logFilePath = logFilePath; // Initialise le chemin du fichier de journalisation
        }

        // Méthode pour enregistrer un message d'information dans le fichier XML de journalisation
        public void LogInfo(string message)
        {
            Log("INFO", message); // Appelle la méthode Log en spécifiant le niveau d'information
        }

        // Méthode pour enregistrer un message d'avertissement dans le fichier XML de journalisation
        public void LogWarning(string message)
        {
            Log("WARNING", message); // Appelle la méthode Log en spécifiant le niveau d'avertissement
        }

        // Méthode pour enregistrer un message d'erreur dans le fichier XML de journalisation
        public void LogError(string message)
        {
            Log("ERROR", message); // Appelle la méthode Log en spécifiant le niveau d'erreur
        }

        // Méthode interne pour enregistrer un message dans le fichier XML avec le niveau de gravité et l'horodatage
        private void Log(string level, string message)
        {
            try
            {
                // Crée un nouveau document XML ou charge un document XML existant
                XmlDocument xmlDoc = new XmlDocument();
                if (File.Exists(logFilePath))
                {
                    xmlDoc.Load(logFilePath);
                }
                else
                {
                    // Si le fichier n'existe pas, crée un nouveau document avec une déclaration XML et un élément racine
                    XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    XmlElement root = xmlDoc.CreateElement("LogEntries");
                    xmlDoc.AppendChild(root);
                    xmlDoc.InsertBefore(xmlDeclaration, root);
                }

                // Crée un nouvel élément LogEntry avec les attributs Level et Timestamp
                XmlElement logEntry = xmlDoc.CreateElement("LogEntry");
                logEntry.SetAttribute("Level", level); // Définit le niveau de gravité du message
                logEntry.SetAttribute("Timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // Définit l'horodatage du message
                logEntry.InnerText = message; // Définit le contenu textuel du message

                // Ajoute l'élément LogEntry à l'élément racine LogEntries du document XML
                xmlDoc.DocumentElement.AppendChild(logEntry);

                // Enregistre le document XML dans le fichier
                xmlDoc.Save(logFilePath);
            }
            catch (Exception ex)
            {
                // En cas d'erreur lors de l'enregistrement, affiche un message d'erreur
                Console.WriteLine("Error while logging: " + ex.Message);
            }
        }
    }
}
