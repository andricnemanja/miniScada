using ModbusConnection.Commands;
using ModbusConnection.Model;
using ModbusConnection.Model.Signals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace ModbusConnection.ViewModel
{
    internal class MainViewModel
    {

        public ICommand CreateConnectionWindowCommand { get; set; }
        public ICommand SetRegistryValuesCommand { get; set; }

        public ObservableCollection<RTU> RTUList { get; set; }


        public MainViewModel()
        {
            CreateConnectionWindowCommand = new CreateConnectionWindowCommand();
            SetRegistryValuesCommand = new SetRegistryValuesCommand();

            ObservableCollection<ISignal> discreteSignals1 = new ObservableCollection<ISignal>()
            {
                new DiscreteSignal(1, "Prekidac 1", false, null),
                new DiscreteSignal(2, "Prekidac 2", false, null)
            };
            ObservableCollection<ISignal> discreteSignals2 = new ObservableCollection<ISignal>()
            {
                new DiscreteSignal(0, "Prekidac 1", false, null),
                new DiscreteSignal(2, "Prekidac 2", false, null),
                new DiscreteSignal(5, "Prekidac 3", false, null)

            };
            ObservableCollection<ISignal> discreteSignals3 = new ObservableCollection<ISignal>()
            {
                new DiscreteSignal(1, "Prekidac 1", false, null)
            };

            RTUList = new ObservableCollection<RTU>
            {
                new RTU(new RTUData("RTU 1", "127.0.0.1", 502), new RTUValues(discreteSignals1), new RTUConnection(null)),
                new RTU(new RTUData("RTU 2", "127.0.0.1", 503), new RTUValues(discreteSignals2), new RTUConnection(null)),
                new RTU(new RTUData("RTU 3", "127.0.0.1", 504), new RTUValues(discreteSignals3), new RTUConnection(null))
            };

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Parallel.ForEach(RTUList, rtu =>
            {
                rtu.Values.UpdateSignals();
            });
        }
    }
}
