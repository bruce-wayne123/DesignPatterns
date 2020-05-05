using System;
using System.Collections.Generic;

namespace DesignPatternsDemo
{
    /// <summary>
    /// Product
    /// </summary>
    public class Vehicle
    {
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public string Body { get; set; }
        public List<string> Accessories { get; set; }

        public Vehicle()
        {
            Accessories = new List<string>();
        }

        public void ShowInfo()
        {
            Console.WriteLine("Model: {0}", Model);
            Console.WriteLine("Engine: {0}", Engine);
            Console.WriteLine("Body: {0}", Body);
            Console.WriteLine("Transmission: {0}", Transmission);
            Console.WriteLine("Accessories:");
            foreach (var accessory in Accessories)
            {
                Console.WriteLine("\t{0}", accessory);
            }
        }
    }

    /// <summary>
    /// Builder
    /// </summary>
    public interface IVehicleBuilder
    {
        void SetModel();

        void SetEngine();

        void SetTransmission();

        void SetBody();

        void SetAcessories();

        Vehicle GetVehicle();
    }


    /// <summary>
    /// ConcreteBuilder
    /// </summary>
    public class HeroBuilder : IVehicleBuilder
    {
        Vehicle vehicle = new Vehicle();
        public void SetAcessories()
        {
            vehicle.Accessories.Add("Seat Cover");
            vehicle.Accessories.Add("Rear Mirror");
        }

        public void SetBody()
        {
            vehicle.Body = "Plastic";
        }

        public void SetEngine()
        {
            vehicle.Engine = "4 Stroke";
        }

        public void SetModel()
        {
            vehicle.Model = "Hero";
        }

        public void SetTransmission()
        {
            vehicle.Transmission = "120 km/hr";
        }

        public Vehicle GetVehicle()
        {
            return vehicle;
        }
    }
    /// <summary>
    /// ConcreteBuilder
    /// </summary>
    public class HondaBuilder : IVehicleBuilder
    {
        Vehicle objVehicle = new Vehicle();
        public void SetModel()
        {
            objVehicle.Model = "Honda";
        }

        public void SetEngine()
        {
            objVehicle.Engine = "4 Stroke";
        }

        public void SetTransmission()
        {
            objVehicle.Transmission = "125 Km/hr";
        }

        public void SetBody()
        {
            objVehicle.Body = "Plastic";
        }

        public void SetAcessories()
        {
            objVehicle.Accessories.Add("Seat Cover");
            objVehicle.Accessories.Add("Rear Mirror");
            objVehicle.Accessories.Add("Helmet");
        }

        public Vehicle GetVehicle()
        {
            return objVehicle;
        }
    }

    /// <summary>
    /// Director
    /// </summary>
    public class VehicleCreator
    {
        private IVehicleBuilder vehicleBuilder;
        public VehicleCreator(IVehicleBuilder vehicleObjBuilder)
        {
            vehicleBuilder = vehicleObjBuilder;
        }
        public void CreateVehicle()
        {
            vehicleBuilder.SetBody();
            vehicleBuilder.SetAcessories();
            vehicleBuilder.SetEngine();
            vehicleBuilder.SetModel();
            vehicleBuilder.SetTransmission();
               
        }

        public Vehicle GetVehicle()
        {
            return vehicleBuilder.GetVehicle();
        }
    }

    public class FluentEmployee
    {
        public string FullName{get;set;}
        public DateTime DateofBirth{get;set;}
        public string Department{get;set;}
        public string Address{get;set;}
    }
    public class EmployeeFluentBuilder
    {
        FluentEmployee employee=new FluentEmployee();
        public EmployeeFluentBuilder NameOfEmployee(string name)
        {
            employee.FullName=name;
            return this;
        }
        public EmployeeFluentBuilder DOBOfEmployee(DateTime dob)
        {
            employee.DateofBirth=dob;
            return this;
        }
        public EmployeeFluentBuilder DepartmentOfEmployee(string dept)
        {
            employee.Department=dept;
            return this;
        }
        public EmployeeFluentBuilder AddressofEmployee(string address)
        {
            employee.Address=address;
            return this;
        }

        public override string ToString()
        {
            return $"Here are following details of requested employee   Name:{employee.FullName}   DOB:{ employee.DateofBirth}  Department:{employee.Department} Address:{ employee.Address}";
        }

    }

}



