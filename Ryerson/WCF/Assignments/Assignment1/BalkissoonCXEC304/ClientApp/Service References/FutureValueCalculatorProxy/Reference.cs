﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientApp.FutureValueCalculatorProxy {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FutureValueCalculatorProxy.IFutureValueCalculator")]
    public interface IFutureValueCalculator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFutureValueCalculator/Calculate", ReplyAction="http://tempuri.org/IFutureValueCalculator/CalculateResponse")]
        double Calculate(double presentValue, double interestRate, int termInYears);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IFutureValueCalculatorChannel : ClientApp.FutureValueCalculatorProxy.IFutureValueCalculator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class FutureValueCalculatorClient : System.ServiceModel.ClientBase<ClientApp.FutureValueCalculatorProxy.IFutureValueCalculator>, ClientApp.FutureValueCalculatorProxy.IFutureValueCalculator {
        
        public FutureValueCalculatorClient() {
        }
        
        public FutureValueCalculatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FutureValueCalculatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FutureValueCalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FutureValueCalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double Calculate(double presentValue, double interestRate, int termInYears) {
            return base.Channel.Calculate(presentValue, interestRate, termInYears);
        }
    }
}
