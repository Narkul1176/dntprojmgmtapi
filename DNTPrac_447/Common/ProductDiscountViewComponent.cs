using DNTPrac_447.Models;
using Microsoft.AspNetCore.Mvc;

namespace DNTPrac_447.Common
{
    public class ProductDiscountViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int price)
        {
          
                int discountAmt = price * 10 / 100;
                int finalAmt = price - discountAmt;
                ProductDiscountViewModel obj = new ProductDiscountViewModel()
                {
                    OriginalPrice = price,
                    DiscountPrice = discountAmt,
                    FinalPrice = finalAmt
                };
            if (price > 30000)
            {
                return View("~/Views/Components/ProductDiscount/_ProductDiscount.cshtml", obj);
            }
            else
            {
                return View("~/Views/Components/ProductDiscount/_NoProductDiscount.cshtml", obj);
            }
        }
    }
}
