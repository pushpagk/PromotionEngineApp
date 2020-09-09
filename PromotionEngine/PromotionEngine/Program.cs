using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Promotions _promotions=new Promotions();
            CalculatePromotion objPromotion = new CalculatePromotion(_promotions);

            Dictionary<string, int> orders = new Dictionary<string, int>();
            orders.Add("A", 3);
            var totalPrice= objPromotion.CalculatePromotions(orders);
            Console.WriteLine("Total price of products is: "+totalPrice);
            Console.ReadLine();
        }
    }
}
