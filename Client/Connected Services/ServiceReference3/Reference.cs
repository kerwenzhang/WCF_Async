﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ServiceReference3 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference3.IService3")]
    public interface IService3 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService3/GetData", ReplyAction="http://tempuri.org/IService3/GetDataResponse")]
        string GetData(string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService3/GetData", ReplyAction="http://tempuri.org/IService3/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService3Channel : Client.ServiceReference3.IService3, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service3Client : System.ServiceModel.ClientBase<Client.ServiceReference3.IService3>, Client.ServiceReference3.IService3 {
        
        public Service3Client() {
        }
        
        public Service3Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service3Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service3Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service3Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(string message) {
            return base.Channel.GetData(message);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(string message) {
            return base.Channel.GetDataAsync(message);
        }
    }
}