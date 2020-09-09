using PromotionEngine.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class Promotions : IPromotions
    {
        public List<PromotionOffer> GetAllPromotionOffers()
        {
            List<PromotionOffer> lstPromotions = new List<PromotionOffer>();

            PromotionOffer A = new PromotionOffer();
            A.productOffer.Add("A", 3);
            A.OfferPrice = 130;
            lstPromotions.Add(A);

            PromotionOffer B = new PromotionOffer();
            B.productOffer.Add("B", 2);
            B.OfferPrice = 45;
            lstPromotions.Add(B);

            PromotionOffer CD = new PromotionOffer();
            CD.productOffer.Add("C", 1);
            CD.productOffer.Add("D", 1);
            CD.OfferPrice = 30;
            lstPromotions.Add(CD);
            return lstPromotions;
        }
    }
   
}
