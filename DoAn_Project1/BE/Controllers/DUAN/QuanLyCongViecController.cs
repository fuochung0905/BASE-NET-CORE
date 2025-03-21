using BE.Helper;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.COMMON;
using MODELS.DUAN.QUANLYCONGVIEC.Requests;
using REPONSITORY.DUAN.QUANLYCONGVIEC;
using REPONSITORY.HETHONG;

namespace BE.Controllers.DUAN;

[Route("api/[controller]")]
[ApiController]
public class QuanLyCongViecController : ControllerBase
{
	private readonly IQUANLYCONGVIECService _service;
    private INotificationHub _notificationHub;

    public QuanLyCongViecController(IQUANLYCONGVIECService service, INotificationHub notificationHub)
	{
		_service = service;
        _notificationHub = notificationHub;
    }

	[HttpPost, Route("get-list")]
    public IActionResult GetList(GetListQuanLyCongViecRequest request)
	{
		try
		{
			if(!ModelState.IsValid)
			{
				throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
			}
			var result = _service.GetList(request);
			if(result.Error)
			{
				throw new Exception(result.Message);
			}
			else
			{
				return Ok(new ApiOkResponse(result.Data));
			}
		}
		catch(Exception ex)
		{
            return Ok(new ApiResponse(false, 500, ex.Message));
        }
	}

    [HttpPost, Route("get-by-id")]
    public IActionResult GetById(GetByIdRequest request)
	{
		try
		{
			if(!ModelState.IsValid)
			{
				throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
			}
			var result = _service.GetById(request);
			if(result.Error)
			{
				throw new Exception(result.Message);
			}
			else
			{
				return Ok(new ApiOkResponse(result.Data));
			}
		}
		catch(Exception ex)
		{
            return Ok(new ApiResponse(false, 500, ex.Message));
        }
	}

	[HttpPost, Route("get-by-post")]
    public IActionResult GetByPost(GetByIdRequest request)
	{
		try
		{
			if(!ModelState.IsValid)
			{
				throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
			}
			var result = _service.GetByPost(request);
			if(result.Error)
			{
				throw new Exception(result.Message);
			}
			else
			{
				return Ok(new ApiOkResponse(result.Data));
			}
		}
		catch(Exception ex)
		{
            return Ok(new ApiResponse(false, 500, ex.Message));
        }
	}

	[HttpPost, Route("insert")]
    public IActionResult Insert(PostQuanLyCongViecRequest request)
	{
		try
		{
			if(!ModelState.IsValid)
			{
				throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
			}
			var result = _service.Insert(request);
            if (result.Error)
            {
                throw new Exception(result.Message);
            }
			else
			{
                if (result.Data.listAssignName.Count() > 0)
                {
                    foreach (var item in result.Data.listAssignName)
                    {
                        _notificationHub.SendMessage(new MODELNotification
                        {
                            NguoiGui = HttpContext.User.Identity.Name,
                            NguoiNhan = item,
                            Message = "Bạn có một công việc mới cần thực hiện"
                        });
                    }
                }
				return Ok(new ApiOkResponse(result.Data));
			}
		}
		catch(Exception ex)
		{
            return Ok(new ApiResponse(false, 500, ex.Message));
        }
	}

	[HttpPost, Route("update")]
    public IActionResult Update(PostQuanLyCongViecRequest request)
	{
		try
		{
			if(!ModelState.IsValid)
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
                if (result.Data.AssignName != null)
                {
                    _notificationHub.SendMessage(new MODELNotification
                    {
                        NguoiGui = HttpContext.User.Identity.Name,
                        NguoiNhan = result.Data.AssignName,
                        Message = "Bạn được assgin công việc"
                    });
                }
				if(result.Data.listAssignName.Count() > 0)
				{
					foreach(var item in result.Data.listAssignName)
					{
                        _notificationHub.SendMessage(new MODELNotification
                        {
                            NguoiGui = HttpContext.User.Identity.Name,
                            NguoiNhan = item,
                            Message = "Bạn có một công việc mới cần thực hiện"
                        });
                    }
               
                }
                return Ok(new ApiOkResponse(result.Data));
            }

        }
		catch(Exception ex)
		{
            return Ok(new ApiResponse(false, 500, ex.Message));
        }
	}

	[HttpPost, Route("delete")]
    public IActionResult Delete(DeleteRequest request)
	{
		try
		{
			if(!ModelState.IsValid)
			{
				throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
			}
			var result = _service.Delete(request);
			if(result.Error)
			{
				throw new Exception(result.Message);
			}
			else
			{
				return Ok(new ApiOkResponse(result.Data));
			}
		}
		catch(Exception ex)
		{
            return Ok(new ApiResponse(false, 500, ex.Message));
        }
	}

	[HttpPost, Route("delete-list")]
    public IActionResult DeleteList(DeleteListRequest request)
	{
		try
		{
			if(!ModelState.IsValid)
			{
				throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
			}
			var result = _service.DeleteList(request);
			if(result.Error)
			{
				throw new Exception(result.Message);
			}
			else
			{
				return Ok(new ApiOkResponse(result.Data));
			}
		}
		catch(Exception ex)
		{
            return Ok(new ApiResponse(false, 500, ex.Message));
        }
	}

    [HttpPost, Route("get-all-combo-box")]
    public IActionResult GetAllComboBox(PostQuanLyCongViecGetAllRequest request)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
            }
            var result = _service.GetAllComboBox(request);
            if(result.Error)
            {
                throw new Exception(result.Message);
            }
            else
            {
                return Ok(new ApiOkResponse(result.Data));
            }
        }
        catch(Exception ex)
        {
            return Ok(new ApiResponse(false, 500, ex.Message));
        }
    }
    [HttpPost, Route("get-all-combo-box-with-du-an")]
    public IActionResult GetAllComboBoxWithDuAN(PostQuanLyCongViecGetAllRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
            }
            var result = _service.GetAllComboBoxWithDuAn(request);
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
    [HttpPost, Route("get-combo-box-trang-thai")]
    public IActionResult GetComboBoxTrangThai(GetAllRequest request)
	{
		try
		{
			if(!ModelState.IsValid)
			{
				throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
			}
			var result = _service.GetComboBoxTrangThai(request);
			if(result.Error)
			{
				throw new Exception(result.Message);
			}
			else
			{
				return Ok(new ApiOkResponse(result.Data));
			}
		}
		catch(Exception ex)
		{
            return Ok(new ApiResponse(false, 500, ex.Message));
        }
	}

    [HttpPost, Route("get-combo-box-trang-thai-by-username")]
    public IActionResult GetComboBoxTrangThaiForUserName(GetAllRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
            }
            var result = _service.GetComboBoxTrangThaiForUserName(request);
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

    [HttpPost, Route("tong-so-cong-viec")]
    public IActionResult GetTongSoCongViec(PostTongSoCongViecRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
            }

            var result = _service.GetTongSoCongViec(request);
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

    [HttpPost, Route("tong-so-gio-cong")]
    public IActionResult GetTongSoGioCong(PostTongSoCongViecRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
            }

            var result = _service.GetTongSoGioCongTrongCongViec(request);
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

    [HttpPost, Route("get-all-combo-box-chi-tiet-cong-viec")]
    public IActionResult GetAllComboBoxChiTietCongViec(PostQuanLyCongViecRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
            }
            var result = _service.GetAllForComboboxChiTietCongViec(request);
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
