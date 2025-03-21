using BE.Helper;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS;
using MODELS.DUAN.LICHSUCONGVIEC;
using REPONSITORY.DUAN.LICHSUCONGVIEC;


namespace BE.Controllers.DUAN
{
    [ApiController]
    [Route("api/[controller]")]
    public class LichSuCongViecController : ControllerBase
    {
        private ILICHSUCONGVIECService _service;
        public LichSuCongViecController(ILICHSUCONGVIECService service)
        {
            _service = service;
        }

        [HttpPost, Route("get-list")]

        public IActionResult GetList(GetByIdRequest requets)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }

                var result = _service.GetList(requets);
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
