using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ws
{ /// <summary>
/// penser a duppliquer le programme et retiré la partie réponse client et ainsi mettre que la partie vu msg serveur pour la console dporté ///
/// </summary>
    internal class serveur
    {
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
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"),9050); //ip serveur

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
            Console.WriteLine("CLient connecté à l'ip {0} sur le port {1}", clientie.Address , clientie.Port);

            return client;
        }
        static void EcouterReseau(Socket client)
        {
            byte[] data = new byte[1024];
            int k = 5;
            string couccou = "Salut a toi jeune entrepreneur";
            int tailleRecv; string Inpt; 
            data = Encoding.UTF8.GetBytes(couccou); 
            client.Send(data, data.Length, SocketFlags.None);
            while(true)
            {
                tailleRecv = client.Receive(data);
                if (Encoding.UTF8.GetString(data, 0, tailleRecv) == "start")
                {
                    aa(client);
                }
                if (Encoding.UTF8.GetString(data, 0, tailleRecv) == "ciao")
                {
                    break;
                }
                if(tailleRecv < k)
                {
                    Console.WriteLine("Alerte le message fait " + tailleRecv + " alors qu'il devrait faire " + k + "octet au maximum");
                }

                Console.WriteLine("Client: " + Encoding.UTF8.GetString(data, 0, tailleRecv));
                Inpt = Console.ReadLine() + " La charge reseau est de " + tailleRecv + " octet";
                client.Send(Encoding.UTF8.GetBytes(Inpt));

            }
        }
        
        private static void Deconnecter(Socket socket)
        {
            Console.WriteLine("Déconnexion de {0}", clientie.Address);
            socket.Close();
        }

        public static string GetProgressBar(int pourcentage)
        {
            const int progressBarLength = 20;
            int charactersToFill = progressBarLength * pourcentage / 100;
                string progressBar = "[";
                for (int i = 0; i < progressBarLength; i++)
                {
                    int k = i % 2;
                    if (k == 0)
                    {
                        progressBar += i < charactersToFill ? "<" : " ";
                    }
                    else
                    {
                        progressBar += i < charactersToFill ? ">" : " ";
                    }

                }
                progressBar += "] " + pourcentage + "%";
                return progressBar;
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
                if (i < 50)
                {
                    Thread.Sleep(200);
                }
                Thread.Sleep(100);
                client.Send(Encoding.UTF8.GetBytes(progressBar));
            }
        }
    } 
}

