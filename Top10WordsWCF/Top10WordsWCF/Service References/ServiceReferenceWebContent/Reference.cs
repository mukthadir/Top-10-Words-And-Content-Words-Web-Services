﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Top10WordsWCF.ServiceReferenceWebContent {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceWebContent.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetWebContent", ReplyAction="http://tempuri.org/IService/GetWebContentResponse")]
        string GetWebContent(string url);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetWebContent", ReplyAction="http://tempuri.org/IService/GetWebContentResponse")]
        System.Threading.Tasks.Task<string> GetWebContentAsync(string url);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : Top10WordsWCF.ServiceReferenceWebContent.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<Top10WordsWCF.ServiceReferenceWebContent.IService>, Top10WordsWCF.ServiceReferenceWebContent.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetWebContent(string url) {
            return base.Channel.GetWebContent(url);
        }
        
        public System.Threading.Tasks.Task<string> GetWebContentAsync(string url) {
            return base.Channel.GetWebContentAsync(url);
        }
    }
}
