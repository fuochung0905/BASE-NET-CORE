using FE.Constants;
using FE.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.COMMON;
using MODELS.DANHMUC.GIAIDOANDUAN.Dtos;
using MODELS.DANHMUC.GIAIDOANDUAN.Requests;
using MODELS.DANHMUC.PHUONGXA.Requests;
using MODELS.HETHONG.TAIKHOAN.Requests;
using Newtonsoft.Json;

namespace FE.Controllers.DANHMUC;

public class GiaiDoanDuAnController : BaseController<GiaiDoanDuAnController>
{
	public IActionResult Index()
	{
		return View("~/Views/DanhMuc/GiaiDoanDuAn/Index.cshtml", GetPhanQuyen());
	}

	public IActionResult GetList([DataSourceRequest] DataSourceRequest request, GetListPagingRequest param)
	{
		try
		{
			var result = new List<MODELGiaiDoanDuAn>();
			param.PageIndex = request.Page - 1;
			param.RowPerPage = request.PageSize;
			param.TextSearch = param.TextSearch == null ? string.Empty : param.TextSearch.Trim();


			ResponseData response = this.PostAPI(URL_API.GIAIDOANDUAN_GETLIST, param);
			DataSourceResult dataSourceResult = result.ToDataSourceResult(request);
			if (response.Status)
			{
				var dataResult = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
				result = JsonConvert.DeserializeObject<List<MODELGiaiDoanDuAn>>(dataResult.Data.ToString());
				dataSourceResult = result.ToDataSourceResult(request);
				dataSourceResult.Total = dataResult.TotalRow;
				dataSourceResult.Data = result;
			}
			else
			{
				throw new Exception(response.Message);
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

	public ActionResult ShowViewPopup(Guid id)
	{
		try
		{
			MODELGiaiDoanDuAn obj = new MODELGiaiDoanDuAn();

			if (id != null)
			{
				ResponseData response = this.PostAPI(URL_API.GIAIDOANDUAN_GETBYID, new { Id = id });

				if (response.Status)
				{
					obj = JsonConvert.DeserializeObject<MODELGiaiDoanDuAn>(response.Data.ToString());
				}
			}

			return PartialView("~/Views/DanhMuc/GiaiDoanDuAn/PopupView.cshtml", obj);
		}
		catch (Exception ex)
		{
			ViewBag.ErrorMessage = ex.Message;
			return PartialView("~/Views/Shared/ErrorPartial.cshtml");
		}
	}

	public ActionResult ShowInsertPopup()
	{
		try
		{
			PostGiaiDoanDuAnRequest obj = new PostGiaiDoanDuAnRequest();

			ResponseData response = this.PostAPI(URL_API.GIAIDOANDUAN_GETBYPOST, new { Id = Guid.Empty });

			if (response.Status)
			{
				obj = JsonConvert.DeserializeObject<PostGiaiDoanDuAnRequest>(response.Data.ToString());
			}

			return PartialView("~/Views/DanhMuc/GiaiDoanDuAn/PopupDetail.cshtml", obj);
		}
		catch (Exception ex)
		{
			ViewBag.ErrorMessage = ex.Message;
			return PartialView("~/Views/Shared/ErrorPartial.cshtml");
		}
	}

	public ActionResult ShowUpdatePopup(Guid id)
	{
		try
		{
			PostGiaiDoanDuAnRequest obj = new PostGiaiDoanDuAnRequest();

			ResponseData response = this.PostAPI(URL_API.GIAIDOANDUAN_GETBYPOST, new { Id = id });

			if (response.Status)
			{
				obj = JsonConvert.DeserializeObject<PostGiaiDoanDuAnRequest>(response.Data.ToString());
			}

			return PartialView("~/Views/DanhMuc/GiaiDoanDuAn/PopupDetail.cshtml", obj);
		}
		catch (Exception ex)
		{
			ViewBag.ErrorMessage = ex.Message;
			return PartialView("~/Views/Shared/ErrorPartial.cshtml");
		}
	}

	[HttpPost]
	public JsonResult Post([DataSourceRequest] DataSourceRequest dataSourceRequest, PostGiaiDoanDuAnRequest param)
	{
		try
		{
			if (param != null && ModelState.IsValid)
			{
				ResponseData response;
				if (param.IsEdit)
				{
					response = this.PostAPI(URL_API.GIAIDOANDUAN_UPDATE, param);
				}
				else
				{
					response = this.PostAPI(URL_API.GIAIDOANDUAN_INSERT, param);
				}
				if (!response.Status)
				{
					return Json(new { IsSuccess = false, Message = response.Message, Data = "" });
				}
			}
			else
			{
				return Json(new { IsSuccess = false, Message = CommonFunc.GetModelStateAPI(this.ModelState), Data = "" });
			}
			return Json(new { IsSuccess = true, Message = "", Data = param.IsEdit });
		}
		catch (Exception ex)
		{
			string message = "Lỗi cập nhật thông tin: " + ex.Message;
			return Json(new { IsSuccess = false, Message = message, Data = "" });
		}
	}

	[HttpPost]
	public JsonResult Delete([DataSourceRequest] DataSourceRequest dataSourceRequest, List<Guid> listSelectedId)
	{
		try
		{
			ResponseData response = this.PostAPI(URL_API.GIAIDOANDUAN_DELETELIST, new { ids = listSelectedId }); ;
			return Json(new { IsSuccess = response.Status, Message = response.Message, Data = "" });
		}
		catch (Exception ex)
		{
			string message = "Lỗi xóa thông tin: " + ex.Message;
			return Json(new { IsSuccess = false, Message = message, Data = "" });
		}
	}

	public ActionResult GetAllComboBox(GetAllRequest param)
	{
		ResponseData response = this.PostAPI(URL_API.GIAIDOANDUAN_GETALLFORCOMBOBOX, param);
		var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
		return Json(result);
	}
}