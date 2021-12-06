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
using System.Net.Sockets;
using System.Net;

namespace CMSN_Lab_8
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

        private void sender_Click(object sender, RoutedEventArgs e)
        {
            UdpClient senderUdp = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(
                IPAddress.Parse(tbRemoteAddr.Text), int.Parse(tbRemotePort.Text)
                );

            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(tbWebAddr.Text);

                senderUdp.Send(bytes, bytes.Length, endPoint);
                tbWebAddr.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                senderUdp.Close();
            }
        }
    }
}
