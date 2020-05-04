using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DesignPatternsDemo
{
    public class Car
    {
        #region Properties

        public int CarNo { get; set; }
        public string CarName { get; set; }
        public int Price { get; set; }

        private readonly List<Car> _carList;

        #endregion Properties

        #region Ctor

        public Car()
        {
            _carList = new List<Car>();
        }

        #endregion Ctor

        #region Methods

        public void AddCar(Car carObj) => _carList.Add(carObj);

        public void RemoveCar(Car carobj) => _carList.Remove(carobj);

        public string GetCarDetails() => string.Join(Environment.NewLine, _carList.Select(x => $"CarNo:{x.CarNo},Name:{x.CarName},Price:{x.Price}"));

        
        #endregion Methods
    }

    public class FileSaver
    {
        #region Methods

        public void SaveToFile(Car car, string fileName, bool overwrite = false)
        {
            if (overwrite || !File.Exists(fileName))
            {
                File.WriteAllText(fileName, car.GetCarDetails());
            }
        }


        #endregion Methods
    }

    public class User
    {
        #region Properties

        public Car carObj;

        #endregion Properties

        #region Ctor

        public User()
        {
            carObj = new Car();
            carObj.AddCar(new Car { CarNo = 1, CarName = "BMW X3", Price = 7800 });
            carObj.AddCar(new Car { CarNo = 2, CarName = "Audi Q3", Price = 9874 });
            carObj.AddCar(new Car { CarNo = 3, CarName = "Volkswagon GT", Price = 4120 });
            var fileName = @"C:\Users\jpatila3\Desktop\Ouput\CarData.txt";
            var fileSaver = new FileSaver();
            fileSaver.SaveToFile(carObj,fileName,true);
        }

        #endregion Ctor
    }
}