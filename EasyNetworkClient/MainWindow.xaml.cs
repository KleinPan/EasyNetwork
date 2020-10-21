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
using EasyNetwork.Connections;
using EasyNetwork.Converter;
using EasyNetwork.GlobalData.Enums;
using EasyNetwork.TCP;

namespace EasyNetwork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConnectionResult connectionResult;
        TcpConnection tcpConnection;
        public MainWindow()
        {
            InitializeComponent();

            Init();
        }


        private void Init()
        {


            connectionResult = ConnectionResult.TCPConnectionNotAlive;
            //1. Establish a connection to the server.
            tcpConnection = ConnectionFactory.CreateTcpConnection("172.16.40.19", 1234, out connectionResult);
            //2. Register what happens if we get a connection
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (connectionResult == ConnectionResult.Connected)
            {
                Console.WriteLine($"{tcpConnection.ToString()} Connection established");
                //3. Send a raw data packet request.
                tcpConnection.SendRawData(RawDataConverter.FromUTF8String("HelloWorld", "Hello, this is the RawDataExample!"));
                //tcpConnection.SendRawData(RawDataConverter.FromBoolean("BoolValue", true));
                //tcpConnection.SendRawData(RawDataConverter.FromBoolean("BoolValue", false));
                //tcpConnection.SendRawData(RawDataConverter.FromDouble("DoubleValue", 32.99311325d));
                ////4. Send a raw data packet request without any helper class
                //tcpConnection.SendRawData("HelloWorld", Encoding.UTF8.GetBytes("Hello, this is the RawDataExample!"));
                //tcpConnection.SendRawData("BoolValue", BitConverter.GetBytes(true));
                //tcpConnection.SendRawData("BoolValue", BitConverter.GetBytes(false));
                //tcpConnection.SendRawData("DoubleValue", BitConverter.GetBytes(32.99311325d));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
