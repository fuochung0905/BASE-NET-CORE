﻿using AutoDependencyRegistration.Attributes;
using AutoMapper;
using ENTITIES.DBContent;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.DANHMUC.TEAM.Dtos;
using MODELS.DANHMUC.TEAM.Requests;
using Repository;
using System.Collections;

namespace Service.DANHMUC.TEAM
{
    [RegisterClassAsTransient]
    public class TEAMService : ITEAMService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IHttpContextAccessor _contextAccessor;

        public TEAMService(
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
                     new SqlParameter("@iMonHocId", request.MonHocId.HasValue ? request.MonHocId : Guid.Empty),
                    new SqlParameter("@iTextSearch", request.TextSearch),
                    new SqlParameter("@iPageIndex", request.PageIndex),
                    new SqlParameter("@iRowsPerPage", request.RowPerPage),
                    iTotalRow
                };

                var result = _unitOfWork.GetRepository<MODELTeam>().ExcuteStoredProcedure("sp_DM_TEAM_GetListPaging", parameters).ToList();
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
        public BaseResponse<MODELTeam> GetById(GetByIdRequest request)
        {
            var response = new BaseResponse<MODELTeam>();
            try
            {
                var result = new MODELTeam();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_TEAM>().Find(x => x.Id == request.Id);
                if (data == null)
                    throw new Exception("Không tìm thấy thông tin");
                else
                {
                    result = _mapper.Map<MODELTeam>(data);
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
        public BaseResponse<PostTeamRequest> GetByPost(GetByIdRequest request)
        {
            var response = new BaseResponse<PostTeamRequest>();
            try
            {
                var result = new PostTeamRequest();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_TEAM>().Find(x => x.Id == request.Id);
                if (data == null)
                {
                    result.Id = Guid.NewGuid();
                    result.IsEdit = false;
                }
                else
                {
                    result = _mapper.Map<PostTeamRequest>(data);
                    var tkIds = _unitOfWork.GetRepository<TEAM_NGUOITHAMGIA>().GetAll(x=>x.TeamId == request.Id).Select(x=>x.TaiKhoanId).ToList();
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
        public BaseResponse<MODELTeam> Insert(PostTeamRequest request)
        {
            var response = new BaseResponse<MODELTeam>();
            try
            {
                var add = _mapper.Map<ENTITIES.DBContent.DM_TEAM>(request);
                add.NguoiTao = _contextAccessor.HttpContext.User.Identity.Name;
                add.NgayTao = DateTime.Now;
                add.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                add.NgaySua = DateTime.Now;
                _unitOfWork.GetRepository<ENTITIES.DBContent.DM_TEAM>().add(add);
                _unitOfWork.Commit();

                if (request.taiKhoanIds.Count() > 0)
                {
                    foreach(var id in request.taiKhoanIds) 
                    {
                        var newEnti = new TEAM_NGUOITHAMGIA
                        {
                            Id = Guid.NewGuid(),
                            TaiKhoanId = id,
                            TeamId = request.Id
                        };
                        _unitOfWork.GetRepository<TEAM_NGUOITHAMGIA>().add(newEnti);
                    }
                    _unitOfWork.Commit();
                }

                response.Data = _mapper.Map<MODELTeam>(add);
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //UPDATE
        public BaseResponse<MODELTeam> Update(PostTeamRequest request)
        {
            var response = new BaseResponse<MODELTeam>();
            try
            {
                var update = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_TEAM>().Find(x => x.Id == request.Id);
                if (update != null)
                {
                    _mapper.Map(request, update);
                    update.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                    update.NgaySua = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.DM_TEAM>().update(update);
                    _unitOfWork.Commit();
                    var listTaiKhoanCurrent = _unitOfWork.GetRepository<TEAM_NGUOITHAMGIA>().GetAll(x => x.TeamId == request.Id).ToList();
                    var currentUserId = listTaiKhoanCurrent.Select(x => x.TaiKhoanId).ToHashSet();
                    var newUserIds = request.taiKhoanIds.ToHashSet();
                    var toAdd = newUserIds.Except(currentUserId);
                    foreach (var id in toAdd)
                    {
                        var newEntry = new TEAM_NGUOITHAMGIA
                        {
                            Id = Guid.NewGuid(),
                            TeamId = request.Id,
                            TaiKhoanId = id
                        };
                        _unitOfWork.GetRepository<TEAM_NGUOITHAMGIA>().add(newEntry);
                    }
                    var toRemove = listTaiKhoanCurrent.Where(x => !newUserIds.Contains(x.TaiKhoanId)).ToList();
                    foreach (var entry in toRemove)
                    {
                        _unitOfWork.GetRepository<TEAM_NGUOITHAMGIA>().delete(entry);
                    }
                    _unitOfWork.Commit();
                    response.Data = _mapper.Map<MODELTeam>(update);
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
                var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_TEAM>().Find(x => x.Id == request.Id);
                if (delete != null)
                {
                    delete.IsDeleted = true;
                    delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                    delete.NgayXoa = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.DM_TEAM>().update(delete);
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
                    var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_TEAM>().Find(x => x.Id == id);
                    if (delete != null)
                    {
                        delete.IsDeleted = true;
                        delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                        delete.NgayXoa = DateTime.Now;

                        _unitOfWork.GetRepository<ENTITIES.DBContent.DM_TEAM>().update(delete);
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
            var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_TEAM>().GetAll(x => x.IsActived && !x.IsDeleted).ToList();
            response.Data = data.Select(x => new MODELCombobox
            {
                Text = x.TenGoi,
                Value = x.Id.ToString(),
            }).OrderBy(x => x.Sort).ToList();

            return response;
        }

        public BaseResponse<List<MODELCombobox>> GetAllForComboboxWithMonHoc(GetByIdRequest request)
        {
            BaseResponse<List<MODELCombobox>> response = new BaseResponse<List<MODELCombobox>>();
            if (request.Id == null)
            {
                response.Data = new List<MODELCombobox>(); 
                return response;
            }

            var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_TEAM>().GetAll(x => x.IsActived && !x.IsDeleted && x.MonHocId == request.Id).ToList();
            response.Data = data.Select(x => new MODELCombobox
            {
                Text = x.TenGoi,
                Value = x.Id.ToString(),
            }).OrderBy(x => x.Sort).ToList();

            return response;
        }
    }
}
