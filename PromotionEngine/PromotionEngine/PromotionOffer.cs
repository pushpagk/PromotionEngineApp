using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class PromotionOffer
    {
        public Dictionary<string, int> productOffer = new Dictionary<string, int>();
        public string inclusionType = "AND";
        public float OfferPrice;
    }
}
