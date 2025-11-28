using Azure.Core;
using FE.Constants;
using FE.Models;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS.HETHONG;
using MODELS.K_MEAN.Dtos;
using Newtonsoft.Json;

namespace FE.Controllers.KNN
{
    public class PhanLoaiSinhVienController : BaseController<PhanLoaiSinhVienController>
    {
        public IActionResult Index()
        {

            var students = new List<UserTasks>();
       
            ResponseData response = this.GetAPI(URL_API.MACHINELEARNPHANLOAISINHVIEN);
            if (response.Status)
            {
               students = JsonConvert.DeserializeObject<List<UserTasks>>(response.Data.ToString());
            }
            var gioi = students.Where(s => s.Label == "Giỏi").ToList();
            var kha = students.Where(s => s.Label == "Khá").ToList();
            var tb = students.Where(s => s.Label == "Trung Bình").ToList();
            var yeu = students.Where(s => s.Label == "Yếu").ToList();

            ViewBag.Gioi = gioi;
            ViewBag.Kha = kha;
            ViewBag.TrungBinh = tb;
            ViewBag.Yeu = yeu;
            return View("~/Views/KNN/PhanLoai/Index.cshtml", GetPhanQuyen());
        }
    }
}
