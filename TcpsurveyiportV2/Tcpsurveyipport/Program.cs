using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

class Program
{
    
    static void Main(string[] args)
    {
        Console.WriteLine("Démarrage de l'application...");

        // Démarrage de la surveillance de la charge réseau
        Task.Run(() => MonitorNetworkLoad());

        Console.ReadLine(); // Garder l'application active
    }

   public static void MonitorNetworkLoad()
    {
        long downloadMax = 10000000;
        string ip = "127.0.0.1";    ////ip a modifié en mettant celle du serveur si comm ext port=> 9050
        int port = 9050;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        while (true)
        {
            
            
            // Obtenir la vitesse actuelle de téléchargement sur l'adresse IP 127.0.0.1 avec le port 9050
            long downloadSpeed = GetDownloadSpeed(ip, 9050); 


            // Afficher la vitesse de téléchargement
            Console.WriteLine($"Vitesse de téléchargement sur {ip}:{port} => {downloadSpeed} o/s - {stopwatch.Elapsed:mm\\:ss}");
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            
            if (downloadSpeed > downloadMax)
            {
                while (downloadSpeed > downloadMax)
                {
                    Console.WriteLine("Alerte charge réseau est supérieure au seuil, réduction des tâches parrallèle en cours");
                    ///réduction des tâche parallèle (maybe augmenter le temps d'actualisation de la barre des tâches)
                }
                Console.WriteLine("La charge réseau est repassé en dessous en dessous du seuil, retour a la normale pour les tâche parrallèles en cours");
                    ////remettre le temps d'actualisation de la barre des tâches a son état normale
            }


            // Attendre un court instant avant de vérifier à nouveau la charge réseau
            Thread.Sleep(1);
        }
        
    }

    static long GetDownloadSpeed(string ipAddress, int port)
    {
        // Obtenir toutes les interfaces réseau disponibles sur la machine
        NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

        // Parcourir les interfaces réseau
        foreach (NetworkInterface adapter in interfaces)
        {
            // On ne prends en compte que les cartes réseaux active
            if (adapter.OperationalStatus != OperationalStatus.Up)
                continue;

            // Obtenir les statistiques IPv4 de l'interface réseau
            IPv4InterfaceStatistics stats = adapter.GetIPv4Statistics();

            // Obtenir les connexions TCP actives
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections();

            // Parcourir les connexions TCP actives
            foreach (TcpConnectionInformation connection in tcpConnections)
            {
                // Vérifier si la connexion correspond à l'adresse IP et au port spécifiés
                if (connection.LocalEndPoint.Address.ToString() == ipAddress && connection.LocalEndPoint.Port == port)
                {
                    // Retourner la vitesse de téléchargement de l'interface réseau
                    return stats.BytesReceived;
                }
            }
        }

        return 0; // Retourner 0 si aucune interface réseau active n'a été trouvée avec la connexion correspondante
    }
}
