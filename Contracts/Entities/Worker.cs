using Contracts.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Constracts { get; set; } = new List<HourContract>();

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void addContract(HourContract contract)
        {
            Constracts.Add(contract);
        }

        public void removeContract(HourContract contract)
        {
            Constracts.Remove(contract);
        }

        public double income(int month, int year)
        {
         
            double valuePerHourTotal = BaseSalary;
            foreach (HourContract contract in Constracts) 
            {
                if (contract.Date.Month == month && contract.Date.Year == year)
                {   
                    valuePerHourTotal += contract.ValuePerHour * contract.Hours;
                }
            }
            return valuePerHourTotal;
        }
    }
}
