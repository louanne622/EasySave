using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

using System.Net;
using System.Net.Sockets;


namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static private string Ip = "127.0.0.1";
        static private int Port = 9050;
        static private Socket socket;
        static private Socket SeConnecter()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(Ip), Port);
            Socket server = new Socket(AddressFamily.InterNetwork,
                                       SocketType.Stream,
                                       ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
            }
            catch (SocketException seEx)
            {
                MessageBox.Show(seEx.Message);
            }
            return server;
        }
        static private void Deconnecter(Socket socket)
        {
            Console.WriteLine("Bon bah ... salut !");
            socket.Shutdown(SocketShutdown.Both);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            socket = SeConnecter();
            if (!socket.Connected) { return; }
            DialoguerReseau(socket);
           
        }

         private void DialoguerReseau(Socket server)
         {
            byte[] data = new byte[1024];
            int recv = server.Receive(data);
            string stringData;

            while (true)
            {
                data = new byte[1024];

                recv = server.Receive(data);

                stringData = Encoding.UTF8.GetString(data, 0, recv);
               if(stringData.Length > 0) MessageBox.Show(stringData);
                labelAffichage.Content = stringData;
                Thread.Sleep(100);
            }
        }
    }
}
