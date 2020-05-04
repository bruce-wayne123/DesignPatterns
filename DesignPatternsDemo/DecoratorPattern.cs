using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsDemo
{
    public interface ICar
    {
        string GetDescription();
        double GetCost();
    }

    public class EconomyCar : ICar
    {
        public double GetCost()
        {
            return 4521;
        }

        public string GetDescription()
        {
            return "Economy Car";
        }
    }

    public class DeluxCar : ICar
    {
        public double GetCost()
        {
            return 9471;
        }

        public string GetDescription()
        {
            return "Delux Car";
        }
    }

    public class SportsCar : ICar
    {
        public double GetCost()
        {
            return 7417;
        }

        public string GetDescription()
        {
            return "Sports Car";
        }
    }

    public class CarAccessoriesDecorator : ICar
    {
        private ICar _car;
        public CarAccessoriesDecorator(ICar car)
        {
            _car = car;

        }
        public virtual double GetCost()
        {
            return _car.GetCost();
        }

        public virtual string GetDescription()
        {
            return _car.GetDescription();
        }

    }

    public class BasicAccessories:CarAccessoriesDecorator
    {
        public BasicAccessories(ICar car):base(car)
        {

        }
    }


}
