using System;
using System.Collections.Generic;

namespace MarketLibrary
{
    public class Department
    {
        private string name { get; set; }
        private int totalPrice { get; set; }
        private DoublyLinkedList<Product> products { get; set; }

        public void AddProduct(Product newProduct)
        { }
        public void DeleteProduct()
        { }
    }
    
}
