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
using ModbusConnection.Circuit_Breaker;
using ModbusConnection.ViewModel;
using NModbus;

namespace ModbusConnection.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IModbusClient modbusClient;
        CircuitBreaker circuitBreaker;


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

            //Holding Registers
            lb_Holding_Register_0.Content = holdinRegisterValues[0].ToString();
            lb_Holding_Register_1.Content = holdinRegisterValues[1].ToString();
            lb_Holding_Register_2.Content = holdinRegisterValues[2].ToString();
            lb_Holding_Register_3.Content = holdinRegisterValues[3].ToString();

            //Analog Inputs
            lb_Analog_Input_0.Content = analogInputValues[0].ToString();
            lb_Analog_Input_1.Content = analogInputValues[1].ToString();
            lb_Analog_Input_2.Content = analogInputValues[2].ToString();
            lb_Analog_Input_3.Content = analogInputValues[3].ToString();

            //Coils
            cb_Coil_0.IsChecked = coilValues[0];
            cb_Coil_1.IsChecked = coilValues[1];
            cb_Coil_2.IsChecked = coilValues[2];
            cb_Coil_3.IsChecked = coilValues[3];

            //Descrete Inputs
            cb_Discrete_Input_0.IsChecked = discreteInputValues[0];
            cb_Discrete_Input_1.IsChecked = discreteInputValues[1];
            cb_Discrete_Input_2.IsChecked = discreteInputValues[2];
            cb_Discrete_Input_3.IsChecked = discreteInputValues[3];

        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            modbusClient = new NModbusClient(IpAddress.Text, 502);
            circuitBreaker = new CircuitBreaker(modbusClient);


            ConnectionStatus.Content = "Online";
            ConnectionStatus.Foreground = Brushes.Green;
            RegisterPanel.IsEnabled = true;
        }
        //private void WriteRegister_Click(object sender, RoutedEventArgs e)
        //{
        //    modbusClient.WriteSingleRegister(int.Parse(RegisterAddress.Text), int.Parse(RegisterValue.Text));
        //}

        private void cb_Coil_0_Checked(object sender, RoutedEventArgs e)
        {
            modbusClient.WriteSingleCoil(0, cb_Coil_0.IsChecked.Value);
        }
        private void cb_Coil_1_Checked(object sender, RoutedEventArgs e)
        {
            modbusClient.WriteSingleCoil(1, cb_Coil_1.IsChecked.Value);
        }

        private void cb_Coil_2_Checked(object sender, RoutedEventArgs e)
        {
            modbusClient.WriteSingleCoil(2, cb_Coil_2.IsChecked.Value);
        }

        private void cb_Coil_3_Checked(object sender, RoutedEventArgs e)
        {
            modbusClient.WriteSingleCoil(3, cb_Coil_3.IsChecked.Value);

        }
        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            modbusClient.Disconnect();
            ConnectionStatus.Content = "Offline";
            ConnectionStatus.Foreground = Brushes.Red;
        }

        private void tb_Holding_Register_0_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tb_Holding_Register_1_TextChanged(object sender, TextChangedEventArgs e)
        {
 
        }
        private void tb_Holding_Register_2_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void tb_Holding_Register_3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void bt_Holding_Register_0_Click(object sender, RoutedEventArgs e)
        {
            int value = string.IsNullOrEmpty(tb_Holding_Register_0.Text) ? 0 : int.Parse(tb_Holding_Register_0.Text);
            modbusClient.WriteSingleRegister(0, value);
            tb_Holding_Register_0.Text = null;
        }

        private void bt_Holding_Register_1_Click(object sender, RoutedEventArgs e)
        {
            int value = string.IsNullOrEmpty(tb_Holding_Register_1.Text) ? 0 : int.Parse(tb_Holding_Register_1.Text);
            modbusClient.WriteSingleRegister(1, value);
            tb_Holding_Register_1.Text = null;
        }

        private void bt_Holding_Register_2_Click(object sender, RoutedEventArgs e)
        {
            int value = string.IsNullOrEmpty(tb_Holding_Register_2.Text) ? 0 : int.Parse(tb_Holding_Register_2.Text);
            modbusClient.WriteSingleRegister(2, value);
            tb_Holding_Register_2.Text = null;
        }

        private void bt_Holding_Register_3_Click(object sender, RoutedEventArgs e)
        {
            int value = string.IsNullOrEmpty(tb_Holding_Register_3.Text) ? 0 : int.Parse(tb_Holding_Register_3.Text);
            modbusClient.WriteSingleRegister(3, value);
            tb_Holding_Register_3.Text = null;
        }

        private void cb_Coil_0_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_Coil_0_Checked(sender, e);
        }

        private void cb_Coil_1_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_Coil_1_Checked(sender, e);
        }

        private void cb_Coil_2_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_Coil_2_Checked(sender, e);
        }

        private void cb_Coil_3_Unchecked(object sender, RoutedEventArgs e)
        {
            cb_Coil_3_Checked(sender, e);
        }*/
    }
}
