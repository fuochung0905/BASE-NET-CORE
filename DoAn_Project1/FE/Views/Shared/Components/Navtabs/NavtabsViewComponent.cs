using Microsoft.AspNetCore.Mvc;
using MODELS.HETHONG.TAB;
using System.Security.Claims;

namespace PROJECTBASE.Views.Shared.Components.Navtabs
{
    public class NavtabsViewComponent : ViewComponent
    {
        IHttpContextAccessor _contextAccessor;

        public NavtabsViewComponent(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
		public IViewComponentResult Invoke(List<Tab> tabs, string activeTab, string navId)
		{
			
			ViewData["activeTab"] = activeTab;
			ViewData["navId"] = navId;
			return View(tabs);
		}

	}
}
