using FE.Constants;
using FE.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using MODELS.BASE;
using MODELS.DUAN.QUANLYCONGVIEC.Dtos;
using Newtonsoft.Json;
using System.Threading.Tasks;
using MODELS;
using MODELS.COMMON;
using MODELS.DUAN.QUANLYCONGVIEC.Requests;
using MODELS.DUAN.TRANGTHAICONGVIEC.Dtos;
using MODELS.DUAN.TRANGTHAICONGVIEC.Request;
using MODELS.HETHONG;
using MODELS.HETHONG.TAIKHOAN.Requests;
using Model.BASE;


namespace FE.Controllers.DUAN
{
    public class TrangThaiCongViecController : BaseController<TrangThaiCongViecController>
    {
	    private readonly IHttpContextAccessor _contextAccessor;

	    public TrangThaiCongViecController(IHttpContextAccessor contextAccessor)
	    {
		    _contextAccessor = contextAccessor;
	    }

        public IActionResult Index()
        {

            var breadcrumbs = new List<MODELS.BREADCRUMB.Breadcrumb>
            {
                new MODELS.BREADCRUMB.Breadcrumb { Name = "Trang chủ", Url = "/" },

                new MODELS.BREADCRUMB.Breadcrumb { Name = "Trạng thái công việc", Url = "#", IsActive = true  }

            };

            ViewData["Breadcrumbs"] = breadcrumbs;



            var tabs = new List<MODELS.HETHONG.TAB.Tab>
            {
                new MODELS.HETHONG.TAB.Tab { Id = "TrangThaiCongViecIndexTab", Name = "Trạng thái công việc", ControllerName = "TrangThaiCongViec" ,ActionName="IndexTab"},
                new MODELS.HETHONG.TAB.Tab { Id = "ThongKeKetQuaCongViecIndexTabT", Name = "Kết quả Tuần", ControllerName = "ThongKeKetQuaCongViec" ,ActionName="IndexTabT" },
                new MODELS.HETHONG.TAB.Tab { Id = "ThongKeKetQuaCongViecIndexTab", Name = "Kết quả tháng", ControllerName = "ThongKeKetQuaCongViec" ,ActionName="IndexTab" },
                new MODELS.HETHONG.TAB.Tab { Id = "ThongKeKetQuaCongViecIndexTabY", Name = "Kết quả năm", ControllerName = "ThongKeKetQuaCongViec" ,ActionName="IndexTabY" },


            };

            ViewData["tabs"] = tabs;
            GetPhanQuyen();

            var result = new MODELCheckPhanQuyen();
            var temp = new GetListPagingRequest();
            ResponseData response = this.PostAPI(URL_API.TRANGTHAICONGVIEC_CHECKROLE, temp);
            if (response.Status)
            {
                result = JsonConvert.DeserializeObject<MODELCheckPhanQuyen>(response.Data.ToString());
            }
            var user = _contextAccessor.HttpContext.User.Identity.Name;
            ResponseData response1 = this.PostAPI(URL_API.TAIKHOAN_GETBYUSERNAME, new GetByUserNameRequest { UserName = user });
            MODELTaiKhoan result1 = new();
            if (response1.Status)
            {
                result1 = JsonConvert.DeserializeObject<MODELTaiKhoan>(response1.Data.ToString());
            }
            if (result1.VaiTroId != Guid.Parse("F8ED5B61-4E04-4AE5-B84D-B21C42D4F7B3")) // Quản trị
            {
                ViewBag.UserId = result1.Id;
            }
            else
            {
                ViewBag.UserId = "";
            }
            return View("~/Views/DuAn/TrangThaiCongViec/Index.cshtml", result);
        }
        public IActionResult GetTask([DataSourceRequest] DataSourceRequest request, PostTrangThaiCongViecGetListPagingRequest param)
	    {
		    try
		    {
			    var result = new List<MODELCongViec>();
                param ??= new PostTrangThaiCongViecGetListPagingRequest();

                
                param.TextSearch = param.TextSearch?.Trim() ?? string.Empty;



                ResponseData response = this.PostAPI(URL_API.TRANGTHAICONGVIEC_GETLISTCONGVIEC, param);
			    DataSourceResult dataSourceResult = result.ToDataSourceResult(request);
			    if (response.Status)
			    {
				    var dataResult = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
				    result = JsonConvert.DeserializeObject<List<MODELCongViec>>(dataResult.Data.ToString());
				    dataSourceResult = result.ToDataSourceResult(request);
				    dataSourceResult.Total = dataResult.TotalRow;
				    dataSourceResult.Data = result;
			    }
			    else
			    {
				    throw new Exception(response.Message);
			    }

			    return Json(dataSourceResult);
		    }
		    catch (Exception ex)
		    {
			    return Json(new DataSourceResult
			    {
				    Errors = "Lỗi tải danh sách: " + ex.Message
			    });
		    }
	    }
		public ActionResult GetTaskStatuses([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var result = new List<MODELTrangThaiCongViec>();
                ResponseData response = this.PostAPI(URL_API.TRANGTHAICONGVIEC_GETLISTTRANGTHAICONGVIEC, request);
                DataSourceResult dataSourceResult = result.ToDataSourceResult(request);
                if (response.Status)
                {
                    result = JsonConvert.DeserializeObject<List<MODELTrangThaiCongViec>>(response.Data.ToString());
                    dataSourceResult = result.ToDataSourceResult(request);
                    dataSourceResult.Data = result;
                }
                else
                {
                    throw new Exception(response.Message);
                }

                return Json(dataSourceResult);
            }
            catch (Exception ex)
            {
                return Json(new DataSourceResult
                {
                    Errors = "Lỗi tải danh sách: " + ex.Message
                });
            }
        }

