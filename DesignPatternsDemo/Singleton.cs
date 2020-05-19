using System;
using System.Collections.Generic;
using System.IO;

namespace DesignPatternsDemo
{
    internal interface ISingleTonContainer
    {
        int GetPopulation(string cityName);
    }

    public class SingleTonDataContainer : ISingleTonContainer
    {
        private Dictionary<string, int> _capitals = new Dictionary<string, int>();

        public SingleTonDataContainer()
        {
            Console.WriteLine("Initalizing object");
            var cityList = File.ReadAllLines("Cities.txt");

            for (int i = 0; i < cityList.Length; i += 2)
            {
                _capitals.Add(cityList[i], int.Parse(cityList[i + 1]));
                Console.WriteLine($" \n City {cityList[i]} \t Population {int.Parse(cityList[i + 1])}");
            }
        }

        public int GetPopulation(string cityName)
        {
            return _capitals[cityName];
        }

        private static SingleTonDataContainer _instance = new SingleTonDataContainer();
        public static SingleTonDataContainer Instance = _instance;
    }
}