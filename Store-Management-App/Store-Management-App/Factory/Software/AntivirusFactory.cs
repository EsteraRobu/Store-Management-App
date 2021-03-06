﻿using Store_Management_App.Decorators;

namespace Store_Management_App.Factory.Software {
    public class AntivirusFactory : ProductFactory {
        public override Product GetProduct(string name, double price, int quantity, IProvider provider) {
            LastId++;
            return new Software(LastId, name, price, quantity, provider);
        }
    }
}
