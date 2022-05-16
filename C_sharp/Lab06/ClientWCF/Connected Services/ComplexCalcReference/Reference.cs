﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientWCF.ComplexCalcReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ComplexCalcReference.ICCalculator")]
    public interface ICCalculator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICCalculator/add", ReplyAction="http://tempuri.org/ICCalculator/addResponse")]
        ContractWCFLibrary.Complex add(ContractWCFLibrary.Complex c1, ContractWCFLibrary.Complex c2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICCalculator/add", ReplyAction="http://tempuri.org/ICCalculator/addResponse")]
        System.Threading.Tasks.Task<ContractWCFLibrary.Complex> addAsync(ContractWCFLibrary.Complex c1, ContractWCFLibrary.Complex c2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICCalculator/sub", ReplyAction="http://tempuri.org/ICCalculator/subResponse")]
        ContractWCFLibrary.Complex sub(ContractWCFLibrary.Complex c1, ContractWCFLibrary.Complex c2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICCalculator/sub", ReplyAction="http://tempuri.org/ICCalculator/subResponse")]
        System.Threading.Tasks.Task<ContractWCFLibrary.Complex> subAsync(ContractWCFLibrary.Complex c1, ContractWCFLibrary.Complex c2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICCalculator/mul", ReplyAction="http://tempuri.org/ICCalculator/mulResponse")]
        ContractWCFLibrary.Complex mul(ContractWCFLibrary.Complex c1, ContractWCFLibrary.Complex c2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICCalculator/mul", ReplyAction="http://tempuri.org/ICCalculator/mulResponse")]
        System.Threading.Tasks.Task<ContractWCFLibrary.Complex> mulAsync(ContractWCFLibrary.Complex c1, ContractWCFLibrary.Complex c2);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICCalculatorChannel : ClientWCF.ComplexCalcReference.ICCalculator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CCalculatorClient : System.ServiceModel.ClientBase<ClientWCF.ComplexCalcReference.ICCalculator>, ClientWCF.ComplexCalcReference.ICCalculator {
        
        public CCalculatorClient() {
        }
        
        public CCalculatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CCalculatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CCalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CCalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ContractWCFLibrary.Complex add(ContractWCFLibrary.Complex c1, ContractWCFLibrary.Complex c2) {
            return base.Channel.add(c1, c2);
        }
        
        public System.Threading.Tasks.Task<ContractWCFLibrary.Complex> addAsync(ContractWCFLibrary.Complex c1, ContractWCFLibrary.Complex c2) {
            return base.Channel.addAsync(c1, c2);
        }
        
        public ContractWCFLibrary.Complex sub(ContractWCFLibrary.Complex c1, ContractWCFLibrary.Complex c2) {
            return base.Channel.sub(c1, c2);
        }
        
        public System.Threading.Tasks.Task<ContractWCFLibrary.Complex> subAsync(ContractWCFLibrary.Complex c1, ContractWCFLibrary.Complex c2) {
            return base.Channel.subAsync(c1, c2);
        }
        
        public ContractWCFLibrary.Complex mul(ContractWCFLibrary.Complex c1, ContractWCFLibrary.Complex c2) {
            return base.Channel.mul(c1, c2);
        }
        
        public System.Threading.Tasks.Task<ContractWCFLibrary.Complex> mulAsync(ContractWCFLibrary.Complex c1, ContractWCFLibrary.Complex c2) {
            return base.Channel.mulAsync(c1, c2);
        }
    }
}
