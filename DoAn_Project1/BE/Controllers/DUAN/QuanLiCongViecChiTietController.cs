using BE.Helper;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS;
using MODELS.COMMON;
using MODELS.DUAN.QUANLICONGVIEC_CHITIET.Requests;
using MODELS.DUAN.QUANLYDUAN.Requests;
using REPONSITORY.DUAN.QUANLYCONGVIECCHITIET;

namespace BE.Controllers.DUAN
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanLiCongViecChiTietController : ControllerBase
    {
        private readonly IQUANLICONGVIECCHITIETService _service;

        public QuanLiCongViecChiTietController(IQUANLICONGVIECCHITIETService service)
        {
            _service = service;
        }

        [HttpPost, Route("get-list")]
        public IActionResult GetList(GetListCongViecChiTietRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }
                var result = _service.GetList(request);
                if (result.Error)
                {
                    throw new Exception(result.Message);
                }
                else
                {
                    return Ok(new ApiOkResponse(result.Data));
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(false, 500, ex.Message));
            }
        }
        [HttpPost, Route("get-by-post")]
        public IActionResult GetByPost(GetByIdRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }
                var result = _service.GetByPost(request);
                if (result.Error)
                {
                    throw new Exception(result.Message);
                }
                else
                {
                    return Ok(new ApiOkResponse(result.Data));
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(false, 500, ex.Message));
            }
        }       
        [HttpPost, Route("update")]
        public IActionResult Update(PostQuanLiCongViec_ChiTietRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }
                var result = _service.Update(request);
                if (result.Error)
                {
                    throw new Exception(result.Message);
                }
                else
                {
                    return Ok(new ApiOkResponse(result.Data));
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(false, 500, ex.Message));
            }
        }
    }
}
