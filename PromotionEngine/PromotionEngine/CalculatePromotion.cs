using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine
{
    public class CalculatePromotion
    {
        private Promotions _promotions;
        public CalculatePromotion(Promotions promotions)
        {
            _promotions = promotions;
        }
        // Calculates the  total price after applying the promotions.
        public float CalculatePromotions(Dictionary<string, int> SalesInvoice)
        {
            Products products = new Products(); 
            float totalPrice = 0;
            float promotionsOffers = 0;
            // Apply each promotion and get the aggreageted offervalue.     
            foreach (var promotion in _promotions.GetAllPromotionOffers())
            {
                var offer = ApplyPromotion(promotion, SalesInvoice);
                promotionsOffers = promotionsOffers + offer;
            }

            // Calculate the total price for non promotion items
            var saleList = new List<string>(SalesInvoice.Keys);
            foreach (var sale in saleList)
            {
                var price = products.SKUs[sale] * SalesInvoice[sale];
                totalPrice = totalPrice + price; 
            }
            
            return promotionsOffers + totalPrice;
        }

        #region ApplyPromotion
        float ApplyPromotion(PromotionOffer promotions, Dictionary<string, int> SalesInvoice)
        {

            if (promotions.productOffer.Count == 1)// Single promotion
            {
                var key = promotions.productOffer.ElementAt(0).Key;
                if (SalesInvoice.ContainsKey(key))
                {
                    int quantityInvoice = SalesInvoice[key];
                    int offerQuantity = promotions.productOffer[key];
                    int offerscount = quantityInvoice / offerQuantity;
                    int remainingQuantity = quantityInvoice % offerQuantity;
                    SalesInvoice[key] = remainingQuantity;
                    return offerscount * promotions.OfferPrice;
                }
            }
            else
            {  
                // Combi product promotion
                var key1 = promotions.productOffer.ElementAt(0).Key;
                var key2 = promotions.productOffer.ElementAt(1).Key; ;
                if (SalesInvoice.ContainsKey(key1) && SalesInvoice.ContainsKey(key2))
                {
                    int quantityInvoice1 = SalesInvoice[key1];
                    int offerQuantity1 = promotions.productOffer[key1];
                    int offerscount1 = quantityInvoice1 / offerQuantity1;
                    int remainingQuantity1 = quantityInvoice1 % offerQuantity1;

                    int quantityInvoice2 = SalesInvoice[key2];
                    int offerQuantity2 = promotions.productOffer[key2];
                    int offerscount2 = quantityInvoice2 / offerQuantity2;
                    int remainingQuantity2 = quantityInvoice2 % offerQuantity2;

                    if (offerscount1 <= offerscount2)
                    {
                        SalesInvoice[key1] = remainingQuantity1;
                        SalesInvoice[key2] = remainingQuantity2 + (offerQuantity2 * (offerscount2 - offerscount1));
                        return offerscount1 * promotions.OfferPrice;
                    }
                    else
                    {
                        SalesInvoice[key1] = remainingQuantity1 + (offerQuantity1 * (offerscount1 - offerscount2));
                        SalesInvoice[key2] = remainingQuantity2;
                        return offerscount2 * promotions.OfferPrice;
                    }
                }
            }
            return 0;
        }
        #endregion
    }
}
