using FE.Constants;
using FE.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.COMMON;
using MODELS.HETHONG.VAITRO.Dtos;
using MODELS.HETHONG.VAITRO.Requests;
using Newtonsoft.Json;

namespace FE.Controllers.HETHONG
{
    public class VaiTroController : BaseController<VaiTroController>
    {
        public IActionResult Index()
        {
            return View("~/Views/HeThong/VaiTro/Index.cshtml", GetPhanQuyen());
        }

        public IActionResult GetList([DataSourceRequest] DataSourceRequest request, GetListPagingRequest param)
        {
            try
            {
                var result = new List<MODELVaiTro>();
                param.PageIndex = request.Page - 1;
                param.RowPerPage = request.PageSize;
                param.TextSearch = param.TextSearch == null ? string.Empty : param.TextSearch.Trim();

                ResponseData response = this.PostAPI(URL_API.VAITRO_GETLISTPAGING, param);

                DataSourceResult dataSourceResult = result.ToDataSourceResult(request);
                if (response.Status)
                {
                    var dataResult = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
                    result = JsonConvert.DeserializeObject<List<MODELVaiTro>>(dataResult.Data.ToString());
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

        public IActionResult GetListPhanQuyenVaiTro([DataSourceRequest] DataSourceRequest request, Guid? nhomId, Guid? vaiTroId)
        {
            try
            {
                if (nhomId == null) nhomId = Guid.Empty;
                var result = new List<MODELVaiTro_PhanQuyen>();
                ResponseData response = this.PostAPI(URL_API.VAITRO_GETLISTPHANQUYEN, new GetListPhanQuyenVaiTroRequest
                {
                    NhomId = nhomId,
                    VaiTroId = vaiTroId
                });

                if (response.Status)
                {
                    result = JsonConvert.DeserializeObject<List<MODELVaiTro_PhanQuyen>>(response.Data.ToString());
                }
                else
                {
                    return Json(new DataSourceResult
                    {
                        Errors = response.Message
                    });
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
                MODELVaiTro obj = new MODELVaiTro();

                if (id != null)
                {
                    ResponseData response = this.PostAPI(URL_API.VAITRO_GETBYID, new { Id = id });

                    if (response.Status)
                    {
                        obj = JsonConvert.DeserializeObject<MODELVaiTro>(response.Data.ToString());
                    }
                }

                return PartialView("~/Views/HeThong/VaiTro/PopupView.cshtml", obj);
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
                PostVaiTroRequest obj = new PostVaiTroRequest();

                ResponseData response = this.PostAPI(URL_API.VAITRO_GETBYPOST, new { Id = Guid.Empty });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostVaiTroRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/HeThong/VaiTro/PopupDetail.cshtml", obj);
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
                PostVaiTroRequest obj = new PostVaiTroRequest();

                ResponseData response = this.PostAPI(URL_API.VAITRO_GETBYPOST, new { Id = id });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostVaiTroRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/HeThong/VaiTro/PopupDetail.cshtml", obj);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        public ActionResult ShowPhanQuyenPopup(Guid id)
        {
            try
            {
                var dsNhom = new List<MODELCombobox>();

                ResponseData response = this.PostAPI(URL_API.NHOMQUYEN_GETALL, new GetAllRequest());

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<MODELNhomQuyen>>(response.Data.ToString());
                    
                    dsNhom = data.Select(x => new MODELCombobox
                    {
                        Text = x.TenGoi,
                        Value = x.Id.ToString()
                    }).ToList();
                }

                ViewBag.VaiTroId = id;
                ViewBag.NhomPhanQuyen = dsNhom;
                return PartialView("~/Views/HeThong/VaiTro/PopupPhanQuyen.cshtml");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        [HttpPost]
        public JsonResult Post([DataSourceRequest] DataSourceRequest dataSourceRequest, PostVaiTroRequest param)
        {
            try
            {
                if (param != null && ModelState.IsValid)
                {
                    ResponseData response;
                    if (param.IsEdit)
                    {
                        response = this.PostAPI(URL_API.VAITRO_UPDATE, param);
                    }
                    else
                    {
                        response = this.PostAPI(URL_API.VAITRO_INSERT, param);
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

        [HttpPost]
        public JsonResult PostPhanQuyenVaiTro([DataSourceRequest] DataSourceRequest dataSourceRequest, PostPhanQuyenVaiTroRequest param)
        {
            try
            {
                var idReturn = new Guid();
                if (param != null && ModelState.IsValid)
                {
                    ResponseData response = this.PostAPI(URL_API.VAITRO_POSTPHANQUYEN, param);

                    if (response.Status)
                    {
                        var data = JsonConvert.DeserializeObject<MODELVaiTro_PhanQuyen>(response.Data.ToString());
                        idReturn = data.Id;
                    }
                    else
                    {
                        throw new Exception(response.Message);
                    }
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = "", Data = "" });
                }
                return Json(new { IsSuccess = true, Message = "", Data = idReturn });
            }
            catch (Exception ex)
            {
                string message = "Lỗi phân quyền: " + ex.Message;
                return Json(new { IsSuccess = false, Message = message, Data = "" });
            }
        }

        [HttpPost]
        public JsonResult Delete([DataSourceRequest] DataSourceRequest dataSourceRequest, List<Guid> listSelectedId)
        {
            try
            {
                ResponseData response = this.PostAPI(URL_API.VAITRO_DELETELIST, new { ids = listSelectedId }); ;
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
            ResponseData response = this.PostAPI(URL_API.VAITRO_GETALLCOMBOBOX, new GetAllRequest());
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result);
        }
    }
}
