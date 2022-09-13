using ModbusConnection.Commands;
using ModbusConnection.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModbusConnection.ViewModel
{
    internal class MainViewModel
    {

        public ICommand CreateConnectionWindowCommand { get; set; }
        public ICommand SetRegistryValuesCommand { get; set; }

        public MainViewModel()
        {
            CreateConnectionWindowCommand = new CreateConnectionWindowCommand();
            SetRegistryValuesCommand = new SetRegistryValuesCommand();
        }

        public ObservableCollection<RTU> RTUList { get; set; } = new ObservableCollection<RTU>
        {
            new RTU(new RTUData("Uredjaj 1", "127.0.0.1", 502), new RTUValues(), new RTUConnection(null)),
            new RTU(new RTUData("Uredjaj 2", "127.0.0.1", 503), new RTUValues(), new RTUConnection(null)),
            new RTU(new RTUData("Uredjaj 3", "127.0.0.1", 504), new RTUValues(), new RTUConnection(null))
        };


        


    }
}
