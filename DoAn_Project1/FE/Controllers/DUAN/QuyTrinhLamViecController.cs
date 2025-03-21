using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using MODELS.DUAN.TRANGTHAICONGVIEC.Dtos;

namespace FE.Controllers.DUAN
{
    public class QuyTrinhLamViecController : BaseController<QuyTrinhLamViecController>
    {
        public IActionResult Index()
        {
            return View("~/Views/DuAn/QuyTrinhLamViec/Index.cshtml", GetPhanQuyen());
        }

        public static List<MODELTrangThaiCongViec> diagramShapes = new List<MODELTrangThaiCongViec>
        {
            new MODELTrangThaiCongViec() { Id = 1,  TenGoi = "Chưa phân công" },
            new MODELTrangThaiCongViec() { Id = 2,  TenGoi = "Đã phân công" },
            new MODELTrangThaiCongViec () { Id = 3, TenGoi = "Đang thực hiện" },
            new MODELTrangThaiCongViec () { Id = 4, TenGoi = "Chờ test" },
            new MODELTrangThaiCongViec () { Id = 5, TenGoi = "Đang test" },
            new MODELTrangThaiCongViec () { Id = 6, TenGoi = "Lỗi" },
            new MODELTrangThaiCongViec () { Id = 7, TenGoi = "Hoàn thành" }
        };

        public static List<MODELChuyenTrangThaiCongViec> diagramConnections = new List<MODELChuyenTrangThaiCongViec>
        {
            new MODELChuyenTrangThaiCongViec() { Id = Guid.NewGuid(), TrangThaiCongViecNguonId = 1, TrangThaiCongViecDich = 2 , TenChuyenTrangThai = "Trạng thái 1"},
            new MODELChuyenTrangThaiCongViec() { Id = Guid.NewGuid(), TrangThaiCongViecNguonId = 2, TrangThaiCongViecDich = 3  , TenChuyenTrangThai = "Trạng thái 2" },
            new MODELChuyenTrangThaiCongViec() { Id = Guid.NewGuid(), TrangThaiCongViecNguonId = 3, TrangThaiCongViecDich = 4 , TenChuyenTrangThai = "Trạng thái 3"},
            new MODELChuyenTrangThaiCongViec() { Id = Guid.NewGuid(), TrangThaiCongViecNguonId = 4, TrangThaiCongViecDich = 5 , TenChuyenTrangThai = "Trạng thái 4" },
            new MODELChuyenTrangThaiCongViec() { Id = Guid.NewGuid(), TrangThaiCongViecNguonId = 4, TrangThaiCongViecDich = 6 , TenChuyenTrangThai = "Trạng thái 5"},
            new MODELChuyenTrangThaiCongViec() { Id = Guid.NewGuid(), TrangThaiCongViecNguonId = 5, TrangThaiCongViecDich = 6 , TenChuyenTrangThai = "Trạng thái 6"},
            new MODELChuyenTrangThaiCongViec() { Id = Guid.NewGuid(), TrangThaiCongViecNguonId = 5, TrangThaiCongViecDich = 3  , TenChuyenTrangThai = "Trạng thái 7"},
            new MODELChuyenTrangThaiCongViec() { Id = Guid.NewGuid(), TrangThaiCongViecNguonId = 5, TrangThaiCongViecDich = 7 , TenChuyenTrangThai = "Trạng thái 8"},
            new MODELChuyenTrangThaiCongViec() { Id = Guid.NewGuid(), TrangThaiCongViecNguonId = 6, TrangThaiCongViecDich = 3 , TenChuyenTrangThai = "Trạng thái 9"}
        };

        // Read Shapes (Now returns static data)
        // Read Shapes (Now returns static data)
        public JsonResult ReadShapes()
        {
            var result = diagramShapes.Select(s => new
            {
                Id = s.Id,
                TenGoi = s.TenGoi
            }).ToList();

            return new JsonResult(result);
        }


        // Create Shape
        public ActionResult CreateShape([DataSourceRequest] DataSourceRequest request, MODELTrangThaiCongViec shape)
        {
            return Json(new[] { shape }.ToDataSourceResult(request, ModelState));
        }

        // Update Shape
        public ActionResult UpdateShape([DataSourceRequest] DataSourceRequest request, MODELTrangThaiCongViec shape)
        {
            return Json(new[] { shape }.ToDataSourceResult(request, ModelState));
        }

        // Destroy Shape
        public ActionResult DestroyShape([DataSourceRequest] DataSourceRequest request, MODELTrangThaiCongViec shape)
        {
            diagramShapes.Remove(shape);
            return Json(new[] { shape }.ToDataSourceResult(request, ModelState));
        }

        // Read Connections (Using static data)
        public ActionResult ReadConnections([DataSourceRequest] DataSourceRequest request)
        {
            // Ensure you return data in a proper structure expected by Kendo Diagram
            var result = diagramConnections.Select(c => new
            {
                Id = c.Id,
                TrangThaiCongViecNguonId = c.TrangThaiCongViecNguonId,
                TrangThaiCongViecDich = c.TrangThaiCongViecDich,
                TenChuyenTrangThai = c.TenChuyenTrangThai

            }).ToList();

            return Json(result.ToDataSourceResult(request));
        }

        // Create Connection
        public ActionResult CreateConnection([DataSourceRequest] DataSourceRequest request, MODELChuyenTrangThaiCongViec connection)
        {
            return Json(new[] { connection }.ToDataSourceResult(request, ModelState));
        }

        // Update Connection
        public ActionResult UpdateConnection([DataSourceRequest] DataSourceRequest request, MODELChuyenTrangThaiCongViec connection)
        {
            return Json(new[] { connection }.ToDataSourceResult(request, ModelState));
        }

        // Destroy Connection
        public ActionResult DestroyConnection([DataSourceRequest] DataSourceRequest request, MODELChuyenTrangThaiCongViec connection)
        {
            diagramConnections.Remove(connection);
            return Json(new[] { connection }.ToDataSourceResult(request, ModelState));
        }
    }
}
