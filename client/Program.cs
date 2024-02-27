using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

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
            catch(SocketException soEx)
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
            string stringData, Input; 
            stringData = Encoding.UTF8.GetString(data, 0, recv);
            Console.WriteLine(stringData);

            while(true)
            {
                Input = Console.ReadLine();
                serveur.Send(Encoding.UTF8.GetBytes(Input));
                if (Input == "ciao")
                {
                    Deco(serveur);
                    break;
                }
                

                data= new byte[1024];
                recv = serveur.Receive(data);
                stringData = Encoding.UTF8.GetString(data, 0, recv);
                Console.WriteLine("Serveur: " + stringData);
            }
        }
        private static void Deco(Socket socket)
        {
            Console.WriteLine("Bon bah.... salut!");
            socket.Shutdown(SocketShutdown.Both);
        }
        
    }
}
