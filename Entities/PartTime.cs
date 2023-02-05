using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    internal class PartTime : Employee
    {

        #region fields
        private double hour;
        private double rate;
        #endregion

        #region properties
        public double Hour { get { return hour; } }
        public double Rate { get { return rate; } set { rate = value; } }
        #endregion

        #region constructor
        public PartTime(string id, string name, string address, string phone, long sin, double hour, double rate) : base(id, name, address, phone, sin)
        {
            this.hour = hour;
            this.rate = rate;
        }
        #endregion

    }
}
