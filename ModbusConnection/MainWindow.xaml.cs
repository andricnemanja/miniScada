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
        IModbusClient modbusClient;
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

            if (!modbusClient.IsAvailable())
            {
                ConnectionStatus.Content = "Uspostavljanje konekcije...";
                ConnectionStatus.Foreground = Brushes.Gray;
                RegisterPanel.IsEnabled = false;
                return;
            }


            else if (ConnectionStatus.Content.Equals("Uspostavljanje konekcije..."))
            {
                modbusClient.Reconnect();

                ConnectionStatus.Content = "Aktivna";
                ConnectionStatus.Foreground = Brushes.Green;
                RegisterPanel.IsEnabled = true;

            }

            ushort startAddress =  string.IsNullOrEmpty(RegisterAddress.Text) ? (ushort)0 : ushort.Parse(RegisterAddress.Text);
            int value = modbusClient.ReadSingleRegister(startAddress);
            CurrentRegisterValue.Text = value.ToString();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            modbusClient = new EasyModbusClient(IpAddress.Text, 502);

            ConnectionStatus.Content = "Aktivna";
            ConnectionStatus.Foreground = Brushes.Green;
            RegisterPanel.IsEnabled = true;
        }

        private void ReadRegister_Click(object sender, RoutedEventArgs e)
        {
            int value = modbusClient.ReadSingleRegister(int.Parse(RegisterAddress.Text));
            CurrentRegisterValue.Text = value.ToString();
        }

        private void WriteRegister_Click(object sender, RoutedEventArgs e)
        {
            modbusClient.WriteSingleRegister(int.Parse(RegisterAddress.Text), int.Parse(RegisterValue.Text));
        }

    }
}
