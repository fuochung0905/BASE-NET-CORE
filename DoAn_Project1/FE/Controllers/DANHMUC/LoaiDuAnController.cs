using FE.Constants;
using FE.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.DANHMUC.LOAIDUAN.Dtos;
using MODELS.DANHMUC.LOAIDUAN.Requests;
using Newtonsoft.Json;

namespace FE.Controllers.DANHMUC
{
    public class LoaiDuAnController : BaseController<LoaiDuAnController>
    {
        public IActionResult Index()
        {
            return View("~/Views/DanhMuc/LoaiDuAn/Index.cshtml", GetPhanQuyen());
        }

        public IActionResult GetList([DataSourceRequest] DataSourceRequest request, GetListPagingRequest param)
        {
            try
            {
                var result = new List<MODELLoaiDuAn>();
                param.PageIndex = request.Page - 1;
                param.RowPerPage = request.PageSize;
                param.TextSearch = param.TextSearch == null ? string.Empty : param.TextSearch.Trim();


                ResponseData response = this.PostAPI(URL_API.LOAIDUAN_GETLIST, param);
                DataSourceResult dataSourceResult = result.ToDataSourceResult(request);
                if (response.Status)
                {
                    var dataResult = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
                    result = JsonConvert.DeserializeObject<List<MODELLoaiDuAn>>(dataResult.Data.ToString());
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
                var result = new List<MODELLoaiDuAn>();
                ResponseData response = this.PostAPI(URL_API.LOAIDUAN_GETLIST, new GetAllRequest());

                if (response.Status)
                {
                    result = JsonConvert.DeserializeObject<List<MODELLoaiDuAn>>(response.Data.ToString());
                }
                else
                {
                    throw new Exception(response.Message);
                }

                return Json(result);
            }
            catch
            {
                return Json(new List<MODELLoaiDuAn>());
            }
        }

        public ActionResult ShowViewPopup(Guid id)
        {
            try
            {
                MODELLoaiDuAn obj = new MODELLoaiDuAn();

                if (id != null)
                {
                    ResponseData response = this.PostAPI(URL_API.LOAIDUAN_GETBYID, new { Id = id });

                    if (response.Status)
                    {
                        obj = JsonConvert.DeserializeObject<MODELLoaiDuAn>(response.Data.ToString());
                    }
                }

                return PartialView("~/Views/DanhMuc/LoaiDuAn/PopupView.cshtml", obj);
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
                PostLoaiDuAnRequest obj = new PostLoaiDuAnRequest();

                ResponseData response = this.PostAPI(URL_API.LOAIDUAN_GETBYPOST, new { Id = Guid.Empty });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostLoaiDuAnRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/DanhMuc/LoaiDuAn/PopupDetail.cshtml", obj);
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
                PostLoaiDuAnRequest obj = new PostLoaiDuAnRequest();

                ResponseData response = this.PostAPI(URL_API.LOAIDUAN_GETBYPOST, new { Id = id });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostLoaiDuAnRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/DanhMuc/LoaiDuAn/PopupDetail.cshtml", obj);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        [HttpPost]
        public JsonResult Post([DataSourceRequest] DataSourceRequest dataSourceRequest, PostLoaiDuAnRequest param)
        {
            try
            {
                if (param != null && ModelState.IsValid)
                {
                    ResponseData response;
                    if (param.IsEdit)
                    {
                        response = this.PostAPI(URL_API.LOAIDUAN_UPDATE, param);
                    }
                    else
                    {
                        response = this.PostAPI(URL_API.LOAIDUAN_INSERT, param);
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
                ResponseData response = this.PostAPI(URL_API.LOAIDUAN_DELETELIST, new { ids = listSelectedId }); ;
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
            ResponseData response = this.PostAPI(URL_API.LOAIDUAN_GETALLFORCOMBOBOX, new GetAllRequest());
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result);
        }
    }
}
