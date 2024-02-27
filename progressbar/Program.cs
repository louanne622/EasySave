using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ws
{ /// <summary>
/// penser a duppliquer le programme et retiré la partie réponse client et ainsi mettre que la partie vu msg serveur pour la console dporté ///
/// </summary>
    internal class serveur
    {
        const long NetworkThreshold = 1000000; // Seuil de charge réseau en octets par seconde
        static IPEndPoint clientie;
        static void Main(string[] args)
        {
            Socket socket = Seconnecter();
            Socket client = AcceptConnection(socket);
            EcouterReseau(client);
            Deconnecter(socket);


        }
        private static Socket Seconnecter()
        {
            Console.OutputEncoding = Encoding.UTF8;

            //méthode natural code
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050); //ip serveur

            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //on peut aussi avoir avec TcpListener, cf solution consoletcp, méthode Low code
            //TcpListener servTCP1 = new TcpListener(9050);
            //or
            //TcpListener servTCP2 = new TcpListener(IPAddress.Parse("127.0.0.1"), 9050);

            newsock.Bind(ipep);
            newsock.Listen(10);
            Console.WriteLine("serveur à l'écoute....");
            return newsock;
        }
        private static Socket AcceptConnection(Socket socket)
        {
            Socket client = socket.Accept();
            clientie = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine("CLient connecté à l'ip {0} sur le port {1}", clientie.Address, clientie.Port);

            return client;
        }
        static void EcouterReseau(Socket client)
        {
            byte[] data = new byte[1024];
            string couccou = "Salut a toi jeune entrepreneur";
            string Inpt;
            data = Encoding.UTF8.GetBytes(couccou);
            client.Send(data, data.Length, SocketFlags.None);
            while (true)
            {
                aa(client);
                Inpt = Console.ReadLine();
                client.Send(Encoding.UTF8.GetBytes(Inpt));

            }
        }
        static void SendProgress(int progress, Socket client)
        {
            // Convertir le pourcentage de progression en tableau d'octets
            byte[] buffer = Encoding.ASCII.GetBytes(progress.ToString());

            // Envoyer les données au client
            client.Send(buffer);
        }
        private static void Deconnecter(Socket socket)
        {
            Console.WriteLine("Déconnexion de {0}", clientie.Address);
            socket.Close();
        }

        static string GetProgressBar(int percentage)
        {
            const int progressBarLength = 20;
            int numberOfFilledBlocks = (int)Math.Round(progressBarLength * (percentage / 100.0));
            int numberOfEmptyBlocks = progressBarLength - numberOfFilledBlocks;

            return new string('#', numberOfFilledBlocks) + new string(' ', numberOfEmptyBlocks);
        }
        public static void aa(Socket client) //améliorable par chiffrement XOR ??
        {
            for (int i = 0; i <= 100; i++)
            {
                // Convertir la barre de progression en une chaîne
                string progressBar = GetProgressBar(i);

                // Convertir la chaîne en tableau d'octets
                byte[] prog = new byte[1024];
                prog = Encoding.ASCII.GetBytes(progressBar);
                // Attendre un court instant avant la prochaine mise à jour
                Thread.Sleep(100);
                client.Send(Encoding.UTF8.GetBytes(progressBar));
            }
        }
    }
}

