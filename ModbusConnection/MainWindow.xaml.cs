using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
using System.Windows.Threading;
using NModbus;

namespace ModbusConnection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IModbusMaster master;
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (ConnectionStatus.Content.Equals("Neaktivna"))
                return;
            byte slaveAddress = 1;
            ushort startAddress =  string.IsNullOrEmpty(RegisterAddress.Text) ? (ushort)0 : ushort.Parse(RegisterAddress.Text);
            ushort[] value = master.ReadHoldingRegisters(slaveAddress, startAddress, 1);
            CurrentRegisterValue.Text = value[0].ToString();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            TcpClient client = new TcpClient(IpAddress.Text, 502);
            var factory = new ModbusFactory();
            master = factory.CreateMaster(client);

            ConnectionStatus.Content = "Aktivna";
            ConnectionStatus.Foreground = Brushes.Green;
            RegisterPanel.IsEnabled = true;
        }

        private void ReadRegister_Click(object sender, RoutedEventArgs e)
        {

            byte slaveAddress = 1;
            ushort startAddress = ushort.Parse(RegisterAddress.Text);
            ushort[] value = master.ReadHoldingRegisters(slaveAddress, startAddress, 1);
            CurrentRegisterValue.Text = value[0].ToString();

        }

        private void WriteRegister_Click(object sender, RoutedEventArgs e)
        {
            byte slaveAddress = 1;
            ushort startAddress = ushort.Parse(RegisterAddress.Text);
            ushort registerValue = ushort.Parse(RegisterValue.Text);
            master.WriteSingleRegister(slaveAddress, startAddress, registerValue);
        }
    }
}
