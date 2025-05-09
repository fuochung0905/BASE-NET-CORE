﻿using FE.Constants;
using FE.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS.BASE;
using MODELS.DANHMUC.Dtos;
using MODELS.DANHMUC.Requests;
using MODELS;
using Newtonsoft.Json;
using MODELS.DANHMUC.TEAM.Dtos;
using MODELS.DANHMUC.TEAM.Requests;

namespace FE.Controllers.DANHMUC
{
    public class TeamController : BaseController<ChucVuController>
    {
        public IActionResult Index()
        {
            return View("~/Views/DanhMuc/Team/Index.cshtml", GetPhanQuyen());
        }

        public IActionResult GetList([DataSourceRequest] DataSourceRequest request, PostMonHocGetListPagingRequest param)
        {
            try
            {
                var result = new List<MODELTeam>();
                param.PageIndex = request.Page - 1;
                param.RowPerPage = request.PageSize;
                param.TextSearch = param.TextSearch == null ? string.Empty : param.TextSearch.Trim();


                ResponseData response = this.PostAPI(URL_API.TEAM_GETLIST, param);
                DataSourceResult dataSourceResult = result.ToDataSourceResult(request);
                if (response.Status)
                {
                    var dataResult = JsonConvert.DeserializeObject<GetListPagingResponse>(response.Data.ToString());
                    result = JsonConvert.DeserializeObject<List<MODELTeam>>(dataResult.Data.ToString());
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

        public IActionResult GetListAll()
        {
            try
            {
                var result = new List<MODELTeam>();
                ResponseData response = this.PostAPI(URL_API.TEAM_GETLIST, new GetAllRequest());

                if (response.Status)
                {
                    result = JsonConvert.DeserializeObject<List<MODELTeam>>(response.Data.ToString());
                }
                else
                {
                    throw new Exception(response.Message);
                }

                return Json(result);
            }
            catch
            {
                return Json(new List<MODELTeam>());
            }
        }

        public ActionResult ShowViewPopup(Guid id)
        {
            try
            {
                MODELTeam obj = new MODELTeam();

                if (id != null)
                {
                    ResponseData response = this.PostAPI(URL_API.TEAM_GETBYID, new { Id = id });

                    if (response.Status)
                    {
                        obj = JsonConvert.DeserializeObject<MODELTeam>(response.Data.ToString());
                    }
                }

                return PartialView("~/Views/DanhMuc/Team/PopupView.cshtml", obj);
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
                PostTeamRequest obj = new PostTeamRequest();

                ResponseData response = this.PostAPI(URL_API.TEAM_GETBYPOST, new { Id = Guid.Empty });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostTeamRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/DanhMuc/Team/PopupDetail.cshtml", obj);
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
                PostTeamRequest obj = new PostTeamRequest();

                ResponseData response = this.PostAPI(URL_API.TEAM_GETBYPOST, new { Id = id });

                if (response.Status)
                {
                    obj = JsonConvert.DeserializeObject<PostTeamRequest>(response.Data.ToString());
                }

                return PartialView("~/Views/DanhMuc/Team/PopupDetail.cshtml", obj);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return PartialView("~/Views/Shared/ErrorPartial.cshtml");
            }
        }

        [HttpPost]
        public JsonResult Post([DataSourceRequest] DataSourceRequest dataSourceRequest, PostTeamRequest param)
        {
            try
            {
                if (param != null && ModelState.IsValid)
                {
                    ResponseData response;
                    if (param.IsEdit)
                    {
                        response = this.PostAPI(URL_API.TEAM_UPDATE, param);
                    }
                    else
                    {
                        response = this.PostAPI(URL_API.TEAM_INSERT, param);
                    }
                    if (!response.Status)
                    {
                        return Json(new { IsSuccess = false, Message = response.Message, Data = "" });
                    }
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = MODELS.COMMON.CommonFunc.GetModelStateAPI(this.ModelState), Data = "" });
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
                ResponseData response = this.PostAPI(URL_API.TEAM_DELETELIST, new { ids = listSelectedId }); ;
                return Json(new { IsSuccess = response.Status, Message = response.Message, Data = "" });
            }
            catch (Exception ex)
            {
                string message = "Lỗi xóa thông tin: " + ex.Message;
                return Json(new { IsSuccess = false, Message = message, Data = "" });
            }
        }

        public ActionResult GetList_Combobox()
        {
            ResponseData response = this.PostAPI(URL_API.TEAM_GETALLFORCOMBOBOX, new GetAllRequest());
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result);
        }
        public ActionResult GetList_ComboboxOfMonHoc(Guid? MonHocId)
        {
            var request = new GetByIdRequest();
            request.Id = MonHocId;  
            ResponseData response = this.PostAPI(URL_API.TEAM_GETALLCOMBOBOXOFMONHOC, request);
            var result = JsonConvert.DeserializeObject<List<MODELCombobox>>(response.Data.ToString());
            return Json(result);
        }
    }
}
