using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MarketLibrary
{
    class Market
    {
        private Department[] Queue; //Массив - кольцевая очередь.
        private int first = -1; //Начало очереди
        private int last = -1; //Конец очереди
        private int count = 0; //Количество элементов в очереди
        //Конструктор, возможно, с указанием размера очереди
        public Market(int Capacity = 10)
        {
            Queue = new Department[Capacity];
        }

        public Market(string FileName, int Capacity = 10) : this(Capacity)
        {
            Load(FileName);
        }

        //Информационные свойства
        //Количество элементов
        public int Count
        {
            get { return count; }
        }
        //Емкость
        public int Capacity
        {
            get { return Queue.Length; }
        }
        //Пустая ли
        public bool Empty
        {
            get { return Count == 0; }
        }
        //Полная ли
        public bool Full
        {
            get { return Count == Queue.Length; }
        }
        //Поместить в очередь
        public bool Push(Department department)
        {
            //Push возвращает false, если нет возможности добавить отдел
            //Поместить отдел в очередь.
            if (count >= Queue.Length) return false; //Очередь переполнена
            //У отдела должно быть уникальное имя
            if (this[department.Name] != null) return false;
            count++;
            //Поместить на место
            Queue[last = ++last % Queue.Length] = department;
            if (first < 0) first = 0;
            return true;
        }

        //Удалить отдел из очереди
        public Department Pop()
        {
            if (count == 0) return null; //Очередь пуста
            count--;
            return Queue[(first++ + Queue.Length) % Queue.Length];
        }

        //Получить отдел по порядковому номеру в очереди
        public Department this[int index]
        {
            get
            {
                return Queue[(first + index + Queue.Length) % Queue.Length];
            }
        }

        //Получить отдел по имени
        public Department this[string name]
        {
            get
            {
                if (count == 0) return null;
                for (int k = first < 0 ? 0 : ((first + Queue.Length) % Queue.Length); k != (last + 1) % Queue.Length; k = (++k) % Queue.Length)
                    if (Queue[k].Name == name) return Queue[k];
                return null;
            }
        }

        //Общая стоимость товаров
        public double Sum
        {
            get
            {
                double result = 0;
                for (int k = 0; k < Count; k++)
                    result += Queue[k].Sum;
                return result;
            }
        }

        //Сохранить
        public void Save(string FileName)
        {
            StreamWriter writer = new StreamWriter(FileName);
            writer.WriteLine(Count);
            for (int d = 0; d < Count; d++)
            {
                writer.WriteLine(Queue[d].Name);
                writer.WriteLine(Queue[d].Count);
                for (int b = 0; b < Queue[d].Count; b++)
                {
                    writer.WriteLine(Queue[d][b].GetProduct.Name);
                    writer.WriteLine(Queue[d][b].GetProduct.Cost);
                }
            }
            writer.Close();
        }

        //Загрузить
        private bool Load(string FileName)
        {
            if (!File.Exists(FileName)) return false;
            StreamReader reader = new StreamReader(FileName);
            int D = int.Parse(reader.ReadLine());
            for (int d = 0; d < D; d++)
            {
                Department department = new Department(reader.ReadLine());
                int B = int.Parse(reader.ReadLine());
                for (int b = 0; b < B; b++)
                {
                    Product g = new Product(reader.ReadLine(), double.Parse(reader.ReadLine()));
                    department.Add(g);
                }
                Push(department);
            }
            return true;
        }
    }
}
