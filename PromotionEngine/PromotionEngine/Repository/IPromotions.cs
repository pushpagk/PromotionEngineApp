using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Repository
{
    public interface IPromotions
    {
        List<PromotionOffer> GetAllPromotionOffers();
    }
}
