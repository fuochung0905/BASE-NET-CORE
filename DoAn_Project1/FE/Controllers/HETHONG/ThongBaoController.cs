using FE.Constants;
using FE.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.COMMON;
using MODELS.HETHONG.HETHONGTHONGBAO.Dtos;
using MODELS.HETHONG.HETHONGTHONGBAO.Requests;
using Newtonsoft.Json;

namespace FE.Controllers.HETHONG
{
    public class ThongBaoController : BaseController<ThongBaoController>
    {
        public IActionResult Index()
        {
            return View("~/Views/HeThong/ThongBao/Index.cshtml", GetPhanQuyen());
        }

        public IActionResult GetList([DataSourceRequest] DataSourceRequest request, GetListPagingRequest param)
        {
            try
            {
                var result = new List<MODELThongBao>();
                param.PageIndex = request.Page - 1;
                param.RowPerPage = request.PageSize;
                param.TextSearch = param.TextSearch == null ? string.Empty : param.TextSearch.Trim();

                ResponseData response = this.PostAPI(URL_API.THONGBAO_GETLISTPAGING, param);

                DataSourceResult dataSourceResult = result.ToDataSourceResult(request);
                if (response.Status)
                {
                    var dataResult = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
                    result = JsonConvert.DeserializeObject<List<MODELThongBao>>(dataResult.Data.ToString());
                    dataSourceResult = result.ToDataSourceResult(request);
                    dataSourceResult.Total = dataResult.TotalRow;
                    dataSourceResult.Data = result;
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


        public ActionResult ShowViewPopup(Guid id)
        {
            try
            {
                MODELThongBao obj = new MODELThongBao();

                if (id != null)
                {
                    ResponseData response = this.PostAPI(URL_API.THONGBAO_GETBYID, new { Id = id });

                    if (response.Status)
                    {
                        obj = JsonConvert.DeserializeObject<MODELThongBao>(response.Data.ToString());
                    }
                }

                return PartialView("~/Views/HeThong/ThongBao/PopupView.cshtml", obj);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        public ActionResult ShowInsertPopup()
        {
            try
            {
                PostThongBaoRequest obj = new PostThongBaoRequest();

                ResponseData response = this.PostAPI(URL_API.THONGBAO_GETBYPOST, new { Id = Guid.Empty });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostThongBaoRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/HeThong/ThongBao/PopupDetail.cshtml", obj);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        public ActionResult ShowUpdatePopup(Guid id)
        {
            try
            {
                PostThongBaoRequest obj = new PostThongBaoRequest();

                ResponseData response = this.PostAPI(URL_API.THONGBAO_GETBYPOST, new { Id = id });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostThongBaoRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/HeThong/ThongBao/PopupDetail.cshtml", obj);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        [HttpPost]
        public JsonResult Post([DataSourceRequest] DataSourceRequest dataSourceRequest, PostThongBaoRequest param)
        {
            try
            {
                if (param != null && ModelState.IsValid)
                {
                    ResponseData response;
                    if (param.IsEdit)
                    {
                        response = this.PostAPI(URL_API.THONGBAO_UPDATE, param);
                    }
                    else
                    {
                        response = this.PostAPI(URL_API.THONGBAO_INSERT, param);
                    }
                    if (!response.Status)
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
            catch (Exception ex)
            {
                string message = "Lỗi cập nhật thông tin: " + ex.Message;
                return Json(new { IsSuccess = false, Message = message, Data = "" });
            }
        }


        [HttpGet]
        public JsonResult SoLuongThongBao()
        {
            try
            {
                ResponseData response = this.GetAPI(URL_API.THONGBAO_SOLUONGTHONGBAOCHUAXEM);
                if (response.Status)
                {
                    return Json(new { IsSuccess = true, Message = "", Data = response.Data });
                }
                return Json(new { IsSuccess = false, Message = response.Message, Data = "" });

            }
            catch (Exception ex)
            {
                string message = "Lỗi cập nhật thông tin: " + ex.Message;
                return Json(new { IsSuccess = false, Message = message, Data = "" });
            }
        }
    }
}
