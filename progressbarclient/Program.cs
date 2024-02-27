using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace client
{
    internal class client
    {
        static void Main(string[] args)
        {
            Socket socket = Seconnecter();
            DialoguerRezo(socket);


        }

        private static Socket Seconnecter()
        {
            Console.OutputEncoding = Encoding.UTF8;
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050); //ip serveur
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
            }
            catch (SocketException soEx)
            {
                Console.Error.WriteLine("Oh miiiiiiiince! Impossible de se connecter au serveur!");
                Console.Error.WriteLine(soEx.ToString());
            }
            return server;
        }

        private static void DialoguerRezo(Socket serveur)
        {
            byte[] data = new byte[1024];
            int recv = serveur.Receive(data);
            string stringData;
            stringData = Encoding.UTF8.GetString(data, 0, recv);
            Console.WriteLine(stringData);

            while (true)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                for (int k = 0; k < 100; k++)
                {

                    data = new byte[1024];
                    recv = serveur.Receive(data);
                    stringData = Encoding.UTF8.GetString(data, 0, recv);
                    string progress = stringData;
                    Console.WriteLine($"-Serveur: [{progress}] {k}% - {stopwatch.Elapsed:mm\\:ss}");
                    System.Threading.Thread.Sleep(100); // Simule un traitement
                    Console.SetCursorPosition(0, Console.CursorTop - 1); // Retour en arrière pour effacer la ligne précédente
                    //Console.Write("\r" + progress); 
                    //Thread.Sleep(1000);
                    //Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
                    //Console.Clear();
                }
                stopwatch.Stop();
                break;
                //Deco(serveur);
                //break;
            }
        }
        private static void Deco(Socket socket)
        {
            Console.WriteLine("Bon bah.... salut!");
            socket.Close();//  socket.Shutdown(SocketShutdown.Both);
        }

    }
}
