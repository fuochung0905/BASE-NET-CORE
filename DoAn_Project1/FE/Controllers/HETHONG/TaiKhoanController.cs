using FE.Constants;
using FE.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.COMMON;
using MODELS.HETHONG;
using MODELS.HETHONG.TAIKHOAN.Requests;
using Newtonsoft.Json;

namespace FE.Controllers.HETHONG
{
    public class TaiKhoanController : BaseController<TaiKhoanController>
    {
        public IActionResult Index()
        {
            return View("~/Views/HeThong/TaiKhoan/Index.cshtml", GetPhanQuyen());
        }

        public IActionResult GetList([DataSourceRequest] DataSourceRequest request, GetListPagingTaiKhoanRequest param)
        {
            try
            {
                var result = new List<MODELTaiKhoan>();
                param.PageIndex = request.Page - 1;
                param.RowPerPage = request.PageSize;
                param.TextSearch = param.TextSearch == null ? string.Empty : param.TextSearch.Trim();

                ResponseData response = this.PostAPI(URL_API.TAIKHOAN_GETLISTPAGING, param);

                DataSourceResult dataSourceResult = result.ToDataSourceResult(request);
                if (response.Status)
                {
                    var dataResult = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
                    result = JsonConvert.DeserializeObject<List<MODELTaiKhoan>>(dataResult.Data.ToString());
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
                MODELTaiKhoan obj = new MODELTaiKhoan();

                if (id != null)
                {
                    ResponseData response = this.PostAPI(URL_API.TAIKHOAN_GETBYID, new GetByIdRequest { Id = id });

                    if (response.Status)
                    {
                        obj = JsonConvert.DeserializeObject<MODELTaiKhoan>(response.Data.ToString());
                    }
                }

                return PartialView("~/Views/HeThong/TaiKhoan/PopupView.cshtml", obj);
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
                PostTaiKhoanRequest obj = new PostTaiKhoanRequest();

                ResponseData response = this.PostAPI(URL_API.TAIKHOAN_GETBYPOST, new GetByIdRequest { Id = Guid.Empty });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostTaiKhoanRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/HeThong/TaiKhoan/PopupDetail.cshtml", obj);
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
                PostTaiKhoanRequest obj = new PostTaiKhoanRequest();

                ResponseData response = this.PostAPI(URL_API.TAIKHOAN_GETBYPOST, new GetByIdRequest { Id = id });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostTaiKhoanRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/HeThong/TaiKhoan/PopupDetail.cshtml", obj);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        [HttpPost]
        public JsonResult Post([DataSourceRequest] DataSourceRequest dataSourceRequest, PostTaiKhoanRequest param)
        {
            try
            {
                if (param != null && ModelState.IsValid)
                {
     
                    ResponseData response;
                    if (param.IsEdit)
                    {
                        response = this.PostAPI(URL_API.TAIKHOAN_UPDATE, param);
                    }
                    else
                    {
                        response = this.PostAPI(URL_API.TAIKHOAN_INSERT, param);
                    }
                    if (!response.Status)
                    {
                        return Json(new { IsSuccess = false, Message = response.Message, Data = "" });
                    }
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = ""   , Data = "" });
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
        public JsonResult PostUserInfo([DataSourceRequest] DataSourceRequest dataSourceRequest, PostTaiKhoanInfoRequest param)
        {
            try
            {
                if (param != null && ModelState.IsValid)
                {
                    ResponseData response = this.PostAPI(URL_API.TAIKHOAN_UPDATEINFO, param);
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
        public JsonResult Delete([DataSourceRequest] DataSourceRequest dataSourceRequest, List<Guid> listSelectedId)
        {
            try
            {
                ResponseData response = this.PostAPI(URL_API.TAIKHOAN_DELETELIST, new { ids = listSelectedId }); ;
                return Json(new { IsSuccess = response.Status, Message = response.Message, Data = "" });
            }
            catch (Exception ex)
            {
                string message = "Lỗi xóa thông tin: " + ex.Message;
                return Json(new { IsSuccess = false, Message = message, Data = "" });
            }
        }

        public ActionResult ShowPopupChangePassword()
        {
            try
            {
                var userId = GetUserId();
                PostChangePasswordRequest model = new PostChangePasswordRequest
                {
                    Id = Guid.Parse(userId)
                };
                return PartialView("~/Views/Account/PopupChangePassword.cshtml", model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        [HttpPost]
        public JsonResult ChangePassword([DataSourceRequest] DataSourceRequest dataSourceRequest, PostChangePasswordRequest param)
        {
            try
            {
                if (param != null && ModelState.IsValid)
                {
                    ResponseData response = this.PostAPI(URL_API.TAIKHOAN_CHANGEPASSWORD, param);
                    if (!response.Status)
                    {
                        throw new Exception(response.Message);
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
                string message = "Lỗi đổi mật khẩu: " + ex.Message;
                return Json(new { IsSuccess = false, Message = message, Data = "" });
            }
        }

        /// <summary>
        /// Thay đổi thông tin cá nhân đối với tài khoản không có nhân sự id
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowPopupChangeProfile()
        {
            try
            {
                var userId = GetUserId();
                var result = new PostTaiKhoanInfoRequest();
                ResponseData response = this.PostAPI(URL_API.TAIKHOAN_GETINFO, new { });

                if (response.Status)
                {
                    result = JsonConvert.DeserializeObject<PostTaiKhoanInfoRequest>(response.Data.ToString());
                }
                else
                {
                    throw new Exception(response.Message);
                }
                return PartialView("~/Views/Account/PopupChangeProfile.cshtml", result);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        public ActionResult GetList_Combobox()
        {
            ResponseData response = this.PostAPI(URL_API.TAIKHOAN_GETALLFORCOMBOBOX, new GetAllRequest());
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result);
        }
        public ActionResult GetList_ComboboxAndAllUser()
        {
            ResponseData response = this.PostAPI(URL_API.TAIKHOAN_GETALLFORCOMBOBOX, new GetAllRequest());
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            var allUsers = new MODELCombobox
            {
                Text = "Gửi tất cả",
                Value = "0"
            };
            var orderedResult = new List<MODELCombobox> { allUsers };
            orderedResult.AddRange(result);
            return Json(orderedResult);
        }

        public ActionResult GetComboBoxNguoiQuanLy()
        {
            var response = this.PostAPI(URL_API.TAIKHOAN_GETCOMBOBOXNGUOIQUANLY, new GetAllRequest());
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result);
        }

        public ActionResult GetComboBoxOfMonHoc(Guid? MonHocId)
        {
            var request = new GetByIdRequest();
            request.Id = MonHocId;
            var response = this.PostAPI(URL_API.TAIKHOAN_GETCOMBOBOXOFMONHOC, request);
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result);
        }
        public ActionResult GetComboBoxOfPhongBan(Guid? PhongBanId)
        {
            var request = new GetByIdRequest();
            request.Id = PhongBanId;
            var response = this.PostAPI(URL_API.TAIKHOAN_GETCOMBOBOXOFPHONGBAN, request);
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result);
        }
        public ActionResult GetComboBoxOfDuAn(Guid? DuAnId)
        {
            var request = new GetByIdRequest();
            request.Id = DuAnId;
            var response = this.PostAPI(URL_API.TAIKHOAN_GETCOMBOBOXOFDUAN, request);
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result);
        }

        public ActionResult GetById(Guid id)
        {
            try
            {
                MODELTaiKhoan obj = new MODELTaiKhoan();

                ResponseData response = this.PostAPI(URL_API.TAIKHOAN_GETBYID, new GetByIdRequest { Id = id });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<MODELTaiKhoan>(response.Data.ToString());

                    return Json(new { IsSuccess = response.Status, Message = response.Message, Data = obj });
                }

                return Json(new { IsSuccess = response.Status, Message = response.Message, Data = "" });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }
    }
}
