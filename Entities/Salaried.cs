using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    internal class Salaried : Employee
    {
        #region fields
        private double salary;
        #endregion

        #region properties
        public double Salary { get { return salary; } set { salary = value; } }
        #endregion

        #region constructor
        public Salaried(string id, string name, string address, string phone, long sin, double salary) : base(id, name, address, phone, sin)
        {
            this.salary = salary;
        }

        #endregion
    }
}
