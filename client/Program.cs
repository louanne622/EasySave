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
            byte key = 255;
            int recv = serveur.Receive(data);
            byte[] datad = CrytpoXOR(data, key, serveur);
            string stringData, Input; 
            stringData = Encoding.UTF8.GetString(datad, 0, recv);
            Console.WriteLine(stringData);

            while(true)
            {
                Input = Console.ReadLine();
                //serveur.Send();
                byte[] dataC = Encoding.UTF8.GetBytes(Input);
              dataC =  CrytpoXOR(dataC, key, serveur);
                serveur.Send(dataC);
                if (Input == "ciao")
                {
                    Deco(serveur);
                    break;
                }
                

               byte[] data2= new byte[1024];
                recv = serveur.Receive(data2);
                byte[] datad2 = CrytpoXOR(data2, key, serveur);
                stringData = Encoding.UTF8.GetString(datad2, 0, recv);
                Console.WriteLine("Serveur: " + stringData);
            }
        }
        public static byte[] CrytpoXOR(byte[] inputBytes, byte key, Socket client)
        {
            byte[] encryptedBytes = new byte[inputBytes.Length];
            for (int i = 0; i < inputBytes.Length; i++)
            {
                encryptedBytes[i] = (byte)(inputBytes[i] ^ key);
            }
            return encryptedBytes;
        }
        private static void Deco(Socket socket)
        {
            Console.WriteLine("Bon bah.... salut!");
            socket.Shutdown(SocketShutdown.Both);
        }
        
    }
}
