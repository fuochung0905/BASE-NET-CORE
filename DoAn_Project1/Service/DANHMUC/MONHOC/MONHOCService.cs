﻿using AutoDependencyRegistration.Attributes;
using AutoMapper;
using ENTITIES.DBContent;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.DANHMUC.Dtos;
using MODELS.DANHMUC.MONHOC.Dtos;
using MODELS.DANHMUC.MONHOC.Requests;
using MODELS.DANHMUC.Requests;
using MODELS.HETHONG.HETHONGTHONGBAO.Dtos;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DANHMUC.MONHOC
{
    [RegisterClassAsTransient]
    public class MONHOCService : IMONHOCService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IHttpContextAccessor _contextAccessor;

        public MONHOCService(
            IHttpContextAccessor contextAccessor,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        //GET LIST
        public BaseResponse<GetListPagingResponse> GetList(PostMonHocGetListPagingRequest request)
        {
            var response = new BaseResponse<GetListPagingResponse>();
            try
            {
                SqlParameter iTotalRow = new SqlParameter()
                {
                    ParameterName = "@oTotalRow",
                    SqlDbType = System.Data.SqlDbType.BigInt,
                    Direction = System.Data.ParameterDirection.Output
                };

                var parameters = new[]
                {
                    new SqlParameter("@iNienKhoaId", request.NienKhoaId.HasValue ? request.NienKhoaId : Guid.Empty),
                    new SqlParameter("@iPhongBanId", request.NienKhoaId.HasValue ? request.NienKhoaId : Guid.Empty),
                    new SqlParameter("@iTextSearch", request.TextSearch),
                    new SqlParameter("@iPageIndex", request.PageIndex),
                    new SqlParameter("@iRowsPerPage", request.RowPerPage),
                    iTotalRow
                };

                var result = _unitOfWork.GetRepository<MODELMonHoc>().ExcuteStoredProcedure("sp_DM_MONHOC_GetListPaging", parameters).ToList();
                GetListPagingResponse resposeData = new GetListPagingResponse();
                resposeData.PageIndex = request.PageIndex;
                resposeData.Data = result;
                resposeData.TotalRow = Convert.ToInt32(iTotalRow.Value);

                response.Data = resposeData;

            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //GET BY ID
        public BaseResponse<MODELMonHoc> GetById(GetByIdRequest request)
        {
            var response = new BaseResponse<MODELMonHoc>();
            try
            {
                var result = new MODELMonHoc();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_MONHOC>().Find(x => x.Id == request.Id);
                if (data == null)
                    throw new Exception("Không tìm thấy thông tin");
                else
                {
                    result = _mapper.Map<MODELMonHoc>(data);
                }
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //GET BY POST (INSERT/UPDATE)
        public BaseResponse<PostMonHocRequest> GetByPost(GetByIdRequest request)
        {
            var response = new BaseResponse<PostMonHocRequest>();
            try
            {
                var result = new PostMonHocRequest();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_MONHOC>().Find(x => x.Id == request.Id);
                if (data == null)
                {
                    result.Id = Guid.NewGuid();
                    result.IsEdit = false;
                }
                else
                {
                    result = _mapper.Map<PostMonHocRequest>(data);
                    var tkIds = _unitOfWork.GetRepository<MONHOC_NGUOITHAMGIA>().GetAll(x => x.MonHocId == request.Id).Select(x => x.TaiKhoanId).ToList();
                    result.taiKhoanIds = tkIds;
                    result.IsEdit = true;
                }
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //INSERT
        public BaseResponse<MODELMonHoc> Insert(PostMonHocRequest request)
        {
            var response = new BaseResponse<MODELMonHoc>();
            try
            {
                var add = _mapper.Map<ENTITIES.DBContent.DM_MONHOC>(request);
                add.NguoiTao = _contextAccessor.HttpContext.User.Identity.Name;
                add.NgayTao = DateTime.Now;
                add.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                add.NgaySua = DateTime.Now;
                _unitOfWork.GetRepository<ENTITIES.DBContent.DM_MONHOC>().add(add);
                _unitOfWork.Commit();
                if (request.taiKhoanIds.Count > 0)
                {
                    List<MONHOC_NGUOITHAMGIA> tk_mk = new List<MONHOC_NGUOITHAMGIA>();
                    foreach (var id in request.taiKhoanIds)
                    {
                        var item = new MONHOC_NGUOITHAMGIA
                        {
                            Id = Guid.NewGuid(),
                            MonHocId = add.Id,
                            TaiKhoanId = id,
                        };
                        tk_mk.Add(item);
                    }
                    _unitOfWork.GetRepository<MONHOC_NGUOITHAMGIA>().addRange(tk_mk);
                    _unitOfWork.Commit();
                    //response.Data = _mapper.Map<MODELThongBao>(add);
                    //response.Data.UserId = new List<string>();
                    //foreach (var item in utb)
                    //{
                    //    var userName = _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().Find(x => x.Id == item.TaiKhoanId);
                    //    if (userName != null)
                    //    {
                    //        response.Data.UserId.Add(userName.UserName);
                    //    }
                    //}

                }
               

                response.Data = _mapper.Map<MODELMonHoc>(add);
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //UPDATE
        public BaseResponse<MODELMonHoc> Update(PostMonHocRequest request)
        {
            var response = new BaseResponse<MODELMonHoc>();
            try
            {
                var update = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_MONHOC>().Find(x => x.Id == request.Id);
                if (update != null)
                {
                    _mapper.Map(request, update);
                    update.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                    update.NgaySua = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.DM_MONHOC>().update(update);
                    _unitOfWork.Commit();

                    var listTaiKhoanCurrent = _unitOfWork.GetRepository<MONHOC_NGUOITHAMGIA>().GetAll(x => x.MonHocId == request.Id).ToList();
                    var currentUserIds = listTaiKhoanCurrent.Select(x => x.TaiKhoanId).ToHashSet();
                    var newUserIds = request.taiKhoanIds.ToHashSet();
                    var toAdd = newUserIds.Except(currentUserIds);
                    foreach(var id in toAdd)
                    {
                        var newEnti = new MONHOC_NGUOITHAMGIA
                        {
                            Id = Guid.NewGuid(),
                            TaiKhoanId = id,
                            MonHocId = request.Id
                        };
                        _unitOfWork.GetRepository<MONHOC_NGUOITHAMGIA>().add(newEnti);
                    }

                    var toRemove = listTaiKhoanCurrent.Where(x => !newUserIds.Contains(x.TaiKhoanId)).ToList();
                    foreach(var entry in toRemove)
                    {
                        _unitOfWork.GetRepository<MONHOC_NGUOITHAMGIA>().delete(entry);
                    }
                    _unitOfWork.Commit();
                    response.Data = _mapper.Map<MODELMonHoc>(update);                   
                }
                else
                {
                    throw new Exception("Không tìm thấy dữ liệu");
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //DELETE
        public BaseResponse<string> Delete(DeleteRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {
                var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_MONHOC>().Find(x => x.Id == request.Id);
                if (delete != null)
                {
                    delete.IsDeleted = true;
                    delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                    delete.NgayXoa = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.DM_MONHOC>().update(delete);
                }
                else
                {
                    throw new Exception("Không tìm thấy dữ liệu");
                }
                _unitOfWork.Commit();
                response.Data = request.Id.ToString();
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //DELETE LIST
        public BaseResponse<string> DeleteList(DeleteListRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {
                foreach (var id in request.Ids)
                {
                    var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_MONHOC>().Find(x => x.Id == id);
                    if (delete != null)
                    {
                        delete.IsDeleted = true;
                        delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                        delete.NgayXoa = DateTime.Now;

                        _unitOfWork.GetRepository<ENTITIES.DBContent.DM_MONHOC>().update(delete);
                    }
                    else
                    {
                        throw new Exception("Không tìm thấy dữ liệu");
                    }
                }
                _unitOfWork.Commit();
                response.Data = String.Join(',', request.Ids);
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //GET ALL FOR COMBOBOX
        public BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request)
        {
            BaseResponse<List<MODELCombobox>> response = new BaseResponse<List<MODELCombobox>>();
            var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_MONHOC>().GetAll(x => x.IsActived && !x.IsDeleted).ToList();
            response.Data = data.Select(x => new MODELCombobox
            {
                Text = x.TenGoi,
                Value = x.Id.ToString(),
            }).OrderBy(x => x.Sort).ToList();

            return response;
        }
    }
}
