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

    static void MonitorNetworkLoad()
    {
        string ip = "192.168.209.31";
        int port = 9050;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        while (true)
        {
            
            
            // Obtenir la vitesse actuelle de téléchargement sur l'adresse IP 127.0.0.1 avec le port 9050
            long downloadSpeed = GetDownloadSpeed(ip, 9050); ////ip a modifié en mettant celle du serveur si comm ext port=> 9050


            // Afficher la vitesse de téléchargement
            Console.WriteLine($"Vitesse de téléchargement sur {ip}:{port} => {downloadSpeed} o/s - {stopwatch.Elapsed:mm\\:ss}");
            Console.SetCursorPosition(0, Console.CursorTop - 1);
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
            // Ignorer les interfaces inactives ou les boucles locales
            if (adapter.OperationalStatus != OperationalStatus.Up || adapter.NetworkInterfaceType == NetworkInterfaceType.Loopback)
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
