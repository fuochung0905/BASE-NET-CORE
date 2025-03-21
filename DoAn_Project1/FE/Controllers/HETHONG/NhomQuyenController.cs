using FE.Constants;
using FE.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using MODELS;
using MODELS.BASE;
using MODELS.COMMON;
using MODELS.HETHONG.NHOMQUYEN.Requests;
using MODELS.HETHONG.VAITRO.Dtos;
using Newtonsoft.Json;

namespace FE.Controllers.HETHONG
{
    public class NhomQuyenController : BaseController<NhomQuyenController>
    {
        public IActionResult Index()
        {
            return View("~/Views/HeThong/NhomQuyen/Index.cshtml", GetPhanQuyen());
        }

        public IActionResult GetList([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var result = new List<MODELNhomQuyen>();
                ResponseData response = this.PostAPI(URL_API.NHOMQUYEN_GETLIST, new GetAllRequest());

                if (response.Status)
                {
                    result = JsonConvert.DeserializeObject<List<MODELNhomQuyen>>(response.Data.ToString());
                }
                else
                {
                    throw new Exception(response.Message);
                }

                return Json(result.ToDataSourceResult(request));
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
                MODELNhomQuyen obj = new MODELNhomQuyen();

                if (id != null)
                {
                    ResponseData response = this.PostAPI(URL_API.NHOMQUYEN_GETBYID, new { Id = id });

                    if (response.Status)
                    {
                        obj = JsonConvert.DeserializeObject<MODELNhomQuyen>(response.Data.ToString());
                    }
                }

                return PartialView("~/Views/HeThong/NhomQuyen/PopupView.cshtml", obj);
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
                PostNhomQuyenRequest obj = new PostNhomQuyenRequest();

                ResponseData response = this.PostAPI(URL_API.NHOMQUYEN_GETBYPOST, new { Id = Guid.Empty });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostNhomQuyenRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/HeThong/NhomQuyen/PopupDetail.cshtml", obj);
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
                PostNhomQuyenRequest obj = new PostNhomQuyenRequest();

                ResponseData response = this.PostAPI(URL_API.NHOMQUYEN_GETBYPOST, new { Id = id });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostNhomQuyenRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/HeThong/NhomQuyen/PopupDetail.cshtml", obj);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        [HttpPost]
        public JsonResult Post([DataSourceRequest] DataSourceRequest dataSourceRequest, PostNhomQuyenRequest param)
        {
            try
            {
                if (param != null && ModelState.IsValid)
                {
                    ResponseData response;
                    if (param.IsEdit)
                    {
                        response = this.PostAPI(URL_API.NHOMQUYEN_UPDATE, param);
                    }
                    else
                    {
                        response = this.PostAPI(URL_API.NHOMQUYEN_INSERT, param);
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

        public ActionResult GetList_Combobox()
        {
            ResponseData response = this.PostAPI(URL_API.NHOMQUYEN_GETALLCOMBOBOX, new GetAllRequest());
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result);
        }

        public ActionResult GetList_Parent_Combobox()
        {
            ResponseData response = this.PostAPI(URL_API.NHOMQUYEN_GETALLPARENTCOMBOBOX, new GetAllRequest());
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result.ToList());
        }
    }
}
