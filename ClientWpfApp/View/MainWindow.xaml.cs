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
using ClientWpfApp.Circuit_Breaker;
using ClientWpfApp.ViewModel;
using NModbus;

namespace ClientWpfApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel mainViewModel = new MainViewModel();
            this.DataContext = mainViewModel;

            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(1);
            //timer.Tick += timer_Tick;
            //timer.Start();
        }
        /*
        void timer_Tick(object sender, EventArgs e)
        {
            if (ConnectionStatus.Content.Equals("Offline"))
                return;

            //ushort startAddress =  string.IsNullOrEmpty(RegisterAddress.Text) ? (ushort)1 : ushort.Parse(RegisterAddress.Text);
            ushort[] holdinRegisterValues = {0, 0, 0, 0};
            ushort[] analogInputValues = { 0, 0, 0, 0 };
            bool[] coilValues = { false, false, false, false };
            bool[] discreteInputValues = { false, false, false, false };

            try
            {
                circuitBreaker.ExecuteAction(() =>
                {
                    holdinRegisterValues = modbusClient.ReadHoldingRegisters(0, 4);
                    analogInputValues = modbusClient.ReadAnalogInputs(0, 4);
                    coilValues = modbusClient.ReadCoils(0, 4);
                    discreteInputValues = modbusClient.ReadDiscreteInputs(0, 4);
                });

                ConnectionStatus.Content = "Online";
                ConnectionStatus.Foreground = Brushes.Green;
                RegisterPanel.IsEnabled = true;
            }
            catch (CircuitBreakerOpenException)
            {
                ConnectionStatus.Content = "Uspostavljanje konekcije za " + circuitBreaker.RecconectingTime.ToString();
                ConnectionStatus.Foreground = Brushes.Gray;
                RegisterPanel.IsEnabled = false;
                return;
            }
            catch(Exception)
            {
                ConnectionStatus.Content = "Uredjaj nije dostupan";
                ConnectionStatus.Foreground = Brushes.Red;
                RegisterPanel.IsEnabled = false;
                return;
            }

            */
    }
}
