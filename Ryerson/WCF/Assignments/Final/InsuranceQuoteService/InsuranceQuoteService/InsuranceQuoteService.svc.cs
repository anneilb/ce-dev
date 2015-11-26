using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace InsuranceQuoteService
{
    // NOTE: If you change the class name "Service1" here, you must also update the reference to "Service1" in Web.config and in the associated .svc file.
    public class InsuranceQuoteService : IInsuranceQuoteService
    {     
        #region IInsuranceQuoteService Members

        public InsuranceQuoteResponseMessage GetQuoteUsingMessageContract(InsuranceQuoteRequestMessage requestMessage)
        {
            InsuredInfo objInsuredInfo; //= new InsuredInfo();
            InsuranceQuoteInfo objQuoteInfo = new InsuranceQuoteInfo();

            objInsuredInfo = requestMessage.InsuredInformation;

            //Validate the Insured information sent with request message
            FaultInfo objFaultInfo = ValidateInsuredInfo(objInsuredInfo);

            if (objFaultInfo == null)
            {
                //Calculate insurance quote based on received info
                objQuoteInfo = CalculateQuote(objInsuredInfo);

                //Finally return the Quote
                InsuranceQuoteResponseMessage responseMessage = new InsuranceQuoteResponseMessage();
                responseMessage.QuoteInformation = objQuoteInfo;

                return responseMessage;
            }
            else
            {
                throw new FaultException<FaultInfo>(objFaultInfo, objFaultInfo.Reason);
            }
        }

        public InsuranceQuoteInfo GetQuote(InsuredInfo insuredInformation)
        {
            InsuranceQuoteInfo objQuoteInfo = new InsuranceQuoteInfo();

            //Validate the Insured information sent with request message
            FaultInfo objFaultInfo = ValidateInsuredInfo(insuredInformation);

            if (objFaultInfo == null)
            {
                //Calculate insurance quote based on received info
                objQuoteInfo = CalculateQuote(insuredInformation);
                return objQuoteInfo;
            }
            else
            {
                throw new FaultException<FaultInfo>(objFaultInfo, objFaultInfo.Reason);
            }
        }

        #endregion

        private FaultInfo ValidateInsuredInfo(InsuredInfo objInsuredInfo)
        {            
            FaultInfo objFaultInfo = null;
            string strReason = "";
            int intTemp = 0;

            //Validate presence of insured data
            if (objInsuredInfo == null)
            {             
                strReason = "Insured information is missing and is required.";   
            }
            else
            {
                //Validate age
                if (objInsuredInfo.Age.Length == 0)
                {
                    strReason = "Insured Age is missing and is required.";
                }
                else
                {
                    if (int.TryParse(objInsuredInfo.Age, out intTemp) == false)
                    {
                        strReason = "Insured Age must be a valid numeric value.";
                    }
                }
                
                //Validate Vehicle Year Built
                if (objInsuredInfo.VehicleYearBuilt == -1)
                {
                    if (strReason.Length > 0)
                    {
                        strReason += "\n";
                    }
                    
                    strReason += "Insured Vehicle Year Built is missing and is required.";                    
                }                
            }

            if (strReason.Length > 0)
            {
                objFaultInfo = new FaultInfo(strReason);
            }

            return objFaultInfo;
        }

        private InsuranceQuoteInfo CalculateQuote(InsuredInfo objInsuredInfo)
        {
            const double QUOTE_BASE_AMOUNT = 78;

            InsuranceQuoteInfo objQuoteInfo = new InsuranceQuoteInfo();
            double dblAgeAmount = 0;
            double dblCarAmount = 0;
            double dblMonthlyTotal = 0;

            //Parse strings to ints
            int intInsuredAge = int.Parse(objInsuredInfo.Age);
             
            //Determine the Age Amount
            if ((intInsuredAge >= 16) && (intInsuredAge <= 25))
            {
                dblAgeAmount = 50; 
            }
            else if ((intInsuredAge >= 26) && (intInsuredAge <= 65))
            {
                dblAgeAmount = 40;
            }
            else if (intInsuredAge > 65)
            {
                dblAgeAmount = 55;
            }

            //Determine the Car Amount
            if (objInsuredInfo.VehicleYearBuilt == 0)
            {
                dblCarAmount = 75;
            }
            else if(objInsuredInfo.VehicleYearBuilt == 1)
            {
                dblCarAmount = 85;
            }
            else if (objInsuredInfo.VehicleYearBuilt == 2)
            {
                dblCarAmount = 55;
            }

            //Calculate the monthly Quote Amount
            dblMonthlyTotal = QUOTE_BASE_AMOUNT + dblAgeAmount + dblCarAmount; 

            //Assign values and return Quote
            objQuoteInfo.BaseAmount = QUOTE_BASE_AMOUNT;
            objQuoteInfo.AgeAmount = dblAgeAmount;
            objQuoteInfo.CarAmount = dblCarAmount;
            objQuoteInfo.MontlyTotal = dblMonthlyTotal;

            return objQuoteInfo; 
        }
    }
}
