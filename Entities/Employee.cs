using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities
{
    internal class Employee
    {
        #region fields

        private string id;
        private string name;
        private string address;
        private string phone;
        private long sin;
        //private double hour;
        //private double rate;
        //private double salary;

        #endregion

        #region properties

        public string ID { get =>id; }
        public string Name { get => name; }
        public string Address { get => address; }
        public string Phone { get => phone; }
        public long Sin { get => sin; }





        #endregion

        #region constructor

        public Employee(string id, string name, string address, string phone, long sin) 
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
        }

        #endregion

    }


}
