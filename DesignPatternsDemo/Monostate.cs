﻿namespace DesignPatternsDemo
{
    public class CEO
    {
        private static string _name;
        private static int _age;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public int Age
        {
            get => _age;
            set => _age = value;
        }

        public override string ToString()
        {
            return $"Name:{Name} \t Age {Age}";
        }
    }



}