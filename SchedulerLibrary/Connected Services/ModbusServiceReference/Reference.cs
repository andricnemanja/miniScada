﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchedulerLibrary.ModbusServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CommandResultBase", Namespace="http://schemas.datacontract.org/2004/07/ModbusServiceLibrary.CommandResult")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.ConnectToRtuResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.ConnectToRtuFailedResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.ReadSingleDiscreteSignalResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.ReadSingleDiscreteSignalFailedResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.ReadSingleAnalogSignalResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.ReadSingleAnalogSignalFailedResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.WriteDiscreteSignalCommandResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.WriteAnalogSignalCommandResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.CommandProcessorNotFoundResult))]
    public partial class CommandResultBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ConnectToRtuResult", Namespace="http://schemas.datacontract.org/2004/07/ModbusServiceLibrary.CommandResult")]
    [System.SerializableAttribute()]
    public partial class ConnectToRtuResult : SchedulerLibrary.ModbusServiceReference.CommandResultBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RtuIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RtuId {
            get {
                return this.RtuIdField;
            }
            set {
                if ((this.RtuIdField.Equals(value) != true)) {
                    this.RtuIdField = value;
                    this.RaisePropertyChanged("RtuId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ConnectToRtuFailedResult", Namespace="http://schemas.datacontract.org/2004/07/ModbusServiceLibrary.CommandResult")]
    [System.SerializableAttribute()]
    public partial class ConnectToRtuFailedResult : SchedulerLibrary.ModbusServiceReference.CommandResultBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RtuIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RtuId {
            get {
                return this.RtuIdField;
            }
            set {
                if ((this.RtuIdField.Equals(value) != true)) {
                    this.RtuIdField = value;
                    this.RaisePropertyChanged("RtuId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ReadSingleDiscreteSignalResult", Namespace="http://schemas.datacontract.org/2004/07/ModbusServiceLibrary.CommandResult")]
    [System.SerializableAttribute()]
    public partial class ReadSingleDiscreteSignalResult : SchedulerLibrary.ModbusServiceReference.CommandResultBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RtuIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SignalIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StateField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RtuId {
            get {
                return this.RtuIdField;
            }
            set {
                if ((this.RtuIdField.Equals(value) != true)) {
                    this.RtuIdField = value;
                    this.RaisePropertyChanged("RtuId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SignalId {
            get {
                return this.SignalIdField;
            }
            set {
                if ((this.SignalIdField.Equals(value) != true)) {
                    this.SignalIdField = value;
                    this.RaisePropertyChanged("SignalId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string State {
            get {
                return this.StateField;
            }
            set {
                if ((object.ReferenceEquals(this.StateField, value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ReadSingleDiscreteSignalFailedResult", Namespace="http://schemas.datacontract.org/2004/07/ModbusServiceLibrary.CommandResult")]
    [System.SerializableAttribute()]
    public partial class ReadSingleDiscreteSignalFailedResult : SchedulerLibrary.ModbusServiceReference.CommandResultBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RtuIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SignalIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RtuId {
            get {
                return this.RtuIdField;
            }
            set {
                if ((this.RtuIdField.Equals(value) != true)) {
                    this.RtuIdField = value;
                    this.RaisePropertyChanged("RtuId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SignalId {
            get {
                return this.SignalIdField;
            }
            set {
                if ((this.SignalIdField.Equals(value) != true)) {
                    this.SignalIdField = value;
                    this.RaisePropertyChanged("SignalId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ReadSingleAnalogSignalResult", Namespace="http://schemas.datacontract.org/2004/07/ModbusServiceLibrary.CommandResult")]
    [System.SerializableAttribute()]
    public partial class ReadSingleAnalogSignalResult : SchedulerLibrary.ModbusServiceReference.CommandResultBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RtuIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SignalIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double SignalValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RtuId {
            get {
                return this.RtuIdField;
            }
            set {
                if ((this.RtuIdField.Equals(value) != true)) {
                    this.RtuIdField = value;
                    this.RaisePropertyChanged("RtuId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SignalId {
            get {
                return this.SignalIdField;
            }
            set {
                if ((this.SignalIdField.Equals(value) != true)) {
                    this.SignalIdField = value;
                    this.RaisePropertyChanged("SignalId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double SignalValue {
            get {
                return this.SignalValueField;
            }
            set {
                if ((this.SignalValueField.Equals(value) != true)) {
                    this.SignalValueField = value;
                    this.RaisePropertyChanged("SignalValue");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ReadSingleAnalogSignalFailedResult", Namespace="http://schemas.datacontract.org/2004/07/ModbusServiceLibrary.CommandResult")]
    [System.SerializableAttribute()]
    public partial class ReadSingleAnalogSignalFailedResult : SchedulerLibrary.ModbusServiceReference.CommandResultBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RtuIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SignalIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RtuId {
            get {
                return this.RtuIdField;
            }
            set {
                if ((this.RtuIdField.Equals(value) != true)) {
                    this.RtuIdField = value;
                    this.RaisePropertyChanged("RtuId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SignalId {
            get {
                return this.SignalIdField;
            }
            set {
                if ((this.SignalIdField.Equals(value) != true)) {
                    this.SignalIdField = value;
                    this.RaisePropertyChanged("SignalId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WriteDiscreteSignalCommandResult", Namespace="http://schemas.datacontract.org/2004/07/ModbusServiceLibrary.CommandResult")]
    [System.SerializableAttribute()]
    public partial class WriteDiscreteSignalCommandResult : SchedulerLibrary.ModbusServiceReference.CommandResultBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RtuIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RtuId {
            get {
                return this.RtuIdField;
            }
            set {
                if ((this.RtuIdField.Equals(value) != true)) {
                    this.RtuIdField = value;
                    this.RaisePropertyChanged("RtuId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WriteAnalogSignalCommandResult", Namespace="http://schemas.datacontract.org/2004/07/ModbusServiceLibrary.CommandResult")]
    [System.SerializableAttribute()]
    public partial class WriteAnalogSignalCommandResult : SchedulerLibrary.ModbusServiceReference.CommandResultBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RtuIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RtuId {
            get {
                return this.RtuIdField;
            }
            set {
                if ((this.RtuIdField.Equals(value) != true)) {
                    this.RtuIdField = value;
                    this.RaisePropertyChanged("RtuId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CommandProcessorNotFoundResult", Namespace="http://schemas.datacontract.org/2004/07/ModbusServiceLibrary.CommandResult")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.CommandResultBase))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.ConnectToRtuResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.ConnectToRtuFailedResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.ReadSingleDiscreteSignalResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.ReadSingleDiscreteSignalFailedResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.ReadSingleAnalogSignalResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.ReadSingleAnalogSignalFailedResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.WriteDiscreteSignalCommandResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SchedulerLibrary.ModbusServiceReference.WriteAnalogSignalCommandResult))]
    public partial class CommandProcessorNotFoundResult : SchedulerLibrary.ModbusServiceReference.CommandResultBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object RtuCommandField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object RtuCommand {
            get {
                return this.RtuCommandField;
            }
            set {
                if ((object.ReferenceEquals(this.RtuCommandField, value) != true)) {
                    this.RtuCommandField = value;
                    this.RaisePropertyChanged("RtuCommand");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ModbusServiceReference.IModbusDuplex", CallbackContract=typeof(SchedulerLibrary.ModbusServiceReference.IModbusDuplexCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
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
        SchedulerLibrary.ModbusServiceReference.CommandResultBase ConnectToRtu(int rtuId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IModbusDuplex/ConnectToRtu", ReplyAction="http://tempuri.org/IModbusDuplex/ConnectToRtuResponse")]
        System.Threading.Tasks.Task<SchedulerLibrary.ModbusServiceReference.CommandResultBase> ConnectToRtuAsync(int rtuId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IModbusDuplexCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IModbusDuplex/ReceiveCommandResult")]
        void ReceiveCommandResult(SchedulerLibrary.ModbusServiceReference.CommandResultBase commandResult);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IModbusDuplexChannel : SchedulerLibrary.ModbusServiceReference.IModbusDuplex, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ModbusDuplexClient : System.ServiceModel.DuplexClientBase<SchedulerLibrary.ModbusServiceReference.IModbusDuplex>, SchedulerLibrary.ModbusServiceReference.IModbusDuplex {
        
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
        
        public SchedulerLibrary.ModbusServiceReference.CommandResultBase ConnectToRtu(int rtuId) {
            return base.Channel.ConnectToRtu(rtuId);
        }
        
        public System.Threading.Tasks.Task<SchedulerLibrary.ModbusServiceReference.CommandResultBase> ConnectToRtuAsync(int rtuId) {
            return base.Channel.ConnectToRtuAsync(rtuId);
        }
    }
}