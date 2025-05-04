using FE.Constants;
using FE.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.COMMON;
using MODELS.DUAN.QUANLYDUAN.Dtos;
using MODELS.DUAN.QUANLYDUAN.Requests;
using Newtonsoft.Json;

namespace FE.Controllers.DUAN
{
    public class QuanLyDuAnController : BaseController<QuanLyDuAnController>
    {
        public IActionResult Index(Guid? id)
        {
            var breadcrumbs = new List<MODELS.BREADCRUMB.Breadcrumb>
            {
                new MODELS.BREADCRUMB.Breadcrumb { Name = "Trang chủ", Url = "/" },
                new MODELS.BREADCRUMB.Breadcrumb { Name = "Quản lý dự án", Url = "#", IsActive = true  }

            };

            ViewData["Breadcrumbs"] = breadcrumbs;
            var tabs = new List<MODELS.HETHONG.TAB.Tab>
            {
                new MODELS.HETHONG.TAB.Tab { Id = "QuanLyDuAn", Name = "Quản lý dự án", ControllerName = "QuanLyDuAn" ,ActionName="IndexTab"},


                new MODELS.HETHONG.TAB.Tab { Id = "ThongKeKetQuaCongViecDuan", Name = "Kết quả", ControllerName = "ThongKeKetQuaCongViecDuan" ,ActionName="IndexTab" },
                new MODELS.HETHONG.TAB.Tab { Id = "ThongKeKetQuaCongViecDuan", Name = "Chi tiết", ControllerName = "ThongKeKetQuaCongViecDuan" ,ActionName="IndexTabCT" },



            };

            ViewData["tabs"] = tabs;
            ViewBag.GiaiDoanId = id ?? Guid.Empty;
            return View("~/Views/DuAn/QuanLyDuAn/Index.cshtml", GetPhanQuyen());
        }

        public IActionResult GetList([DataSourceRequest] DataSourceRequest request, GetListQuanLyDuAnRequest param)
        {
            try
            {
                var result = new List<MODELQuanLyDuAn>();
                param.PageIndex = request.Page - 1;
                param.RowPerPage = request.PageSize;
                param.TextSearch = param.TextSearch == null ? string.Empty : param.TextSearch.Trim();


                ResponseData response = this.PostAPI(URL_API.QUANLYDUAN_GETLIST, param);
                DataSourceResult dataSourceResult = result.ToDataSourceResult(request);
                if(response.Status)
                {
                    var dataResult = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
                    result = JsonConvert.DeserializeObject<List<MODELQuanLyDuAn>>(dataResult.Data.ToString());
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
            var result = new List<MODELQuanLyDuAn>();
            GetListQuanLyDuAnRequest param = new GetListQuanLyDuAnRequest();
            ResponseData response = this.PostAPI(URL_API.QUANLYDUAN_GETLIST, param);

            if (response.Status)
            {
                var dataResult = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
                //result = JsonConvert.DeserializeObject<List<MODELQuanLyDuAn>>(dataResult.Data.ToString());
                return Json(0);
            }

            return Json(0);
        }
        #endregion
        public ActionResult ShowViewPopup(Guid id)
        {
            try
            {
                MODELQuanLyDuAn obj = new();

                if(id != null)
                {
                    ResponseData response = this.PostAPI(URL_API.QUANLYDUAN_GETBYID, new { Id = id });

                    if(response.Status)
                    {
                        obj = JsonConvert.DeserializeObject<MODELQuanLyDuAn>(response.Data.ToString());
                    }
                }

                return PartialView("~/Views/DuAn/QuanLyDuAn/PopupView.cshtml", obj);
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
                PostQuanLyDuAnRequest obj = new();

                ResponseData response = this.PostAPI(URL_API.QUANLYDUAN_GETBYPOST, new { Id = Guid.Empty });

                if(response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostQuanLyDuAnRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/DuAn/QuanLyDuAn/PopupDetail.cshtml", obj);
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
                PostQuanLyDuAnRequest obj = new();

                ResponseData response = this.PostAPI(URL_API.QUANLYDUAN_GETBYPOST, new { Id = id });

                if(response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostQuanLyDuAnRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/DuAn/QuanLyDuAn/PopupDetail.cshtml", obj);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        [HttpPost]
        public JsonResult Post([DataSourceRequest] DataSourceRequest dataSourceRequest, PostQuanLyDuAnRequest param)
        {
            try
            {
                if(param != null && ModelState.IsValid)
                {
                    ResponseData response;
                    if(param.IsEdit)
                    {
                        response = this.PostAPI(URL_API.QUANLYDUAN_UPDATE, param);
                    }
                    else
                    {
                        response = this.PostAPI(URL_API.QUANLYDUAN_INSERT, param);
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
                ResponseData response = this.PostAPI(URL_API.QUANLYDUAN_DELETELIST, new { ids = listSelectedId }); ;
                return Json(new { IsSuccess = response.Status, Message = response.Message, Data = "" });
            }
            catch(Exception ex)
            {
                string message = "Lỗi xóa thông tin: " + ex.Message;
                return Json(new { IsSuccess = false, Message = message, Data = "" });
            }
        }

        public ActionResult GetAllComboBox(GetAllRequest param)
        {
            var response = this.PostAPI(URL_API.QUANLYDUAN_GETALLCOMBOBOX, param);

            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result);
        }
      
    }
}
