using Microsoft.AspNetCore.Mvc;

namespace Principal.ViewComponents
{
    public class Menu2ViewComponent : ViewComponent
    {

        #pragma warning disable 1998
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

    }
}
