using FE.Constants;
using FE.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS.BASE;
using MODELS.COMMON;
using MODELS.DUAN.QUANLICONGVIEC_CHITIET.Dtos;
using MODELS.DUAN.QUANLICONGVIEC_CHITIET.Requests;
using MODELS.DUAN.QUANLYDUAN.Requests;
using Newtonsoft.Json;

namespace FE.Controllers.DUAN
{
    public class QuanLiCongViecChiTietController : BaseController<QuanLiCongViecChiTietController>
    {
        public IActionResult GetList([DataSourceRequest] DataSourceRequest request, GetListCongViecChiTietRequest param)
        {
            try
            {
                var result = new List<MODELQuanLiCongViecChiTiet>();
                param.PageIndex = request.Page - 1;
                param.RowPerPage = request.PageSize;
                param.TextSearch = param.TextSearch == null ? string.Empty : param.TextSearch.Trim();


                ResponseData response = this.PostAPI(URL_API.QUANLICONGVIEC_CHITIET_GETLIST, param);
                DataSourceResult dataSourceResult = result.ToDataSourceResult(request);
                if (response.Status)
                {
                    var dataResult = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
                    result = JsonConvert.DeserializeObject<List<MODELQuanLiCongViecChiTiet>>(dataResult.Data.ToString());
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
        public ActionResult ShowUpdatePopup(Guid id)
        {
            try
            {
                PostQuanLiCongViec_ChiTietRequest obj = new();

                ResponseData response = this.PostAPI(URL_API.QUANLICONGVIEC_CHITIET_GETBYPOST, new { Id = id });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostQuanLiCongViec_ChiTietRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/DuAn/ThongKeCongViecCaNhan/ShowUpdatePopupChiTiet.cshtml", obj);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        [HttpPost]
        public JsonResult Post([DataSourceRequest] DataSourceRequest dataSourceRequest, PostQuanLiCongViec_ChiTietRequest param)
        {
            try
            {
                if (param != null && ModelState.IsValid)
                {
                    ResponseData response;
                    if (param.IsEdit)
                    {
                        response = this.PostAPI(URL_API.QUANLICONGVIEC_CHITIET_UPDATE, param);
                    }
                    else
                    {
                        response = this.PostAPI(URL_API.QUANLYDUAN_INSERT, param);
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
    }
}
