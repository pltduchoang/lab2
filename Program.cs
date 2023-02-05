using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Entities;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {

        public static double totalPay = 0;
        public static double totalPerson = 0;       
        public List<Employee> employeeList = new List<Employee>();
        public List<Salaried> salariedList = new List<Salaried>();
        public List<Wages> wagesList= new List<Wages>();
        public List<PartTime> partimeList = new List<PartTime>();

        public string PercentageOfEmployee ()
        {
            double numberOfSalaryPerson = salariedList.Count;
            double numberOfWagesPerson = wagesList.Count;
            double numberOfPartimePerson = partimeList.Count;
            double totalEmployee = employeeList.Count;

            double salaryPercentage = numberOfSalaryPerson / totalEmployee;
            double wagePercentage = numberOfWagesPerson / totalEmployee;
            double partimePercentage = numberOfPartimePerson / totalEmployee;
            
            
            string message = string.Format("The ratio of Salaried Employee is {0:P2}, Waged Employee is {1:P2}, Part-timed is {2:P2}",salaryPercentage,wagePercentage,partimePercentage);
            return message;
        }

        public string FindHighestWagePay()
        {
            double highestWagePay = 0;
            string highestWageperson = null;
            foreach (Wages person in wagesList) 
            {
                if (person.Hour <= 40) {
                    double pay = person.Rate * person.Hour;
                    if (pay > highestWagePay)
                    {
                        highestWagePay = pay;
                        highestWageperson = person.Name;
                    }
                }
                else
                {
                    double pay = (person.Rate * 40) + (person.Rate *1.5)*(person.Hour - 40);
                    if (pay > highestWagePay)
                    {
                        highestWagePay = pay;
                        highestWageperson = person.Name;
                    }
                }
                
            }
            string message = string.Format("The highest pay in Wage is {0:C2}, and that employee is {1}",highestWagePay, highestWageperson);
            return message;
        }

        public string FindLowestSalaryPay()
        {
            string lowestPayPerson = null;
            double lowestSalaryPay = 9999999999;
            foreach (Salaried person in salariedList)
            {
                if (person.Salary <= lowestSalaryPay)
                {
                    lowestSalaryPay = person.Salary;
                    lowestPayPerson = person.Name;
                }
            }
            string message = string.Format("The lowest pay in Slary is {0:C2}, and that employee is {1}", lowestSalaryPay, lowestPayPerson);
            return message;
        }
        public double FindAveragePay()
        {
            foreach (Employee person in employeeList)
            {
                if (person is Salaried salaried)
                {
                    double pay = salaried.Salary;
                    totalPay = totalPay + pay;
                    totalPerson += 1;
                }
                else if (person is Wages wages)
                {
                    double hourWork = wages.Hour;
                    double rateWork = wages.Rate;
                   
                    if ( hourWork <= 40)
                    {
                        double pay = hourWork * rateWork;
                        totalPay = totalPay + pay;
                        totalPerson += 1;
                    }
                    else
                    {
                        double pay = (rateWork * 40) + ((rateWork * 1.5) * (hourWork - 40));
                        totalPay = totalPay + pay;
                        totalPerson += 1;
                    }
                  
                }
                else if (person is PartTime parttime)
                {
                    double rateWork = parttime.Rate;
                    double hourWork = parttime.Hour;
                    double pay = hourWork * rateWork;
                    totalPay = totalPay + pay;
                    totalPerson += 1;
                }

            }
            double averagePay = totalPay / totalPerson;
            return averagePay;
        }

        

            static void Main(string[] args)
            {
                string path = "employees.txt";

                string[] lines;

                lines = File.ReadAllLines(path);

                Program program = new Program();

                

                foreach (string line in lines)
                {
                    string[] parts;

                    parts = line.Split(':');

                    string id = parts[0];

                    string name = parts[1];

                    string address = parts[2];

                    string phone = parts[3];

                    long sin = long.Parse(parts[4]);

                    double hour = double.Parse(parts[7]);

                    string firstDigit;

                    firstDigit = id.Substring(0, 1);

                    int firstDigitNum = int.Parse(firstDigit);

                    if (firstDigitNum >= 0 && firstDigitNum <= 4)
                    {
                        double salary = double.Parse(parts[7]);

                        Salaried salaried;

                        salaried = new Salaried(id, name, address, phone, sin, salary);

                        program.employeeList.Add(salaried);
                        program.salariedList.Add(salaried);
                    }
                    else if (firstDigitNum >= 5 && firstDigitNum <= 7)
                    {
                        double rate = double.Parse(parts[8]);

                        Wages wages;

                        wages = new Wages(id, name, address, phone, sin, hour, rate);

                        program.employeeList.Add(wages);
                        program.wagesList.Add(wages);

                    }
                    else if (firstDigitNum >= 8 && firstDigitNum <= 9)
                    {
                        double rate = double.Parse(parts[8]);

                        PartTime parttime;

                        parttime = new PartTime(id, name, address, phone, sin, hour, rate);

                        program.employeeList.Add(parttime);
                        program.partimeList.Add(parttime);
                    }
                }
            double averagePayResult = program.FindAveragePay();
            string averagePayMessage = string.Format("The average pay is {0:C2}", averagePayResult);
            Console.WriteLine(averagePayMessage);
            string highestPayMessage = program.FindHighestWagePay();
            Console.WriteLine(highestPayMessage);
            string lowestPayMessage = program.FindLowestSalaryPay();
            Console.WriteLine(lowestPayMessage);
            string percentageOfSalary = program.PercentageOfEmployee();
            Console.WriteLine(percentageOfSalary);
            }
        
    } 
}
