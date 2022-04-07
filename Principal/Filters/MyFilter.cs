using Microsoft.AspNetCore.Mvc.Filters;

namespace Principal.Filters
{
    public class MyFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Avant Exécution de l'action {context.ActionDescriptor.DisplayName}");
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Après Exécution de l'action {context.ActionDescriptor.DisplayName}");
            base.OnActionExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"Avant Exécution de la vue {context.ActionDescriptor.DisplayName}");
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"Après Exécution de la vue {context.ActionDescriptor.DisplayName}");
            base.OnResultExecuted(context);
        }
    }
}
