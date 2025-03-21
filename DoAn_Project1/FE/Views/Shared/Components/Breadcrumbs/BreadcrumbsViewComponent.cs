using Microsoft.AspNetCore.Mvc;
using MODELS.HETHONG;
using System.Security.Claims;

namespace PROJECTBASE.Views.Shared.Components.Breadcrumbs
{
    public class BreadcrumbsViewComponent : ViewComponent
    {
        IHttpContextAccessor _contextAccessor;

        public BreadcrumbsViewComponent(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public IViewComponentResult Invoke(List<MODELS.BREADCRUMB.Breadcrumb> items)
        {
            return View(items);
        }
     
    }
}
