using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MarketLibrary
{
    public class DoublyLinkedList<T> : IEnumerable<T>  // двусвязный список
    {
        private Product head; // головной/первый элемент
        private Product tail; // последний/хвостовой элемент
        private int count;  // количество элементов в списке

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}