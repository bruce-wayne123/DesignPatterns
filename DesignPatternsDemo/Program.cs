using System;
using System.Collections.Generic;

namespace DesignPatternsDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            EmployeeFluentBuilder employee=new EmployeeFluentBuilder();
            employee.NameOfEmployee("Jack").DOBOfEmployee(new DateTime(2001,01,01)).AddressofEmployee("127,LA").DepartmentOfEmployee("Research");
            Console.WriteLine(employee);

            //var carDetails = new Car();
            //carDetails.CarId = 1;
            //carDetails.CarName = "BMW X3";
            //carDetails.MFGDate = new DateTime(2020,05,03);
            //Console.WriteLine("Welcome here are the details");
            //Console.WriteLine("Car Id : {0} ,CarName : {1},MfgDate:{2}",carDetails.CarId,carDetails.CarName,carDetails.MFGDate);
            //var empManager = new EmployeeManager();
            //empManager.AddEmployee(new Employee { Gender = Gender.Female, Name = "Mary", Position = Position.Manager });
            //empManager.AddEmployee(new Employee { Gender = Gender.Female, Name = "Jessica", Position = Position.Executive });
            //empManager.AddEmployee(new Employee { Gender = Gender.Male, Name = "Shawn", Position = Position.Manager });
            //empManager.AddEmployee(new Employee { Gender = Gender.Female, Name = "Clary", Position = Position.Manager });

            //var employeeResearch = new EmployeeResearch(empManager);
            //Console.WriteLine("The total number of female managers are " + employeeResearch.CountFemaleManger());

            //    var sample = new Sample();
            //    var devReports = new List<DeveloperReport> {
            //    new DeveloperReport{
            //    Id=1,Name="Alex",Level="Senior Level",HourlyRate=37.5,WorkingHours=9
            //    },
            //        new DeveloperReport
            //    {
            //        Id = 2,
            //        Name = "Jessica",
            //        Level = "Junior Level",
            //        HourlyRate = 12,
            //        WorkingHours = 9
            //    },
            //    new DeveloperReport
            //    {
            //        Id = 3,
            //        Name = "Bob",
            //        Level = "Senior Level",
            //        HourlyRate = 65.5,
            //        WorkingHours = 9
            //    }
            //};
            //    //var calculator = new SalaryCalculator(devReports);
            //    Console.WriteLine($"Sum of all the developer salaries is {calculator.CalculateTotalSalaries()} dollars");
            //}
        }

        public class Sample
        {
            #region Properties

            public List<int> demoList;

            #endregion Properties

            public Sample()
            {
                demoList = new List<int>();
                demoList.Add(2);
                demoList.Add(17);
                demoList.Add(35);
                demoList.Add(36);
                demoList.Add(28);
                demoList.Add(25);
                var sampleList = IStringList;
            }

            public IEnumerable<int> IStringList
            {
                get
                {
                    foreach (var item in demoList)
                    {
                        if (item % 2 == 0)
                        {
                            yield return item;
                        }
                    }
                }
            }
        }

        public class Car
        {
            public int CarId { get; set; }
            public string CarName { get; set; }

            public DateTime MFGDate { get; set; }
        }
    }
}