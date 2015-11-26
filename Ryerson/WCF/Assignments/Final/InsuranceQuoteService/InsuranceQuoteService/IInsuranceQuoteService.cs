using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace InsuranceQuoteService
{
    // NOTE: If you change the interface name "IService1" here, you must also update the reference to "IService1" in Web.config.
    [ServiceContract]
    public interface IInsuranceQuoteService
    {

        [OperationContract]
        [FaultContract(typeof(FaultInfo))]
        InsuranceQuoteResponseMessage GetQuoteUsingMessageContract(InsuranceQuoteRequestMessage requestMessage);

        [OperationContract]
        [FaultContract(typeof(FaultInfo))]
        InsuranceQuoteInfo GetQuote(InsuredInfo insuredInformation);

    }
    
    [DataContract]
    public class FaultInfo
    {
        const string FAULT_REASON_MSG = "An exception has occurred. See details below:\n\n{0}";
        private string m_strReason;

        public FaultInfo(string strReason)
        {
            m_strReason = string.Format(FAULT_REASON_MSG, strReason);
        }
 
        [DataMember] 
        public string Reason
        {
            get{ return m_strReason;}
            set{ m_strReason = value;}
        }    
    }
 
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class InsuredInfo
    {
        private string m_strName;
        private string m_strAge;
        private string m_strAddress;
        private string m_strVehicleMake;
        private int m_intVehicleYearBuilt;

        [DataMember]
        public string Name
        {
            get { return m_strName; }
            set { m_strName = value; }
        }

        [DataMember]
        public string Age
        {
            get { return m_strAge; }
            set { m_strAge = value; }
        }

        [DataMember]
        public string Address
        {
            get { return m_strAddress; }
            set { m_strAddress = value; }
        }

        [DataMember]
        public string VehicleMake
        {
            get { return m_strVehicleMake; }
            set { m_strVehicleMake = value; }
        }

        [DataMember]
        public int VehicleYearBuilt
        {
            get { return m_intVehicleYearBuilt; }
            set { m_intVehicleYearBuilt = value; }
        }
        
        //public override string ToString()
        //{
        //    string strResult = string.Format("Name: {0}\n" +
        //                                 "Age: {1}\n" +
        //                                 "Address: {2}\n" +
        //                                 "Vehicle Make: {3}\n" +
        //                                 "Vehicle Year Built: {4}\n",
        //                                 m_strName, m_strAge, m_strAddress,
        //                                 m_strVehicleMake, m_strVehicleYearBuilt);

        //    return strResult;
        //}
    }

    [DataContract]
    public class InsuranceQuoteInfo
    {
        private double m_dblBaseAmount;
        private double m_dblAgeAmount;
        private double m_dblCarAmount;
        private double m_dblMonthlyTotal;

        [DataMember]
        public double BaseAmount
        {
            get { return m_dblBaseAmount; }
            set { m_dblBaseAmount = value; }
        }

        [DataMember]
        public double AgeAmount
        {
            get { return m_dblAgeAmount; }
            set { m_dblAgeAmount = value; }
        }

        [DataMember]
        public double CarAmount
        {
            get { return m_dblCarAmount; }
            set { m_dblCarAmount = value; }
        }

        [DataMember]
        public double MontlyTotal
        {
            get { return m_dblMonthlyTotal; }
            set { m_dblMonthlyTotal = value; }
        }
    }
    
    [MessageContract(IsWrapped = false)]
    public class InsuranceQuoteRequestMessage
    {
        private InsuredInfo m_objInsuredInfo; 

        [MessageHeader]
        public InsuredInfo InsuredInformation
        {
            get { return m_objInsuredInfo; }
            set { m_objInsuredInfo = value; }
        }        
    }

    [MessageContract(IsWrapped = false)]
    public class InsuranceQuoteResponseMessage
    {
        private InsuranceQuoteInfo m_objQuoteInfo;

        [MessageBodyMember]
        public InsuranceQuoteInfo QuoteInformation
        {
            get { return m_objQuoteInfo; }
            set { m_objQuoteInfo = value; }
        }
    }
}
