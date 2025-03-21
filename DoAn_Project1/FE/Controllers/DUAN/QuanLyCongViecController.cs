using FE.Constants;
using FE.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using MODELS;
using MODELS.BASE;
using MODELS.COMMON;
using MODELS.DUAN.LICHSUCONGVIEC.Dtos;
using MODELS.DUAN.QUANLYCONGVIEC.Dtos;
using MODELS.DUAN.QUANLYCONGVIEC.Requests;
using Newtonsoft.Json;
using MODELS.HETHONG;
using MODELS.HETHONG.TAIKHOAN.Requests;
using MODELS.DUAN.QUANLICONGVIEC_CHITIET.Requests;

using static System.Runtime.InteropServices.JavaScript.JSType;
using Model.BASE;

namespace FE.Controllers.DUAN
{
    public class QuanLyCongViecController : BaseController<QuanLyCongViecController>
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public QuanLyCongViecController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            //var breadcrumbs = new List<MODELS.BREADCRUMB.Breadcrumb>
            //{
            //    new MODELS.BREADCRUMB.Breadcrumb { Name = "Trang chủ", Url = "/" },
            //    new MODELS.BREADCRUMB.Breadcrumb { Name = "Quản lý công việc", Url = "#", IsActive = true  }

            //};

            //ViewData["Breadcrumbs"] = breadcrumbs;
            var user = _contextAccessor.HttpContext.User.Identity.Name;
            ResponseData response = this.PostAPI(URL_API.TAIKHOAN_GETBYUSERNAME, new GetByUserNameRequest { UserName = user });
            MODELTaiKhoan result = new();
            if (response.Status)
            {
                result = JsonConvert.DeserializeObject<MODELTaiKhoan>(response.Data.ToString());
            }
            if (result.VaiTroId != Guid.Parse("F8ED5B61-4E04-4AE5-B84D-B21C42D4F7B3")) // Quản trị
            {
                ViewBag.UserId = result.Id;
            }
            else
            {
                ViewBag.UserId = "";
            }
            return View("~/Views/DuAn/QuanLyCongViec/Index.cshtml", GetPhanQuyen());
		}

        public IActionResult GetTongSoLuongCongViec(Guid? Id)
        {
            try
            {
                var tongSoCongViec = this.PostAPI(URL_API.QUANLYCONGVIEC_GETTONGSOCONGVIECTHEOUSER, new { taiKhoanId = Id });
                List<MODELTongSoCongViec> tongCongViec = [];
                if (tongSoCongViec.Status)
                {
                    tongCongViec = JsonConvert.DeserializeObject<List<MODELTongSoCongViec>>(tongSoCongViec.Data.ToString());
                    return Json(tongCongViec);
                }
                else
                {
                    throw new Exception(tongSoCongViec.Message);
                }
            }
            catch (Exception ex)
            {
                return Json(new DataSourceResult
                {
                    Errors = "Lỗi tải danh sách: " + ex.Message
                });
            }
           
        }

        public IActionResult GetTongSoGioCong(Guid? Id)
        {
            try
            {
                var tongSoCongViec = this.PostAPI(URL_API.QUANLYCONGVIEC_GETTONGSOGIOCONG, new { taiKhoanId = Id });
                var tongSoGioCong = new MODELTongSoGioCong();
                if (tongSoCongViec.Status)
                {
                    tongSoGioCong = JsonConvert.DeserializeObject<MODELTongSoGioCong>(tongSoCongViec.Data.ToString());
                    return Json(tongSoGioCong);
                }
                else
                {
                    throw new Exception(tongSoCongViec.Message);
                }
            }
            catch (Exception ex)
            {
                return Json(new DataSourceResult
                {
                    Errors = "Lỗi tải danh sách: " + ex.Message
                });
            }
        }
        public IActionResult GetList([DataSourceRequest] DataSourceRequest request, GetListQuanLyCongViecRequest param)
		{
			try
			{
				var result = new List<MODELQuanLyCongViec>();
				param.PageIndex = request.Page - 1;
				param.RowPerPage = request.PageSize;
				param.TextSearch = param.TextSearch == null ? string.Empty : param.TextSearch.Trim();


				ResponseData response = this.PostAPI(URL_API.QUANLYCONGVIEC_GETLIST, param);
				DataSourceResult dataSourceResult = result.ToDataSourceResult(request);
				if(response.Status)
				{
					var dataResult = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
					result = JsonConvert.DeserializeObject<List<MODELQuanLyCongViec>>(dataResult.Data.ToString());
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
			catch(Exception ex)
			{
				return Json(new DataSourceResult
				{
					Errors = "Lỗi tải danh sách: " + ex.Message
				});
			}
		}
        #region Thong ke Tong

        public IActionResult Tong()
        {
            try
            {
                var response = this.PostAPI(URL_API.QUANLYCONGVIEC_TONG, new { });

                
                if (!response.Status || response.Data == null)
                {
                    return Json(new { Error = true, Message = "Không tìm thấy dữ liệu" });
                }

               
                var jsonData = Convert.ToString(response.Data);
                var data = string.IsNullOrEmpty(jsonData)
                    ? new List<MODELQuanLyCongViec>()
                    : JsonConvert.DeserializeObject<List<MODELQuanLyCongViec>>(jsonData) ?? new List<MODELQuanLyCongViec>();

               
                var model = new MODELQuanLyCongViecTK
                {
                    Tong = data.Count,
                    TongSoDongThang = data.FirstOrDefault()?.TongSoDongThang ?? 0
                };

                return Json(model);
            }
            catch (Exception ex)
            {
                return Json(new { Error = true, Message = ex.Message });
            }
        }

     
        #endregion
        public ActionResult ShowWorkHistory(Guid id)
        {
            try
            {
                List<MODELLichSuCongViec> obj = new();

                if (id != null)
                {
                    ResponseData response = this.PostAPI(URL_API.QUANLYCONGVIEC_LICHSUCONGVIEC, new { Id = id });

                    if (response.Status)
                    {
                        var datas = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
                        obj = JsonConvert.DeserializeObject<List<MODELLichSuCongViec>>(datas.Data.ToString());
                    }
                }

                return PartialView("~/Views/DuAn/QuanLyCongViec/WorkHistory.cshtml", obj);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        public ActionResult ShowViewPopup(Guid id)
		{
			try
			{
				MODELQuanLyCongViec obj = new();

				if(id != null)
				{
					ResponseData response = this.PostAPI(URL_API.QUANLYCONGVIEC_GETBYID, new { Id = id });

					if(response.Status)
					{
						obj = JsonConvert.DeserializeObject<MODELQuanLyCongViec>(response.Data.ToString());
					}
				}

				return PartialView("~/Views/DuAn/QuanLyCongViec/PopupView.cshtml", obj);
			}
			catch(Exception ex)
			{
				ViewBag.ErrorMessage = ex.Message;
				return PartialView("~/Views/Shared/ErrorPartial.cshtml");
			}
		}

		public ActionResult ShowInsertPopup()
		{
			try
			{
				PostQuanLyCongViecRequest obj = new();

				ResponseData response = this.PostAPI(URL_API.QUANLYCONGVIEC_GETBYPOST, new { Id = Guid.Empty });

				if(response.Status)
				{
					obj = JsonConvert.DeserializeObject<PostQuanLyCongViecRequest>(response.Data.ToString());
				}

				return PartialView("~/Views/DuAn/QuanLyCongViec/PopupDetail.cshtml", obj);
			}
			catch(Exception ex)
			{
				ViewBag.ErrorMessage = ex.Message;
				return PartialView("~/Views/Shared/ErrorPartial.cshtml");
			}
		}

		public ActionResult ShowUpdatePopup(Guid id)
		{
			try
			{
				PostQuanLyCongViecRequest obj = new();

				ResponseData response = this.PostAPI(URL_API.QUANLYCONGVIEC_GETBYPOST, new { Id = id });

				if(response.Status)
				{
					obj = JsonConvert.DeserializeObject<PostQuanLyCongViecRequest>(response.Data.ToString());
				}

				return PartialView("~/Views/DuAn/QuanLyCongViec/PopupDetail.cshtml", obj);
			}
			catch(Exception ex)
			{
				ViewBag.ErrorMessage = ex.Message;
				return PartialView("~/Views/Shared/ErrorPartial.cshtml");
			}
		}

		[HttpPost]
		public JsonResult Post([DataSourceRequest] DataSourceRequest dataSourceRequest, PostQuanLyCongViecRequest param, string? Json_ListSubTask)
		{
			try
			{
				if(param != null && ModelState.IsValid)
				{
                    if (!string.IsNullOrEmpty(Json_ListSubTask))
                    {
                        //param.ListSubTask = JsonConvert.DeserializeObject<List<PostSubTaskRequests>>(Json_ListSubTask);
                        //param.listChiTiet = JsonConvert.DeserializeObject<List<PostChiTietCongViecRequest>>(Json_ListSubTask);
                        param.listCongViecChiTiet = JsonConvert.DeserializeObject<List<PostQuanLiCongViec_ChiTietRequest>>(Json_ListSubTask);
                    }
                    ResponseData response;
					if(param.IsEdit)
					{
						response = this.PostAPI(URL_API.QUANLYCONGVIEC_UPDATE, param);
					}
					else
					{
						response = this.PostAPI(URL_API.QUANLYCONGVIEC_INSERT, param);
					}
					if(!response.Status)
					{
						return Json(new { IsSuccess = false, Message = response.Message, Data = "" });
					}
				}
				else
				{
					return Json(new { IsSuccess = false, Message = "", Data = "" });
				}
				return Json(new { IsSuccess = true, Message = "", Data = param.IsEdit });
			}
			catch(Exception ex)
			{
				string message = "Lỗi cập nhật thông tin: " + ex.Message;
				return Json(new { IsSuccess = false, Message = message, Data = "" });
			}
		}

		[HttpPost]
		public JsonResult Delete([DataSourceRequest] DataSourceRequest dataSourceRequest, List<Guid> listSelectedId)
		{
			try
			{
				ResponseData response = this.PostAPI(URL_API.QUANLYCONGVIEC_DELETELIST, new { ids = listSelectedId }); ;
				return Json(new { IsSuccess = response.Status, Message = response.Message, Data = "" });
			}
			catch(Exception ex)
			{
				string message = "Lỗi xóa thông tin: " + ex.Message;
				return Json(new { IsSuccess = false, Message = message, Data = "" });
			}
		}
		public ActionResult GetAllComboboxWithDuAn(PostQuanLyCongViecGetAllRequest param)
		{
            var response = this.PostAPI(URL_API.QUANLYCONGVIEC_GETALLCOMBOBOXWITHDUAN, param);
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result);
        }
        public ActionResult GetAllComboBox(PostQuanLyCongViecGetAllRequest param)
        {
            var response = this.PostAPI(URL_API.QUANLYCONGVIEC_GETALLCOMBOBOX, param);
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result);
        }
        public ActionResult GetAllComboBoxChiTietCongViec(PostQuanLyCongViecRequest request)
        {
            var response = this.PostAPI(URL_API.QUANLYCONGVIEC_GETCOMBOBOXBYCHITIETCV, request);
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result);
        }
        public ActionResult GetComboBoxTrangThai(GetAllRequest param)
		{
			var response = this.PostAPI(URL_API.QUANLYCONGVIEC_GETCOMBOBOXTRANGTHAI, param);
			var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
			return Json(result);
		}
        public ActionResult GetComboBoxTrangThaiBYUserName(GetAllRequest param)
        {
            var response = this.PostAPI(URL_API.QUANLYCONGVIEC_GETCOMBOBOXBYUSERNAME, param);
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result);
        }
    }
}
