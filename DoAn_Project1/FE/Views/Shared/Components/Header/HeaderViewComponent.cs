using FE.Helpers;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using MODELS.HETHONG;
using MODELS.HETHONG.TAIKHOAN.Dtos;
using Newtonsoft.Json;
using System.Security.Claims;

namespace PROJECTBASE.Views.Shared.Components.Header
{
    public class HeaderViewComponent : ViewComponent
    {
        ICacheService _cacheService;
        IHttpContextAccessor _contextAccessor;
        

        public HeaderViewComponent(IHttpContextAccessor contextAccessor)
        {
            _cacheService = new InMemoryCache();
            _contextAccessor = contextAccessor;
        }

        public IViewComponentResult Invoke()
        {
            MODELTaiKhoan model = new MODELTaiKhoan();
            var HostBE = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("BEFileUrl").Value.ToString();
            
            //Lấy cache
            string cacheInfo = _cacheService.Get<string>(User.Identity.Name + "_info");
            if (!string.IsNullOrEmpty(cacheInfo))
            {
                model = JsonConvert.DeserializeObject<MODELTaiKhoan>(cacheInfo);
                model.AnhDaiDien = HostBE + model.AnhDaiDien;
            }

            ViewBag.UserInfo = model;
            return View();
        }
    }
}
