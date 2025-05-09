﻿using AutoDependencyRegistration.Attributes;
using AutoMapper;
using ENTITIES.DBContent;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.DANHMUC.PHONGBAN.Dtos;
using MODELS.DANHMUC.PHONGBAN.Requests;
using MODELS.DANHMUC.PHUONGXA.Requests;
using MODELS.HETHONG.TAIKHOAN.Requests;
using Repository;


namespace REPONSITORY.DANHMUC.PHONGBAN
{
    [RegisterClassAsTransient]
    public class PHONGBANService : IPHONGBANService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IHttpContextAccessor _contextAccessor;

        public PHONGBANService(
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
        public BaseResponse<GetListPagingResponse> GetList(GetListPhongBanRequest request)
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
                    new SqlParameter("@iTextSearch", request.TextSearch),
                    new SqlParameter("@iDonViId", request.DonViId.HasValue ? request.DonViId : Guid.Empty),
                    new SqlParameter("@iPageIndex", request.PageIndex),
                    new SqlParameter("@iRowsPerPage", request.RowPerPage),
                    iTotalRow
                };

                var result = _unitOfWork.GetRepository<MODELPhongBan>().ExcuteStoredProcedure("sp_DM_PHONGBAN_GetListPaging", parameters).ToList();
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
        public BaseResponse<MODELPhongBan> GetById(GetByIdRequest request)
        {
            var response = new BaseResponse<MODELPhongBan>();
            try
            {
                var result = new MODELPhongBan();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_PHONGBAN>().Find(x => x.Id == request.Id);
                if (data == null)
                    throw new Exception("Không tìm thấy thông tin");
                else
                {
                    result = _mapper.Map<MODELPhongBan>(data);
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
        public BaseResponse<PostPhongBanRequest> GetByPost(GetByIdRequest request)
        {
            var response = new BaseResponse<PostPhongBanRequest>();
            try
            {
                var result = new PostPhongBanRequest();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_PHONGBAN>().Find(x => x.Id == request.Id);
                if (data == null)
                {
                    result.Id = Guid.NewGuid();
                    result.IsEdit = false;
                }
                else
                {
                    result = _mapper.Map<PostPhongBanRequest>(data);
                    var tkIds = _unitOfWork.GetRepository<PHONGBAN_NGUOITHAMGIA>().GetAll(x => x.PhongBanId == request.Id).Select(x=>x.TaiKhoanId).ToList();
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
        public BaseResponse<MODELPhongBan> Insert(PostPhongBanRequest request)
        {
            var response = new BaseResponse<MODELPhongBan>();
            try
            {
                var add = _mapper.Map<ENTITIES.DBContent.DM_PHONGBAN>(request);
                add.NguoiTao = _contextAccessor.HttpContext.User.Identity.Name;
                add.NgayTao = DateTime.Now;
                add.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                add.NgaySua = DateTime.Now;
                _unitOfWork.GetRepository<ENTITIES.DBContent.DM_PHONGBAN>().add(add);
                _unitOfWork.Commit();

                if (request.taiKhoanIds.Count > 0)
                {
                    List<PHONGBAN_NGUOITHAMGIA> tk_mk = new List<PHONGBAN_NGUOITHAMGIA>();
                    foreach (var id in request.taiKhoanIds)
                    {
                        var item = new PHONGBAN_NGUOITHAMGIA
                        {
                            Id = Guid.NewGuid(),
                            PhongBanId = add.Id,
                            TaiKhoanId = id,
                        };
                        tk_mk.Add(item);
                    }
                    _unitOfWork.GetRepository<PHONGBAN_NGUOITHAMGIA>().addRange(tk_mk);
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

                response.Data = _mapper.Map<MODELPhongBan>(add);
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //UPDATE
        public BaseResponse<MODELPhongBan> Update(PostPhongBanRequest request)
        {
            var response = new BaseResponse<MODELPhongBan>();
            try
            {
                var update = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_PHONGBAN>().Find(x => x.Id == request.Id);
                if (update != null)
                {
                    _mapper.Map(request, update);
                    update.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                    update.NgaySua = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.DM_PHONGBAN>().update(update);
                    _unitOfWork.Commit();
                    var listTaiKhoanCurrent = _unitOfWork.GetRepository<PHONGBAN_NGUOITHAMGIA>().GetAll(x=>x.PhongBanId == request.Id).ToList();
                    var currentUserId = listTaiKhoanCurrent.Select(x=>x.TaiKhoanId).ToHashSet();
                    var newUserIds = request.taiKhoanIds.ToHashSet();
                    var toAdd = newUserIds.Except(currentUserId);
                    foreach (var id in toAdd)
                    {
                        var newEntry = new PHONGBAN_NGUOITHAMGIA
                        {
                            Id = Guid.NewGuid(),
                            PhongBanId = request.Id,
                            TaiKhoanId = id                     
                        };
                        _unitOfWork.GetRepository<PHONGBAN_NGUOITHAMGIA>().add(newEntry);
                    }
                    var toRemove = listTaiKhoanCurrent.Where(x => !newUserIds.Contains(x.TaiKhoanId)).ToList();
                    foreach (var entry in toRemove)
                    {
                        _unitOfWork.GetRepository<PHONGBAN_NGUOITHAMGIA>().delete(entry);
                    }
                    _unitOfWork.Commit();
                    response.Data = _mapper.Map<MODELPhongBan>(update);
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
                var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_PHONGBAN>().Find(x => x.Id == request.Id);
                if (delete != null)
                {
                    delete.IsDeleted = true;
                    delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                    delete.NgayXoa = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.DM_PHONGBAN>().update(delete);
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
                    var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_PHONGBAN>().Find(x => x.Id == id);
                    if (delete != null)
                    {
                        delete.IsDeleted = true;
                        delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                        delete.NgayXoa = DateTime.Now;

                        _unitOfWork.GetRepository<ENTITIES.DBContent.DM_PHONGBAN>().update(delete);
                    }
                    else
                    {
                        throw new Exception("Không tìm thấy dữ liệu");
                    }
                }
                _unitOfWork.Commit();
                response.Data = String.Join(',', request);
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
            var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_PHONGBAN>()
                .GetAll(x => x.IsActived && !x.IsDeleted).ToList();
            response.Data = data.Select(x => new MODELCombobox
            {
                Text = x.TenGoi,
                Value = x.Id.ToString(),
            }).OrderBy(x => x.Text).ToList();

            return response;
        }


        //GET ALL FOR COMBOBOX WITH DONVI
        public BaseResponse<List<MODELCombobox>> GetAllForComboboxWithDonVi(GetAllPhongBanRequest request)
        {
            BaseResponse<List<MODELCombobox>> response = new BaseResponse<List<MODELCombobox>>();
            var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_PHONGBAN>()
                .GetAll(x => x.IsActived == true && x.IsDeleted == false && (x.DonViId == request.DonViId || request.DonViId == null)).ToList();
            response.Data = data.Select(x => new MODELCombobox
            {
                Text = x.TenGoi,
                Value = x.Id.ToString(),
            }).OrderBy(x => x.Text).ToList();

            return response;
        }
    }
}
