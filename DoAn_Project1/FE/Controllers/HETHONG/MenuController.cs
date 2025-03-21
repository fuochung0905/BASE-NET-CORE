using FE.Constants;
using FE.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.COMMON;
using MODELS.HETHONG.MENU.Requests;
using MODELS.HETHONG.TAIKHOAN.Dtos;
using Newtonsoft.Json;

namespace FE.Controllers.HETHONG
{
    public class MenuController : BaseController<MenuController>
    {
        public IActionResult Index()
        {
            return View("~/Views/HeThong/Menu/Index.cshtml", GetPhanQuyen());
        }

        public IActionResult GetListPaging([DataSourceRequest] DataSourceRequest request, GetListPagingRequest param)
        {
            try
            {
                param.PageIndex = request.Page - 1;
                param.RowPerPage = request.PageSize;
                param.TextSearch = param.TextSearch == null ? string.Empty : param.TextSearch.Trim();

                var result = new List<MODELMenu>();
                ResponseData response = this.PostAPI(URL_API.MENU_GETLISTPAGING, param);

                DataSourceResult dataSourceResult = result.ToDataSourceResult(request);
                if (response.Status)
                {
                    var dataResult = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
                    result = JsonConvert.DeserializeObject<List<MODELMenu>>(dataResult.Data.ToString());
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

        //public IActionResult GetList([DataSourceRequest] DataSourceRequest request)
        //{
        //    try
        //    {
        //        var result = new List<MODELMenu>();
        //        ResponseData response = this.PostAPI(URL_API.MENU_GETLIST, new GetAllRequest());

        //        if (response.Status)
        //        {
        //            result = JsonConvert.DeserializeObject<List<MODELMenu>>(response.Data.ToString());
        //        }
        //        else
        //        {
        //            throw new Exception(response.Message);
        //        }

        //        return Json(result.ToDataSourceResult(request));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new DataSourceResult
        //        {
        //            Errors = "Lỗi tải danh sách: " + ex.Message
        //        });
        //    }
        //}

        public ActionResult ShowInsertPopup()
        {
            try
            {
                PostMenuRequest obj = new PostMenuRequest();

                ResponseData response = this.PostAPI(URL_API.MENU_GETBYPOST, new GetMenuByIdRequest { ControllerName = "abc" });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostMenuRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/HeThong/Menu/PopupDetail.cshtml", obj);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        public ActionResult ShowUpdatePopup(string id)
        {
            try
            {
                PostMenuRequest obj = new PostMenuRequest();

                ResponseData response = this.PostAPI(URL_API.MENU_GETBYPOST, new GetMenuByIdRequest { ControllerName = id });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostMenuRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/HeThong/Menu/PopupDetail.cshtml", obj);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        [HttpPost]
        public JsonResult Post([DataSourceRequest] DataSourceRequest dataSourceRequest, PostMenuRequest param)
        {
            try
            {
                if (param != null && ModelState.IsValid)
                {
                    ResponseData response;
                    if (param.IsEdit)
                    {
                        response = this.PostAPI(URL_API.MENU_UPDATE, param);
                    }
                    else
                    {
                        response = this.PostAPI(URL_API.MENU_INSERT, param);
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
