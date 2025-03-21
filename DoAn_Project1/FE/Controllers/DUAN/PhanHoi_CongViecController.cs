using FE.Constants;
using FE.Models;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS.DUAN.PHANHOI.Requests;
using MODELS.DUAN.QUANLYCONGVIEC.Dtos;
using Newtonsoft.Json;

namespace FE.Controllers.DUAN
{
    public class PhanHoi_CongViecController : BaseController<PhanHoi_CongViecController>
    {
        public ActionResult GetList(PostPhanHoiGetListPagingRequest param)
        {
            try
            {
                var result = new List<MODELQuanLyCongViec_PhanHoi>();
                ResponseData response = this.PostAPI(URL_API.CONGVIEC_PHANHOI_GETLIST, param);
                if (response.Status)
                {
                    var dataResult = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
                    result = JsonConvert.DeserializeObject<List<MODELQuanLyCongViec_PhanHoi>>(dataResult.Data.ToString());
                }
                else
                {
                    throw new Exception(response.Message);
                }

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new DataSourceResult
                {
                    Errors = "Lỗi tải danh sách: " + ex.Message
                });
            }
        }

        public IActionResult GetById(Guid Id)
        {
            try
            {
                var result = new MODELQuanLyCongViec_PhanHoi();
                ResponseData response = this.PostAPI(URL_API.CONGVIEC_PHANHOI_GETBYID, new { Id = Id });
                if (response.Status)
                {
                    result = JsonConvert.DeserializeObject<MODELQuanLyCongViec_PhanHoi>(response.Data.ToString());
                }
                else
                {
                    throw new Exception(response.Message);
                }

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json("Lỗi lấy phản hồi theo id");

            }
        }

        [HttpPost]
        public JsonResult Delete(Guid Id)
        {
            try
            {
                if (Id != null && ModelState.IsValid)
                {
                    ResponseData response;

                    response = this.PostAPI(URL_API.CONGVIEC_PHANHOI_DELETE, new { Id = Id });
                    if (!response.Status)
                    {
                        return Json(new { IsSuccess = false, Message = response.Message, Data = "" });
                    }
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = MODELS.COMMON.CommonFunc.GetModelStateAPI(this.ModelState), Data = "" });
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
        public JsonResult Post(PostPhanHoiRequest param)
        {
            try
            {
                if (param != null && ModelState.IsValid)
                {
                    ResponseData response;
                    if (param.IsEdit)
                    {
                        response = this.PostAPI(URL_API.CONGVIEC_PHANHOI_INSERT, param);
                    }
                    else
                    {
                        response = this.PostAPI(URL_API.CONGVIEC_PHANHOI_INSERT, param);
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
        public JsonResult Update(PostPhanHoiRequest request)
        {
            try
            {
                if (request != null && ModelState.IsValid)
                {
                    ResponseData response = this.PostAPI(URL_API.CONGVIEC_PHANHOI_UPDATE, request);
                    if (!response.Status)
                    {
                        return Json(new { IsSuccess = false, Message = response.Message, Data = "" });
                    }
                }
                else
                {
                    return Json(new
                    { IsSuccess = false, Message = MODELS.COMMON.CommonFunc.GetModelStateAPI(this.ModelState), Data = "" });
                }

                return Json(new { IsSuccess = true, Message = "", Data = request.IsEdit });
            }
            catch (Exception e)
            {
                string message = "Lỗi cập nhật thông tin: " + e.Message;
                return Json(new { IsSuccess = false, Message = message, Data = "" });
            }
        }

    }
}
