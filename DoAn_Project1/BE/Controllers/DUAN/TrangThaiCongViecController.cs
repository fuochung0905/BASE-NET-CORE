using BE.Helper;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.COMMON;
using MODELS.DUAN.TRANGTHAICONGVIEC.Request;
using MODELS.HETHONG.TAIKHOAN.Requests;
using REPONSITORY.DUAN.TRANGTHAICONGVIEC;
using REPONSITORY.HETHONG;

namespace BE.Controllers.DUAN
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrangThaiCongViecController : ControllerBase
    {
        private ITRANGTHAICONGVIECService _service;
        private INotificationHub _notificationHub;
        public TrangThaiCongViecController(ITRANGTHAICONGVIECService service, INotificationHub notificationHub)
        {
            _service = service;
            _notificationHub = notificationHub;
        }

        [HttpPost, Route("get-list-cong-viec")]
        public IActionResult GetListCongViec(PostTrangThaiCongViecGetListPagingRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }

                var result = _service.GetListCongViec(request);
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

        [HttpPost, Route("get-list-trang-thai")]
        public IActionResult GetListTrangThai()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }

                var result = _service.GetListTrangThaiCongViec();
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
        public IActionResult Update(PostTrangThaiCongViecRequest request)
        {
	        try
	        {
		        if (!ModelState.IsValid)
		        {
			        throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
		        }
		        var result = _service.UpdateTrangThaiCongViec(request);
               

		        if (result.Error)
		        {
			        throw new Exception(result.Message);
		        }
		        else
		        {
                    _notificationHub.SendMessage(new MODELNotification
                    {
                        NguoiNhan = result.Data.NguoiAssignTo,
                        NguoiGui = HttpContext.User.Identity.Name,
                        Message = "Bạn được assign một task mới"
                    });
                    return Ok(new ApiOkResponse(result.Data));
		        }
			}
	        catch (Exception ex)
	        {
                return Ok(new ApiResponse(false, 500, ex.Message));
            }
        }

        [HttpPost, Route("update-congviec")]
        public IActionResult UpdateCongViecByTrangThai(PostCongViecByTrangThaiRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }
                var result = _service.UpdateCongViecByTrangThai(request);
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

        [HttpPost, Route("check-role")]
        public IActionResult CheckRole(GetListPagingRequest temp)
        {
	        try
	        {
		        var result = _service.CheckRoleUser();
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

        [HttpPost, Route("get-by-id")]
        public IActionResult GetById(GetByIdRequest request)
        {
	        try
	        {
		        if (!ModelState.IsValid)
		        {
			        throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
		        }

		        var result = _service.GetById(request);
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
