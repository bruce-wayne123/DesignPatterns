using System;
using System.Collections.Generic;
using static DesignPatternsDemo.XMLConverter;

namespace DesignPatternsDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            LGRemoteControl lGRemoteControl = new LGRemoteControl(new LgTV());
            lGRemoteControl.SwitchOn();
            lGRemoteControl.SetChannel(201);
            lGRemoteControl.SwitchOff();

            SamsungRemoteControl samsungRemoteControl = new SamsungRemoteControl(new SamsungLEDTV());
            samsungRemoteControl.SwitchOn();
            samsungRemoteControl.SetChannel(850);
            samsungRemoteControl.SwitchOff();
            //Converted and printed the objects on console
            // var choclate = new IceCreamMaker();
            //
            // Console.WriteLine(choclate.Functionality());
            //
            //
            // InfyBAL infyBAL = new InfyBAL(new InfyDAL());
            // var employeeList = infyBAL.GetEmployeeList();
            // foreach (var employee in employeeList)
            //   {
            //       Console.WriteLine($"\n Employee ID:{employee.ID} \t Employee Name:{employee.Name} \t Employee Department:{employee.Department}");
            //    }
            // Console.ReadKey();

            #region Comments

            /* used code
             *
             *   var xmlConverter = new XMLConverter();
            var adapter = new XMLToJSONParser(xmlConverter);//Passed XML data to JSONparser to parse and print the result
            adapter.ConvertToJSON();
             *   var ceo = new CEO();
            ceo.Name = "James Gordan";
            ceo.Age = 53;

            var secondCEO = new CEO();
            Console.WriteLine(secondCEO);
             *  var cityDb = SingleTonDataContainer.Instance;
            var cityDb2 = SingleTonDataContainer.Instance;
             *  var messi = new PlayerData {PlayerNumber=10,PlayerName="MESSI",Position=PlayPosition.ATTACK};
            var copier = new PlayerDataCopier();
            var ramos = copier.DeepCopy<PlayerData>(messi);
            ramos.PlayerName = "RAMOS";
            ramos.PlayerNumber = 4;
            ramos.Position = PlayPosition.DEFENCE;
            Console.WriteLine($"\n Player Number:{messi.PlayerNumber} \t Player Name:{messi.PlayerName} \t Position:{messi.Position}");
            Console.WriteLine($"\n Player Number:{ramos.PlayerNumber} \t Player Name:{ramos.PlayerName} \t Position:{ramos.Position}");

             *
             *   var choclate = new IceCreamMaker();

            Console.WriteLine(choclate.Functionality());
             * var car = new CarBuilderFacade().Address.AtAddress("135 LA").AtCity("LOS ANGELES").Parts.WithColor("YELLOW").WithType("4T").Build();
            Console.WriteLine(car);
             var employee = new EmployeeDesignationBuilder();
            //EmployeeFluentBuilder employee=new EmployeeFluentBuilder();
            //employee.NameOfEmployee("Jack").DOBOfEmployee(new DateTime(2001,01,01)).AddressofEmployee("127,LA").DepartmentOfEmployee("Research");
            //Console.WriteLine(employee);

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
            */

            #endregion Comments
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