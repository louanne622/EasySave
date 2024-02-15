using System;
using System.IO;
using System.Xml;

namespace XML
{
    class XMl
    {
        public static void Xml(bool x, string Erreur)
        {
            // Création d'un objet XmlDocument pour stocker les logs
            XmlDocument xmlDocument = new XmlDocument();

            DateTime now = DateTime.Now;

            // Formattage de la date au format "jj/mm/yy"
            string formattedDate = now.ToString("dd_MM_yy");

            // Affichage de la date formatée
            string Nomlog = "log_" + formattedDate;
            XmlElement rootElement = xmlDocument.CreateElement(Nomlog);
            xmlDocument.AppendChild(rootElement);
            string filePath = @"C:\Log\" + Nomlog + ".xml";
            // Ajout de plusieurs entrées de log

            if (x == false) 
            {
                AddLog(xmlDocument, "Erreur", Erreur);
            }
            if (x == true)
            {
                AddLog(xmlDocument, "réussite",Erreur);   
            } 
            

            // Sauvegarde du document XML dans un fichier
            
            xmlDocument.Save(filePath);

            Console.WriteLine($"Les logs ont été enregistrés avec succès dans le fichier : {filePath}");
        }

        // Fonction pour ajouter un log au document XML
        static void AddLog(XmlDocument xmlDocument, string type, string message)
        {
            DateTime log2 = DateTime.Now;
            string formattedDate2 = log2.ToString("ss");
            string nlog="Log1 ";
            XmlElement newClassElement = xmlDocument.CreateElement(nlog);

            // Création et ajout des éléments de la nouvelle classe
            XmlElement nomElement = xmlDocument.CreateElement("nom");
            nomElement.InnerText = "Maths";
            newClassElement.AppendChild(nomElement);

            XmlElement niveauElement = xmlDocument.CreateElement("niveau");
            niveauElement.InnerText = "12";
            newClassElement.AppendChild(niveauElement);

            // Ajout de la nouvelle itération de classe à l'élément racine du document
            xmlDocument.DocumentElement?.AppendChild(newClassElement);

            // Sauvegarde des modifications dans le fichier XML
            
        }
    }
    
}


