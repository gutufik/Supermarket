using System;
using System.Collections.Generic;
using System.Text;

namespace MarketLibrary
{
    public class Product
    {
        private string name;
        private double cost;
        //Конструктор
        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
        //Конструктор без параметров
        public Product() : this("", 0) { }

        //Свойства
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Cost
        {
            get { return cost; }
            set
            {
                if (value >= 0)
                    cost = value;
            }
        }

        //Для удобства сравнения
        public static bool operator ==(Product g1, Product g2)
        {
            return g1.Name == g2.Name;
        }
        public static bool operator !=(Product g1, Product g2)
        {
            return g1.Name != g2.Name;
        }

        //В виде строки
        public override string ToString()
        {
            return Name;
        }

        //Технические override 
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
