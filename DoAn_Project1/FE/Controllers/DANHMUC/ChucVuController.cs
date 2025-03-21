using FE.Constants;
using FE.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using MODELS.BASE;
using MODELS.COMMON;
using MODELS.DANHMUC.CHUCVU.Dtos;
using MODELS.DANHMUC.CHUCVU.Requests;
using MODELS;
using MODELS.HETHONG.TAIKHOAN.Requests;
using Newtonsoft.Json;
using Model.BASE;

namespace FE.Controllers.DANHMUC
{
    public class ChucVuController : BaseController<ChucVuController>
    {
        public IActionResult Index()
        {
            return View("~/Views/DanhMuc/ChucVu/Index.cshtml", GetPhanQuyen());
        }

        public IActionResult GetList([DataSourceRequest] DataSourceRequest request, GetListPagingRequest param)
        {
            try
            {
                var result = new List<MODELChucVu>();
                param.PageIndex = request.Page - 1;
                param.RowPerPage = request.PageSize;
                param.TextSearch = param.TextSearch == null ? string.Empty : param.TextSearch.Trim();


                ResponseData response = this.PostAPI(URL_API.CHUCVU_GETLIST, param);
                DataSourceResult dataSourceResult = result.ToDataSourceResult(request);
                if (response.Status)
                {
                    var dataResult = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
                    result = JsonConvert.DeserializeObject<List<MODELChucVu>>(dataResult.Data.ToString());
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

        public IActionResult GetListAll()
        {
            try
            {
                var result = new List<MODELChucVu>();
                ResponseData response = this.PostAPI(URL_API.CHUCVU_GETLIST, new GetAllRequest());

                if (response.Status)
                {
                    result = JsonConvert.DeserializeObject<List<MODELChucVu>>(response.Data.ToString());
                }
                else
                {
                    throw new Exception(response.Message);
                }

                return Json(result);
            }
            catch
            {
                return Json(new List<MODELChucVu>());
            }
        }

        public ActionResult ShowViewPopup(Guid id)
        {
            try
            {
                MODELChucVu obj = new MODELChucVu();

                if (id != null)
                {
                    ResponseData response = this.PostAPI(URL_API.CHUCVU_GETBYID, new { Id = id });

                    if (response.Status)
                    {
                        obj = JsonConvert.DeserializeObject<MODELChucVu>(response.Data.ToString());
                    }
                }

                return PartialView("~/Views/DanhMuc/ChucVu/PopupView.cshtml", obj);
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
                PostChucVuRequest obj = new PostChucVuRequest();

                ResponseData response = this.PostAPI(URL_API.CHUCVU_GETBYPOST, new { Id = Guid.Empty });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostChucVuRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/DanhMuc/ChucVu/PopupDetail.cshtml", obj);
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
                PostChucVuRequest obj = new PostChucVuRequest();

                ResponseData response = this.PostAPI(URL_API.CHUCVU_GETBYPOST, new { Id = id });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostChucVuRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/DanhMuc/ChucVu/PopupDetail.cshtml", obj);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        [HttpPost]
        public JsonResult Post([DataSourceRequest] DataSourceRequest dataSourceRequest, PostChucVuRequest param)
        {
            try
            {
                if (param != null && ModelState.IsValid)
                {
                    ResponseData response;
                    if (param.IsEdit)
                    {
                        response = this.PostAPI(URL_API.CHUCVU_UPDATE, param);
                    }
                    else
                    {
                        response = this.PostAPI(URL_API.CHUCVU_INSERT, param);
                    }
                    if (!response.Status)
                    {
                        return Json(new { IsSuccess = false, Message = response.Message, Data = "" });
                    }
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = MODELS.COMMON.CommonFunc.GetModelStateAPI(this.ModelState), Data = "" });
                }
                return Json(new { IsSuccess = true, Message = "", Data = param.IsEdit });
            }
            catch (Exception ex)
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
                ResponseData response = this.PostAPI(URL_API.CHUCVU_DELETELIST, new { ids = listSelectedId }); ;
                return Json(new { IsSuccess = response.Status, Message = response.Message, Data = "" });
            }
            catch (Exception ex)
            {
                string message = "Lỗi xóa thông tin: " + ex.Message;
                return Json(new { IsSuccess = false, Message = message, Data = "" });
            }
        }

        public ActionResult GetList_Combobox()
        {
            ResponseData response = this.PostAPI(URL_API.CHUCVU_GETALLFORCOMBOBOX, new GetAllRequest());
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result);
        }
    }
}
