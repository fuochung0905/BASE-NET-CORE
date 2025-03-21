using FE.Helpers;
using Microsoft.AspNetCore.Mvc;
using MODELS.HETHONG.TAIKHOAN.Dtos;
using MODELS.HETHONG.VAITRO.Dtos;
using Newtonsoft.Json;

namespace PROJECTBASE.Views.Shared.Components.LeftMenu
{
    public class LeftMenuViewComponent : ViewComponent
    {
        ICacheService _cacheService;

        public LeftMenuViewComponent()
        {
            _cacheService = new InMemoryCache();
        }

        public IViewComponentResult Invoke()
        {
            List<MODELMenu> menu = new List<MODELMenu>();
            List<MODELNhomQuyen> nhomQuyen = new List<MODELNhomQuyen>();

            //Lấy cache
            string cacheMenu = _cacheService.Get<string>(User.Identity.Name + "_menu");
            if (!string.IsNullOrEmpty(cacheMenu))
            {
                menu = JsonConvert.DeserializeObject<List<MODELMenu>>(cacheMenu);
            }
            string cacheGroupRole = _cacheService.Get<string>(User.Identity.Name + "_grouprole");
            if (!string.IsNullOrEmpty(cacheGroupRole))
            {
                nhomQuyen = JsonConvert.DeserializeObject<List<MODELNhomQuyen>>(cacheGroupRole);
            }

            ViewBag.MENUHEADER = nhomQuyen.OrderBy(x => x.Sort).ToList();
            ViewBag.MENUITEM = menu.Where(x => x.IsShowMenu).ToList();
            return View();
        }
    }
}
