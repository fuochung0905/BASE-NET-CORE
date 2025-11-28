using FE.Constants;
using FE.Models;
using Microsoft.AspNetCore.Mvc;
using MODELS.K_MEAN.Dtos;
using MODELS.KNN.Dtos;
using Newtonsoft.Json;

namespace FE.Controllers.KNN
{
    public class DeXuatSinhVienController : BaseController<DeXuatSinhVienController>
    {
        public IActionResult Index()
        {
            var suggestions = new List<GroupStudent>();

            ResponseData response = this.GetAPI(URL_API.MACHINELEARNDEXUATSINHVIEN);
            if (response.Status)
            {
                suggestions = JsonConvert.DeserializeObject<List<GroupStudent>>(response.Data.ToString());
            }
            ViewBag.Gioi = suggestions.Where(s => s.Label == "Giỏi").ToList();
            ViewBag.Kha = suggestions.Where(s => s.Label == "Khá").ToList();
            ViewBag.TrungBinh = suggestions.Where(s => s.Label == "Trung Bình").ToList();
            ViewBag.Yeu = suggestions.Where(s => s.Label == "Yếu").ToList();

            return View("~/Views/KNN/DeXuat/Index.cshtml", GetPhanQuyen());
        }
    }
}
