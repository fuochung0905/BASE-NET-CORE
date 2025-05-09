﻿using AutoDependencyRegistration.Attributes;
using AutoMapper;
using ENTITIES.DBContent;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.DANHMUC.CHUCVU.Dtos;
using MODELS.DANHMUC.CHUCVU.Requests;
using Repository;


namespace REPONSITORY.DANHMUC.CHUCVU
{
    [RegisterClassAsTransient]
    public class CHUCVUService : ICHUCVUService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IHttpContextAccessor _contextAccessor;

        public CHUCVUService(
            IHttpContextAccessor contextAccessor,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        // lấy danh sách
        public BaseResponse<GetListPagingResponse> GetList(GetListPagingRequest request)
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
                    new SqlParameter("@iPageIndex", request.PageIndex),
                    new SqlParameter("@iRowsPerPage", request.RowPerPage),
                    iTotalRow
                };

                var result = _unitOfWork.GetRepository<MODELChucVu>().ExcuteStoredProcedure("sp_DM_CHUCVU_GetListPaging", parameters).ToList();
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
        // Lấy thông tin id 
        public BaseResponse<MODELChucVu> GetById(GetByIdRequest request)
        {
            var response = new BaseResponse<MODELChucVu>();
            try
            {
                var result = new MODELChucVu();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_CHUCVU>().Find(x => x.Id == request.Id);
                if (data == null)
                    throw new Exception("Không tìm thấy thông tin");
                else
                {
                    result = _mapper.Map<MODELChucVu>(data);
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
        // thêm sửa thông tin
        public BaseResponse<PostChucVuRequest> GetByPost(GetByIdRequest request)
        {
            var response = new BaseResponse<PostChucVuRequest>();
            try
            {
                var result = new PostChucVuRequest();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_CHUCVU>().Find(x => x.Id == request.Id);
                if (data == null)
                {
                    result.Id = Guid.NewGuid();
                    result.IsEdit = false;
                }
                else
                {
                    result = _mapper.Map<PostChucVuRequest>(data);
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
        public BaseResponse<MODELChucVu> Insert(PostChucVuRequest request)
        {
            var response = new BaseResponse<MODELChucVu>();
            try
            {
                var checkIn = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_CHUCVU>().Find(p => p.MaChucVu.ToLower() == request.MaChucVu.ToLower() || p.TenChucVu.ToLower() == request.TenChucVu.ToLower());
                if (checkIn is not null)
                {
                    throw new Exception("Dữ liệu bị trùng lặp, vui lòng nhập lại!!");
                }
                var add = _mapper.Map<ENTITIES.DBContent.DM_CHUCVU>(request);
                add.NguoiTao = _contextAccessor.HttpContext.User.Identity.Name;
                add.NgayTao = DateTime.Now;
                add.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                add.NgaySua = DateTime.Now;
                _unitOfWork.GetRepository<ENTITIES.DBContent.DM_CHUCVU>().add(add);
                _unitOfWork.Commit();

                response.Data = _mapper.Map<MODELChucVu>(add);
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }
        //UPDATE
        public BaseResponse<MODELChucVu> Update(PostChucVuRequest request)
        {
            var response = new BaseResponse<MODELChucVu>();
            try
            {
                var update = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_CHUCVU>().Find(x => x.Id == request.Id);
                var checkInUpdate = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_CHUCVU>().Find(p => p.Id != request.Id  
                                                                                                     && (p.MaChucVu.ToLower() == request.MaChucVu.ToLower()
                                                                                                     || p.TenChucVu.ToLower() == request.TenChucVu.ToLower()));
                if(checkInUpdate is not null)
                {
                    throw new Exception("Dữ liệu cập nhật bị trùng lặp, vui lòng nhập lại!!");
                }
                if (update != null)
                {
                    _mapper.Map(request, update);
                    update.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                    update.NgaySua = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.DM_CHUCVU>().update(update);
                    _unitOfWork.Commit();

                    response.Data = _mapper.Map<MODELChucVu>(update);
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
                var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_CHUCVU>().Find(x => x.Id == request.Id);
                if (delete != null)
                {
                    delete.IsDeleted = true;
                    delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                    delete.NgayXoa = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.DM_CHUCVU>().update(delete);
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
                    var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_CHUCVU>().Find(x => x.Id == id);
                    if (delete != null)
                    {
                        delete.IsDeleted = true;
                        delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                        delete.NgayXoa = DateTime.Now;

                        _unitOfWork.GetRepository<ENTITIES.DBContent.DM_CHUCVU>().update(delete);
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
            var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_CHUCVU>().GetAll(x => x.IsActived && !x.IsDeleted).ToList();
            response.Data = data.Select(x => new MODELCombobox
            {
                Text = x.TenChucVu,
                Value = x.Id.ToString(),
            }).OrderBy(x => x.Sort).ToList();

            return response;
        }
    }
}
