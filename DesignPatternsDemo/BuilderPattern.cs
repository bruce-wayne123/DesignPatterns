using System;
using System.Collections.Generic;
using System.ComponentModel;

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
        private Vehicle vehicle = new Vehicle();

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
        private Vehicle objVehicle = new Vehicle();

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
        public string FullName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
    }

    public class EmployeeFluentBuilder
    {
        private FluentEmployee employee = new FluentEmployee();

        public EmployeeFluentBuilder NameOfEmployee(string name)
        {
            employee.FullName = name;
            return this;
        }

        public EmployeeFluentBuilder DOBOfEmployee(DateTime dob)
        {
            employee.DateofBirth = dob;
            return this;
        }

        public EmployeeFluentBuilder DepartmentOfEmployee(string dept)
        {
            employee.Department = dept;
            return this;
        }

        public EmployeeFluentBuilder AddressofEmployee(string address)
        {
            employee.Address = address;
            return this;
        }

        public override string ToString()
        {
            return $"Here are following details of requested employee   Name:{employee.FullName}   DOB:{ employee.DateofBirth}  Department:{employee.Department} Address:{ employee.Address}";
        }
    }

    public class EmployeeNormal
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} , Position :{Designation},Salary{Salary}";
        }
    }

    public class EmployeeBuilder
    {
        protected EmployeeNormal employee = new EmployeeNormal();

        public EmployeeBuilder SetName(string Name)
        {
            employee.Name = Name;
            return this;
        }
    }

    public class EmployeeDesignationBuilder : EmployeeBuilder
    {
        public EmployeeDesignationBuilder SetDesignation(string designation)
        {
            employee.Designation = designation;
            return this;
        }
    }

    public class MyCar
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public int NumberOfDoors { get; set; }

        public string City { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"CarType: {Type}, Color: {Color}, Number of doors: {NumberOfDoors}, Manufactured in {City}, at address: {Address}";
        }
    }

    public class CarBuilderFacade
    {
        protected MyCar CarObj;

        public CarBuilderFacade()
        {
            CarObj = new MyCar();
        }

        public MyCar Build() => CarObj;

        public CarPartsBuilder Parts => new CarPartsBuilder(CarObj);
        public CarAddressBuilder Address => new CarAddressBuilder(CarObj);
    }

    public class CarPartsBuilder : CarBuilderFacade
    {
        public CarPartsBuilder(MyCar car)
        {
            CarObj = car;
        }

        public CarPartsBuilder WithType(string type)
        {
            CarObj.Type = type;
            return this;
        }

        public CarPartsBuilder WithColor(string color)
        {
            CarObj.Color = color;
            return this;
        }
    }

    public class CarAddressBuilder : CarBuilderFacade
    {
        public CarAddressBuilder(MyCar car)
        {
            CarObj = car;
        }

        public CarAddressBuilder AtAddress(string address)
        {
            CarObj.Address = address;
            return this;
        }

        public CarAddressBuilder AtCity(string city)
        {
            CarObj.City = city;
            return this;
        }
    }

    public interface IIceCream
    {
        string Functionality();
    }

    public class ChoclateIceCream : IIceCream
    {
        public string Functionality()
        {
            return ("Here is your choclate IceCream!! Enjoy :)");
        }
    }

    public class VanillaIceCream : IIceCream
    {
        public string Functionality()
        {
            return ("Here is your vanilla IceCream!! Enjoy :)");
        }
    }

    public class ButterScotchIceCream : IIceCream

    {
        public string Functionality()
        {
            return ("Here is your ButterScotch IceCream!! Enjoy :)");
        }
    }

    public class IceCreamMaker
    {
       //public static IIceCream GetFlavour(int flavour)
       //{
       //    switch (flavour)
       //    {
       //        case 1:new ChoclateIceCream();
       //            break;
       //        case 2:
       //            new VanillaIceCream();
       //            break;
       //        case 3:
       //            new ButterScotchIceCream();
       //            break;
       //        default:new ChoclateIceCream();
       //            break;
       //    }
       //}
    }
}