using FE.Constants;
using FE.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS.BASE;
using MODELS.DUAN.LICHSUCONGVIEC.Dtos;
using MODELS.DUAN.LICHSUCONGVIEC.Request;
using Newtonsoft.Json;

namespace FE.Controllers.DUAN
{
    public class QuanLyCongViec_LichSuGiaoViecController : BaseController<QuanLyCongViec_LichSuGiaoViecController>
    {
        public IActionResult PartialTabLichSuGiaoViec(Guid? thongTinChungId)
        {
            try
            {
                List<MODELLichSuCongViec> obj = new();

                if (thongTinChungId != null)
                {
                    ResponseData response = this.PostAPI(URL_API.QUANLYCONGVIEC_LICHSUCONGVIEC, new { Id = thongTinChungId });

                    if (response.Status)
                    {
                        var datas = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
                        obj = JsonConvert.DeserializeObject<List<MODELLichSuCongViec>>(datas.Data.ToString());
                    }
                }

                return PartialView("~/Views/DuAn/QuanLyCongViec/_PartialLichSuGiaoViec.cshtml", obj);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }
    }
}
