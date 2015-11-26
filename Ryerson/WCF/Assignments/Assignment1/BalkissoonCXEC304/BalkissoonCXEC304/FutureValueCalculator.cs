using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BalkissoonCXEC304
{
    // NOTE: If you change the class name "Service1" here, you must also update the reference to "Service1" in App.config.
    public class FutureValueCalculator : IFutureValueCalculator 
    {
        #region IFutureValueCalculator Members

        public double Calculate(double presentValue, double interestRate, int termInYears)
        {
            double futureValue = 0;

            futureValue = presentValue * Math.Pow(1 + (interestRate / 100), termInYears);

            return futureValue;            
        }

        #endregion 
    }
}
