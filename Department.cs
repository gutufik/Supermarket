namespace MarketLibrary
{
    public class Department
    {
        private string name; //Название отдела
        private ListElement Root = new ListElement(new Product("Корень", 0)); //Заголовок списка.  Именно сюда добавляются новые товары
        private int count = 0; //Количество элементов
        public Department(string name)
        {
            Name = name;
            Root.Previous = Root; //Кольцевой
            Root.Next = Root;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //Добавить 
        //Операция "добавить в конец списка"
        public bool Add(Product product)
        {
            return Insert(count, product);
        }

        //Найти индекс по имени
        public int IndexOf(string productName)
        {
            ListElement e = Root.Next;
            for (int index = 0; index < count; index++)
            {
                if (e.GetProduct.Name == productName) return index;
                index++;
                e = e.Next;
            }
            return -1;
        }

        //Найти товар
        public int IndexOf(Product product)
        {
            return IndexOf(product.Name);
        }

        //Количество элементов
        public int Count
        {
            get { return count; }
        }

        //Операция "вставить перед указанным индексом"
        public bool Insert(int index, Product product)
        {
            //Имя товара должно быть уникальным для отдела
            if (IndexOf(product) >= 0) return false; //Отказ вставлять
            ListElement newElement = new ListElement(product);
            ListElement e = this[index];

            count++;
            if (e == null) e = Root;

            newElement.Next = e;
            newElement.Previous = e.Previous;
            newElement.Next.Previous = newElement;
            newElement.Previous.Next = newElement;
            return true;
        }


        //Вставить после или до товара с указанным именем
        //after - признак того, что надо вставлять "после"
        public bool Insert(string orientir, Product goods, bool after = false)
        {
            int index = IndexOf(orientir); //Поиск по имени
            if (index < 0) return false; //Анализ результата поиска
            if (after) index++;
            return Insert(index, goods);
        }


        //Получить доступ к элементу по его индексу
        public ListElement this[int index]
        {
            get
            {
                //Исправить возможную некорректность вызова
                if (count == 0) return null;
                if (index < 0) index = 0;
                if (index >= count) index = count;
                //Найти элемент
                ListElement e = Root.Next;
                for (int k = 0; k < index; k++) e = e.Next;
                return e;
            }
        }
        //Получить доступ по имени товара
        public ListElement this[string name]
        {
            get
            {
                ListElement e = Root;
                for (int k = 0; k < count; k++)
                {
                    e = e.Next;
                    if (e.GetProduct.Name == name)
                        return e;
                }
                return null; //Нет такого
            }
        }

        //Удалить по индексу
        public bool Remove(int index)
        {
            ListElement removed = this[index];
            if (removed == null) return false;
            removed.Previous.Next = removed.Next;
            removed.Next.Previous = removed.Previous;
            count--;
            return true;
        }

        //Удалить по имени товара
        //УДАЛИТЬ. ПО. ИМЕНИ. ТОВАРА.
        public bool Remove(string name)
        {
            ListElement removed = this[name];
            if (removed == null) return false;
            removed.Previous.Next = removed.Next;
            removed.Next.Previous = removed.Previous;
            count--;
            return true;
        }

        //Сумма
        public double Sum
        {
            get
            {
                double result = 0;
                for (int k = 0; k < count; k++)
                    result += this[k].GetProduct.Cost;
                return result;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
    
}
