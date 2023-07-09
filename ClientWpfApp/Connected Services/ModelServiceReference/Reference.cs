﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientWpfApp.ModelServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ModelServiceReference.IModelService")]
    public interface IModelService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModelService/GetAllRTUs", ReplyAction="http://tempuri.org/IModelService/GetAllRTUsResponse")]
        System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelRTU> GetAllRTUs();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModelService/GetAllRTUs", ReplyAction="http://tempuri.org/IModelService/GetAllRTUsResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelRTU>> GetAllRTUsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModelService/GetRTU", ReplyAction="http://tempuri.org/IModelService/GetRTUResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ModbusServiceLibrary.ModelServiceReference.ModelServiceException), Action="http://tempuri.org/IModelService/GetRTUModelServiceExceptionFault", Name="ModelServiceException", Namespace="http://schemas.datacontract.org/2004/07/ModelWcfServiceLibrary")]
        ModbusServiceLibrary.ModelServiceReference.ModelRTU GetRTU(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModelService/GetRTU", ReplyAction="http://tempuri.org/IModelService/GetRTUResponse")]
        System.Threading.Tasks.Task<ModbusServiceLibrary.ModelServiceReference.ModelRTU> GetRTUAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModelService/GetDiscreteSignalsForRtu", ReplyAction="http://tempuri.org/IModelService/GetDiscreteSignalsForRtuResponse")]
        System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelDiscreteSignal> GetDiscreteSignalsForRtu(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModelService/GetDiscreteSignalsForRtu", ReplyAction="http://tempuri.org/IModelService/GetDiscreteSignalsForRtuResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelDiscreteSignal>> GetDiscreteSignalsForRtuAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModelService/GetAnalogSignalsForRtu", ReplyAction="http://tempuri.org/IModelService/GetAnalogSignalsForRtuResponse")]
        System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelAnalogSignal> GetAnalogSignalsForRtu(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModelService/GetAnalogSignalsForRtu", ReplyAction="http://tempuri.org/IModelService/GetAnalogSignalsForRtuResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelAnalogSignal>> GetAnalogSignalsForRtuAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModelService/GetRTUsEssentialData", ReplyAction="http://tempuri.org/IModelService/GetRTUsEssentialDataResponse")]
        System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelRTUData> GetRTUsEssentialData();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModelService/GetRTUsEssentialData", ReplyAction="http://tempuri.org/IModelService/GetRTUsEssentialDataResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelRTUData>> GetRTUsEssentialDataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModelService/GetAnalogSignalMappings", ReplyAction="http://tempuri.org/IModelService/GetAnalogSignalMappingsResponse")]
        System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelAnalogSignalMapping> GetAnalogSignalMappings();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModelService/GetAnalogSignalMappings", ReplyAction="http://tempuri.org/IModelService/GetAnalogSignalMappingsResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelAnalogSignalMapping>> GetAnalogSignalMappingsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModelService/GetDiscreteSignalMappings", ReplyAction="http://tempuri.org/IModelService/GetDiscreteSignalMappingsResponse")]
        System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelDiscreteSignalMapping> GetDiscreteSignalMappings();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModelService/GetDiscreteSignalMappings", ReplyAction="http://tempuri.org/IModelService/GetDiscreteSignalMappingsResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelDiscreteSignalMapping>> GetDiscreteSignalMappingsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModelService/GetDiscreteSignalPossibleStates", ReplyAction="http://tempuri.org/IModelService/GetDiscreteSignalPossibleStatesResponse")]
        System.Collections.ObjectModel.ObservableCollection<string> GetDiscreteSignalPossibleStates(int rtuId, int signalAddress);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModelService/GetDiscreteSignalPossibleStates", ReplyAction="http://tempuri.org/IModelService/GetDiscreteSignalPossibleStatesResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<string>> GetDiscreteSignalPossibleStatesAsync(int rtuId, int signalAddress);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IModelServiceChannel : ClientWpfApp.ModelServiceReference.IModelService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ModelServiceClient : System.ServiceModel.ClientBase<ClientWpfApp.ModelServiceReference.IModelService>, ClientWpfApp.ModelServiceReference.IModelService {
        
        public ModelServiceClient() {
        }
        
        public ModelServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ModelServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ModelServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ModelServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelRTU> GetAllRTUs() {
            return base.Channel.GetAllRTUs();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelRTU>> GetAllRTUsAsync() {
            return base.Channel.GetAllRTUsAsync();
        }
        
        public ModbusServiceLibrary.ModelServiceReference.ModelRTU GetRTU(int id) {
            return base.Channel.GetRTU(id);
        }
        
        public System.Threading.Tasks.Task<ModbusServiceLibrary.ModelServiceReference.ModelRTU> GetRTUAsync(int id) {
            return base.Channel.GetRTUAsync(id);
        }
        
        public System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelDiscreteSignal> GetDiscreteSignalsForRtu(int id) {
            return base.Channel.GetDiscreteSignalsForRtu(id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelDiscreteSignal>> GetDiscreteSignalsForRtuAsync(int id) {
            return base.Channel.GetDiscreteSignalsForRtuAsync(id);
        }
        
        public System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelAnalogSignal> GetAnalogSignalsForRtu(int id) {
            return base.Channel.GetAnalogSignalsForRtu(id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelAnalogSignal>> GetAnalogSignalsForRtuAsync(int id) {
            return base.Channel.GetAnalogSignalsForRtuAsync(id);
        }
        
        public System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelRTUData> GetRTUsEssentialData() {
            return base.Channel.GetRTUsEssentialData();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelRTUData>> GetRTUsEssentialDataAsync() {
            return base.Channel.GetRTUsEssentialDataAsync();
        }
        
        public System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelAnalogSignalMapping> GetAnalogSignalMappings() {
            return base.Channel.GetAnalogSignalMappings();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelAnalogSignalMapping>> GetAnalogSignalMappingsAsync() {
            return base.Channel.GetAnalogSignalMappingsAsync();
        }
        
        public System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelDiscreteSignalMapping> GetDiscreteSignalMappings() {
            return base.Channel.GetDiscreteSignalMappings();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ModbusServiceLibrary.ModelServiceReference.ModelDiscreteSignalMapping>> GetDiscreteSignalMappingsAsync() {
            return base.Channel.GetDiscreteSignalMappingsAsync();
        }
        
        public System.Collections.ObjectModel.ObservableCollection<string> GetDiscreteSignalPossibleStates(int rtuId, int signalAddress) {
            return base.Channel.GetDiscreteSignalPossibleStates(rtuId, signalAddress);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<string>> GetDiscreteSignalPossibleStatesAsync(int rtuId, int signalAddress) {
            return base.Channel.GetDiscreteSignalPossibleStatesAsync(rtuId, signalAddress);
        }
    }
}
