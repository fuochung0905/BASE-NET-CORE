using FE.Constants;
using FE.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS.BASE;
using MODELS.DUAN.PHANHOI.Dtos;
using MODELS.DUAN.PHANHOI.Requests;
using Newtonsoft.Json;

namespace FE.Controllers.DUAN
{
    public class QuanLyCongViec_PhanHoiController : BaseController<QuanLyCongViec_PhanHoiController>
    {
        public IActionResult PartialTabPhanHoi(Guid? thongTinChungId)
        {
            ViewBag.ThongTinChungId = thongTinChungId;
            return PartialView("~/Views/DuAn/QuanLyCongViec/_PartialPhanHoi.cshtml", GetPhanQuyen());
        }
        public ActionResult GetList([DataSourceRequest] DataSourceRequest request, PostPhanHoiGetListPagingRequest param)
        {
            try
            {
                var result = new List<MODELPhanHoi>();
                param.PageIndex = request.Page - 1;
                param.RowPerPage = request.PageSize;

                ResponseData response = PostAPI(URL_API.QUANLYCONGVIEC_LICHSUCONGVIEC, param);

                DataSourceResult dataSourceResult = result.ToDataSourceResult(request);
                if (response.Status)
                {
                    var dataResult = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
                    result = JsonConvert.DeserializeObject<List<MODELPhanHoi>>(dataResult.Data.ToString());
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
    }
}
