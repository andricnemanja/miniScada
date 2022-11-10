using ClientWpfApp.ModbusClients;
using System.ComponentModel;

namespace ClientWpfApp.Model
{
    public class RTUConnection : INotifyPropertyChanged
    {
        private bool _status;

        public bool Status
        {
            get { return _status; }
            set 
            {
                if(value != _status)
                {
                    _status = value;
                    RaisePropertyChanged("Status");
                }
            }
        }

        public IModbusClient Client { get; set; }

        public RTUConnection(IModbusClient client, bool status = false)
        {
            Status = status;
            Client = client;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}