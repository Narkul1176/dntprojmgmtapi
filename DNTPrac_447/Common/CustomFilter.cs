using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DNTPrac_447.Common
{
    public class CustomFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (DateTime.Now > DateTime.Parse("2026-01-22T4:57:00"))
            {
                context.Result = new ViewResult()
                {
                    ViewName = "PromotionOffer"
                };
            }
            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("After Exec of Create Action Method");
            base.OnActionExecuted(context);
        }
    }
}
