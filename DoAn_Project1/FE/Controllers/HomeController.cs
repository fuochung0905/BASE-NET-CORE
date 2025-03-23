using FE.Constants;
using FE.Helpers;
using FE.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MODELS.BASE;
using MODELS.DUAN.QUANLYCONGVIEC.Dtos;
using MODELS.DUAN.QUANLYCONGVIEC.Requests;
using MODELS.DUAN.QUANLYDUAN.Dtos;
using Newtonsoft.Json;

namespace FE.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        ICacheService _cacheService;

        public HomeController()
        {
            _cacheService = new InMemoryCache();
        }

        public IActionResult Index(Guid? Id) {
            var breadcrumbs = new List<MODELS.BREADCRUMB.Breadcrumb>
            {
                new MODELS.BREADCRUMB.Breadcrumb { Name = "Trang chủ", Url = "/" },
                new MODELS.BREADCRUMB.Breadcrumb { Name = "Dashboard", Url = "#", IsActive = true  }

            };

            ViewData["Breadcrumbs"] = breadcrumbs;
            GetPhanQuyen();
            var TongSoGioCong = this.PostAPI(URL_API.QUANLYCONGVIEC_GETTONGSOGIOCONG, new { taiKhoanId = Id });
            var tongSoGio = new MODELTongSoGioCong();
            if (TongSoGioCong.Status)
            {
                tongSoGio = JsonConvert.DeserializeObject<MODELTongSoGioCong>(TongSoGioCong.Data.ToString());
            }

            var tongSoCongViec = this.PostAPI(URL_API.QUANLYCONGVIEC_GETTONGSOCONGVIECTHEOUSER, new {taiKhoanId = Id});
            List<MODELTongSoCongViec> tongCongViec = [];
            if (tongSoCongViec.Status)
            {
                tongCongViec = JsonConvert.DeserializeObject<List<MODELTongSoCongViec>>(tongSoCongViec.Data.ToString());
            }
            var tongDuAnResponse = this.GetAPI(URL_API.QUANLYDUAN_GETTONGDUANTHEOTUNGIAIDOAN);
            List<MODELTongDuAn> tongDuAn = [];
            if (tongDuAnResponse.Status)
            {
                tongDuAn = JsonConvert.DeserializeObject<List<MODELTongDuAn>>(tongDuAnResponse.Data.ToString());
            }
            ViewBag.TongDuAn = tongDuAn;
            ViewBag.TongCongViec = tongCongViec;
            ViewBag.TongSoGio = tongSoGio;
            return View();
        }


        public IActionResult NoPermission()
        {
            return View("~/Views/Shared/NoPermission.cshtml");
        }

        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            return View("~/Views/Shared/Error.cshtml", exceptionFeature.Error.Message);
        }

        [HttpPost]
        public IActionResult UploadFile(IFormCollection data)
        {
            try
            {
                var multiForm = new System.Net.Http.MultipartFormDataContent();

                // add API method parameters
                foreach (var file in data.Files)
                {
                    multiForm.Add(new StreamContent(file.OpenReadStream()), "files", file.FileName);
                }

                multiForm.Add(new StringContent(data["FolderName"]), "FolderName");

                ResponseData response = this.PostFormDataAPI(URL_API.UPLOADFILE, multiForm);

                if (!response.Status)
                {
                    return Json(new { IsSuccess = false, Message = response.Message, Data = "" });
                }

                return Json(new { IsSuccess = true, Message = "", Data = "" });
            }
            catch (Exception ex)
            {
                string message = "Lỗi upload file: " + ex.Message;
                return Json(new { IsSuccess = false, Message = message, Data = "" });
            }
        }

        public IActionResult Download(string filePath)
        {
            try
            {
                string beAddress = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("BEFileUrl").Value.ToString();
                string fullPath = beAddress + filePath;
                using (var client = new HttpClient())
                {
                    using (var result = client.GetAsync(fullPath).Result)
                    {
                        var fileName = Path.GetFileName(fullPath);
                        var content = result.Content.ReadAsByteArrayAsync().Result;
                        var contentType = "application/octet-stream";

                        return File(content, contentType, fileName);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult ShowPopupDocumentReader(string documentUrl)
        {
            string beAddress = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("BEFileUrl").Value.ToString();
            string fullPath = "https://docviewer.sjob.vn/Home/ShowFromHost?documentUrl=" + documentUrl + "&host=" + beAddress;
            ViewBag.Src = fullPath;
            return PartialView("~/Views/Home/PopupDocumnetReader.cshtml");
        }

        public IActionResult ShowPartialUploadFileInGrid(List<MODELTepDinhKem> obj, string[]? fileValidate, bool isMultiple = true)
        {
            ViewBag.IsMultiple = isMultiple;
            ViewBag.FileValidate = fileValidate ?? MODELS.COMMON.CommonConst._fileValid;
            return PartialView("~/Views/Shared/Components/UploadFileInGrid.cshtml", obj);
        }

       

        public ActionResult ShowPopupScanQRCode()
        {
            return PartialView("~/Views/Home/PopupScanQRCode.cshtml");
        }
    }
}