        [HttpPost]
        public JsonResult UpdateCongViec(PostCongViecByTrangThaiRequest request)
        {
            try
            {
                if (request != null && ModelState.IsValid)
                {
                    ResponseData response;
                    response = this.PostAPI(URL_API.TRANGTHAICONGVIEC_UPDATECONGVIEC, request);
                    if (!response.Status)
                    {
                        return Json(new { IsSuccess = false, Message = response.Message, Data = "" });
                    }
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "", Data = "" });
                }
                return Json(new { IsSuccess = true, Message = "", Data = "" });
            }
            catch (Exception ex)
            {
                string message = "Lỗi cập nhật thông tin: " + ex.Message;
                return Json(new { IsSuccess = false, Message = message, Data = "" });
            }
        }
        [HttpPost]
        public JsonResult UpdateTask(PostTrangThaiCongViecRequest request)
        {
	        try
	        {
		        if (request != null && ModelState.IsValid)
		        {
			        ResponseData response;
			        response = this.PostAPI(URL_API.TRANGTHAICONGVIEC_UPDATETRANGTHAICONGVIEC, request);
			        if (!response.Status)
			        {
				        return Json(new { IsSuccess = false, Message = response.Message, Data = "" });
			        }
		        }
		        else
		        {
			        return Json(new { IsSuccess = false, Message = "", Data = "" });
		        }
		        return Json(new { IsSuccess = true, Message = "", Data = "" });
			}
	        catch (Exception ex)
	        {
				string message = "Lỗi cập nhật thông tin: " + ex.Message;
				return Json(new { IsSuccess = false, Message = message, Data = "" });
			}
		}
        public IActionResult GetById(Guid Id)
        {
	        try
	        {
		        var result = new MODELQuanLyCongViec();
				ResponseData response = this.PostAPI(URL_API.TRANGTHAICONGVIEC_GETBYID, new { Id = Id });
				if (response.Status)
		        {
			        result = JsonConvert.DeserializeObject<MODELQuanLyCongViec>(response.Data.ToString());
		        }
		        else
		        {
			        throw new Exception(response.Message);
		        }

		        return PartialView("~/Views/DuAn/TrangThaiCongViec/PartialTrangThaiCongViecChiTiet.cshtml", result);
	        }
	        catch (Exception ex)
	        {
		        return Json("Lỗi công việc theo id");

	        }
        }
	}
}
