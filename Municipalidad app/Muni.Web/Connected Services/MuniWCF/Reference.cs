﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Muni.Web.MuniWCF {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MuniWCF.IRegistros")]
    public interface IRegistros {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistros/ValidarUsuario", ReplyAction="http://tempuri.org/IRegistros/ValidarUsuarioResponse")]
        bool ValidarUsuario(string xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistros/ValidarUsuario", ReplyAction="http://tempuri.org/IRegistros/ValidarUsuarioResponse")]
        System.Threading.Tasks.Task<bool> ValidarUsuarioAsync(string xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistros/ReadUsuario", ReplyAction="http://tempuri.org/IRegistros/ReadUsuarioResponse")]
        string ReadUsuario(string xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistros/ReadUsuario", ReplyAction="http://tempuri.org/IRegistros/ReadUsuarioResponse")]
        System.Threading.Tasks.Task<string> ReadUsuarioAsync(string xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistros/CreateSolicitudJson", ReplyAction="http://tempuri.org/IRegistros/CreateSolicitudJsonResponse")]
        bool CreateSolicitudJson(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistros/CreateSolicitudJson", ReplyAction="http://tempuri.org/IRegistros/CreateSolicitudJsonResponse")]
        System.Threading.Tasks.Task<bool> CreateSolicitudJsonAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistros/ReadCollectionSolicitudJson", ReplyAction="http://tempuri.org/IRegistros/ReadCollectionSolicitudJsonResponse")]
        string ReadCollectionSolicitudJson();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistros/ReadCollectionSolicitudJson", ReplyAction="http://tempuri.org/IRegistros/ReadCollectionSolicitudJsonResponse")]
        System.Threading.Tasks.Task<string> ReadCollectionSolicitudJsonAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistros/ValidarUsuarioJson", ReplyAction="http://tempuri.org/IRegistros/ValidarUsuarioJsonResponse")]
        bool ValidarUsuarioJson(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistros/ValidarUsuarioJson", ReplyAction="http://tempuri.org/IRegistros/ValidarUsuarioJsonResponse")]
        System.Threading.Tasks.Task<bool> ValidarUsuarioJsonAsync(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistros/ReadUsuarioJson", ReplyAction="http://tempuri.org/IRegistros/ReadUsuarioJsonResponse")]
        string ReadUsuarioJson(string json);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistros/ReadUsuarioJson", ReplyAction="http://tempuri.org/IRegistros/ReadUsuarioJsonResponse")]
        System.Threading.Tasks.Task<string> ReadUsuarioJsonAsync(string json);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRegistrosChannel : Muni.Web.MuniWCF.IRegistros, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegistrosClient : System.ServiceModel.ClientBase<Muni.Web.MuniWCF.IRegistros>, Muni.Web.MuniWCF.IRegistros {
        
        public RegistrosClient() {
        }
        
        public RegistrosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RegistrosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RegistrosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RegistrosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool ValidarUsuario(string xml) {
            return base.Channel.ValidarUsuario(xml);
        }
        
        public System.Threading.Tasks.Task<bool> ValidarUsuarioAsync(string xml) {
            return base.Channel.ValidarUsuarioAsync(xml);
        }
        
        public string ReadUsuario(string xml) {
            return base.Channel.ReadUsuario(xml);
        }
        
        public System.Threading.Tasks.Task<string> ReadUsuarioAsync(string xml) {
            return base.Channel.ReadUsuarioAsync(xml);
        }
        
        public bool CreateSolicitudJson(string json) {
            return base.Channel.CreateSolicitudJson(json);
        }
        
        public System.Threading.Tasks.Task<bool> CreateSolicitudJsonAsync(string json) {
            return base.Channel.CreateSolicitudJsonAsync(json);
        }
        
        public string ReadCollectionSolicitudJson() {
            return base.Channel.ReadCollectionSolicitudJson();
        }
        
        public System.Threading.Tasks.Task<string> ReadCollectionSolicitudJsonAsync() {
            return base.Channel.ReadCollectionSolicitudJsonAsync();
        }
        
        public bool ValidarUsuarioJson(string json) {
            return base.Channel.ValidarUsuarioJson(json);
        }
        
        public System.Threading.Tasks.Task<bool> ValidarUsuarioJsonAsync(string json) {
            return base.Channel.ValidarUsuarioJsonAsync(json);
        }
        
        public string ReadUsuarioJson(string json) {
            return base.Channel.ReadUsuarioJson(json);
        }
        
        public System.Threading.Tasks.Task<string> ReadUsuarioJsonAsync(string json) {
            return base.Channel.ReadUsuarioJsonAsync(json);
        }
    }
}
