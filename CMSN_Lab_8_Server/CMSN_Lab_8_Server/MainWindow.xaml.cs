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
using System.Net.Sockets;
using System.Net;
using System.Reflection.Metadata;
using System.Diagnostics;

namespace CMSN_Lab_8_Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UdpClient receivingUdpClient;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void launcher_Click(object sender, RoutedEventArgs e)
        {
            int port = int.Parse(localPortName.Text);
            Thread tReciever = new Thread(() => Reciever(port));
            tReciever.Start();
            launcher.IsEnabled = false;
        }

        private void Reciever(int port)
        {
            receivingUdpClient = new UdpClient(port);
            IPEndPoint remoteIpEndPoint = null;

            try
            {
                while (true)
                {

                    byte[] recievedBytes = receivingUdpClient.Receive(ref remoteIpEndPoint);

                    string returnData = Encoding.UTF8.GetString(recievedBytes);

                    requestsLog.Dispatcher.BeginInvoke(new Action(() => addMessage("-->" + returnData)));
                    Process.Start("C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe", returnData);
                }
            }
            catch(Exception ex)
            {
                requestsLog.Dispatcher.BeginInvoke(new Action(() => 
                    addMessage("Возникло исключение: " + ex.ToString() + "\n" + ex.Message))
                    );
            }
        }

        private void addMessage(string message)
        {
            requestsLog.Text += message + "\n";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (receivingUdpClient != null)
                receivingUdpClient.Close();
        }
    }
}

/*
Разработать сервер открывающий в браузере указанную клиентом страницу.

После запуска сервер должен ожидать подключение на порту 8081. 

⦁	При подключении клиент отправляет адрес страницы в интернет
⦁	При получении адреса сервер должен открыть браузер с этим адресом.
    Для этого можно воспользоваться вызовом Diagnostics.Process.Start(),
    однако в этом случае нужно убедиться, что сервер не будет запускать ничего кроме браузера.
*/
