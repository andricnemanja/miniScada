﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientWpfApp.ModbusServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ModbusServiceReference.IModbusDuplex", CallbackContract=typeof(ClientWpfApp.ModbusServiceReference.IModbusDuplexCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IModbusDuplex {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IModbusDuplex/ReadAnalogSignal")]
        void ReadAnalogSignal(int rtuId, int signalAddress);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IModbusDuplex/ReadAnalogSignal")]
        System.Threading.Tasks.Task ReadAnalogSignalAsync(int rtuId, int signalAddress);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IModbusDuplex/ReadDiscreteSignal")]
        void ReadDiscreteSignal(int rtuId, int signalAddress);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IModbusDuplex/ReadDiscreteSignal")]
        System.Threading.Tasks.Task ReadDiscreteSignalAsync(int rtuId, int signalAddress);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IModbusDuplex/WriteAnalogSignal")]
        void WriteAnalogSignal(int rtuId, int signalAddress, double newValue);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IModbusDuplex/WriteAnalogSignal")]
        System.Threading.Tasks.Task WriteAnalogSignalAsync(int rtuId, int signalAddress, double newValue);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IModbusDuplex/WriteDiscreteSignal")]
        void WriteDiscreteSignal(int rtuId, int signalAddress, string newValue);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IModbusDuplex/WriteDiscreteSignal")]
        System.Threading.Tasks.Task WriteDiscreteSignalAsync(int rtuId, int signalAddress, string newValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModbusDuplex/ConnectToRtu", ReplyAction="http://tempuri.org/IModbusDuplex/ConnectToRtuResponse")]
        ModbusServiceLibrary.CommandResult.ConnectToRtuResult ConnectToRtu(int rtuId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModbusDuplex/ConnectToRtu", ReplyAction="http://tempuri.org/IModbusDuplex/ConnectToRtuResponse")]
        System.Threading.Tasks.Task<ModbusServiceLibrary.CommandResult.ConnectToRtuResult> ConnectToRtuAsync(int rtuId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IModbusDuplexCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IModbusDuplex/UpdateAnalogSignalValue")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ModbusServiceLibrary.CommandResult.ReadSingleDiscreteSignalResult))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ModbusServiceLibrary.CommandResult.ReadSingleAnalogSignalResult))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ModbusServiceLibrary.CommandResult.ConnectToRtuResult))]
        void UpdateAnalogSignalValue(ModbusServiceLibrary.CommandResult.CommandResultBase readResult);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IModbusDuplex/UpdateDiscreteSignalValue")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ModbusServiceLibrary.CommandResult.ReadSingleDiscreteSignalResult))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ModbusServiceLibrary.CommandResult.ReadSingleAnalogSignalResult))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ModbusServiceLibrary.CommandResult.ConnectToRtuResult))]
        void UpdateDiscreteSignalValue(ModbusServiceLibrary.CommandResult.CommandResultBase readResult);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IModbusDuplex/ChangeConnectionStatusToFalse")]
        void ChangeConnectionStatusToFalse(int rtuId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IModbusDuplexChannel : ClientWpfApp.ModbusServiceReference.IModbusDuplex, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ModbusDuplexClient : System.ServiceModel.DuplexClientBase<ClientWpfApp.ModbusServiceReference.IModbusDuplex>, ClientWpfApp.ModbusServiceReference.IModbusDuplex {
        
        public ModbusDuplexClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ModbusDuplexClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ModbusDuplexClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ModbusDuplexClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ModbusDuplexClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void ReadAnalogSignal(int rtuId, int signalAddress) {
            base.Channel.ReadAnalogSignal(rtuId, signalAddress);
        }
        
        public System.Threading.Tasks.Task ReadAnalogSignalAsync(int rtuId, int signalAddress) {
            return base.Channel.ReadAnalogSignalAsync(rtuId, signalAddress);
        }
        
        public void ReadDiscreteSignal(int rtuId, int signalAddress) {
            base.Channel.ReadDiscreteSignal(rtuId, signalAddress);
        }
        
        public System.Threading.Tasks.Task ReadDiscreteSignalAsync(int rtuId, int signalAddress) {
            return base.Channel.ReadDiscreteSignalAsync(rtuId, signalAddress);
        }
        
        public void WriteAnalogSignal(int rtuId, int signalAddress, double newValue) {
            base.Channel.WriteAnalogSignal(rtuId, signalAddress, newValue);
        }
        
        public System.Threading.Tasks.Task WriteAnalogSignalAsync(int rtuId, int signalAddress, double newValue) {
            return base.Channel.WriteAnalogSignalAsync(rtuId, signalAddress, newValue);
        }
        
        public void WriteDiscreteSignal(int rtuId, int signalAddress, string newValue) {
            base.Channel.WriteDiscreteSignal(rtuId, signalAddress, newValue);
        }
        
        public System.Threading.Tasks.Task WriteDiscreteSignalAsync(int rtuId, int signalAddress, string newValue) {
            return base.Channel.WriteDiscreteSignalAsync(rtuId, signalAddress, newValue);
        }
        
        public ModbusServiceLibrary.CommandResult.ConnectToRtuResult ConnectToRtu(int rtuId) {
            return base.Channel.ConnectToRtu(rtuId);
        }
        
        public System.Threading.Tasks.Task<ModbusServiceLibrary.CommandResult.ConnectToRtuResult> ConnectToRtuAsync(int rtuId) {
            return base.Channel.ConnectToRtuAsync(rtuId);
        }
    }
}
