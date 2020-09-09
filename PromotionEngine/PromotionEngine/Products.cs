using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class Products
    {
        public Dictionary<string, float> SKUs = new Dictionary<string, float>();
        public Products()
        {
            SKUs.Add("A", 50);
            SKUs.Add("B", 30);
            SKUs.Add("C", 20);
            SKUs.Add("D", 15);
        }
    }
}
