using System;
using System.Collections.Generic;
using System.Text;

namespace MarketLibrary
{
    public class ListElement
    {
        ListElement previous;
        ListElement next;
        Product product;
        public ListElement()
        {
            previous = next = this;
            product = null;
        }
        //Конструктор с товаром
        public ListElement(Product product) : this()
        {
            this.product = product;
        }


        public ListElement Previous
        {
            get { return previous; }
            set { previous = value; }
        }
        public ListElement Next
        {
            get { return next; }
            set { next = value; }
        }

        public Product GetProduct
        {
            get { return product; }
        }

        public override string ToString()
        {
            return product.ToString();
        }
    }
}
