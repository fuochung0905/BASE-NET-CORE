using Microsoft.AspNetCore.Mvc;
using MODELS.K_MEAN.Dtos;

namespace FE.Controllers.KNN
{
    public class PhanLoaiSinhVienController : BaseController<PhanLoaiSinhVienController>
    {
        public IActionResult Index()
        {

            var students = new List<UserTasks>
        {
            new UserTasks { Name = "Nguyễn A", Label = "Giỏi" },
            new UserTasks { Name = "Trần B", Label = "Khá" },
            new UserTasks { Name = "Lê C", Label = "Trung Bình" },
            new UserTasks { Name = "Phạm D", Label = "Khá" },
            new UserTasks { Name = "Đỗ E", Label = "Giỏi" },
            new UserTasks { Name = "Bùi F", Label = "Trung Bình" },
            // ...
        };

            // Chia theo học lực
            var gioi = students.Where(s => s.Label == "Giỏi").ToList();
            var kha = students.Where(s => s.Label == "Khá").ToList();
            var tb = students.Where(s => s.Label == "Trung Bình").ToList();

            ViewBag.Gioi = gioi;
            ViewBag.Kha = kha;
            ViewBag.TrungBinh = tb;
            return View("~/Views/KNN/PhanLoai/Index.cshtml", GetPhanQuyen());
        }
    }
}
