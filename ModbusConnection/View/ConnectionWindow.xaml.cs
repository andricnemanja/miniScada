using ModbusConnection.Model;
using ModbusConnection.ViewModel;
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
using System.Windows.Shapes;

namespace ModbusConnection.View
{
    /// <summary>
    /// Interaction logic for ConnectionWindow.xaml
    /// </summary>
    public partial class ConnectionWindow : Window
    {
        public ConnectionWindow(RTU rtu)
        {
            InitializeComponent();
            ConnectionViewModel connectionViewModel = new ConnectionViewModel(rtu);
            this.DataContext = connectionViewModel;
        }
    }
}
