using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FailuresCommon
{
    public class SimVar
    {
        /// <summary>
        /// Definition for SimConnect
        /// </summary>
        public DEFINITION eDef = DEFINITION.Dummy;

        /// <summary>
        /// Request for SimConnect
        /// </summary>
        public REQUEST eRequest = REQUEST.Dummy;

        /// <summary>
        /// Event for SimConnect
        /// </summary>
        public EVENT eEvent = EVENT.Dummy;

        /// <summary>
        /// ID of SimVar
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// name of SimVar
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// represents sim variable string known by SimConnect
        /// </summary>
        public string simVariable { get; set; }

        /// <summary>
        /// unit of sim variable in case if nessecary
        /// </summary>
        public string unit { get; set; }

        /// <summary>
        /// domain of simVar (engine, avionics, fuel...)
        /// </summary>
        public string domain { get; set; }

        /// <summary>
        /// current value of simVar
        /// </summary>
        public double value { get; set; }

        /// <summary>
        /// value of failure (leak rate, possition of stuck gear...)
        /// </summary>
        public double failureValue { get; set; }

        /// <summary>
        /// value of SimVar before failure starts (usable for continous failures)
        /// </summary>
        public double beforeFailureValue { get; set; }


        /// <summary>
        /// if simVar is SimConnect event
        /// </summary>
        public bool isEvent { get; set; }

        /// <summary>
        /// if simVar is for failures or to read flight parameters
        /// </summary>
        public bool isFailable { get; set; }


        /// <summary>
        /// if failure type is leak
        /// </summary>
        public bool isLeak { get; set; }

        /// <summary>
        /// if failure type is stuck
        /// </summary>
        public bool isStuck { get; set; }

        /// <summary>
        /// if failure type is once complete failure
        /// </summary>
        public bool isCompleteFail { get; set; }

        /// <summary>
        /// if failure type is countinous changing failure (short circuit)
        /// </summary>
        public bool isContinousFail { get; set; }


        /// <summary>
        /// if failure already triggered
        /// </summary>
        public bool failed { get; set; }

        /// <summary>
        /// if failure started (usable for stuck and continous type of failures)
        /// </summary>
        public bool started { get; set; }

        /// <summary>
        /// random object for turning on and off continous event failures
        /// </summary>
        public Random random { get; set; }
    }
}
