using Contracts.Entities;
using Contracts.Entities.Enums;
using System.Globalization;

namespace Contracts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name:");
            string department = Console.ReadLine();

            Console.WriteLine("Enter worker data:");
            Console.Write("Name:");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior):");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base Salary:");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(department);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker?");
            int numberContract = int.Parse(Console.ReadLine());           
           

            for (int i=0;i < numberContract;++i)
            {
                Console.WriteLine($"Enter #{i+1} contract data:");
                Console.Write("Date (DD/MM/YYYY):");
                DateTime dateTime = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per hour:");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours):");
                int duractionHour = int.Parse(Console.ReadLine());

                HourContract hourContract = new HourContract(dateTime, valuePerHour, duractionHour);

                worker.addContract(hourContract);
            }
            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY):");
            string dateIncome = Console.ReadLine();
            int month = int.Parse(dateIncome.Substring(0, 2));
            int year = int.Parse(dateIncome.Substring(3, 4));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine($"Income for {month}/{year}:" + worker.income(month, year).ToString( "F2", CultureInfo.InvariantCulture));

        }
    }
}