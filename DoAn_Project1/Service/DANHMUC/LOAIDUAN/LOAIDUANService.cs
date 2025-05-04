using AutoDependencyRegistration.Attributes;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Model.BASE;
using MODELS.BASE;
using MODELS.DANHMUC.Dtos;
using MODELS.DANHMUC.Requests;
using MODELS;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS.DANHMUC.LOAIDUAN.Dtos;
using MODELS.DANHMUC.LOAIDUAN.Requests;

namespace Service.DANHMUC.LOAIDUAN
{
    [RegisterClassAsTransient]
    public class LOAIDUANService : ILOAIDUANService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IHttpContextAccessor _contextAccessor;

        public LOAIDUANService(
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

                var result = _unitOfWork.GetRepository<MODELLoaiDuAn>().ExcuteStoredProcedure("sp_DM_LOAIDUAN_GetListPaging", parameters).ToList();
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
        public BaseResponse<MODELLoaiDuAn> GetById(GetByIdRequest request)
        {
            var response = new BaseResponse<MODELLoaiDuAn>();
            try
            {
                var result = new MODELLoaiDuAn();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_LOAIDUAN>().Find(x => x.Id == request.Id);
                if (data == null)
                    throw new Exception("Không tìm thấy thông tin");
                else
                {
                    result = _mapper.Map<MODELLoaiDuAn>(data);
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
        public BaseResponse<PostLoaiDuAnRequest> GetByPost(GetByIdRequest request)
        {
            var response = new BaseResponse<PostLoaiDuAnRequest>();
            try
            {
                var result = new PostLoaiDuAnRequest();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_LOAIDUAN>().Find(x => x.Id == request.Id);
                if (data == null)
                {
                    result.Id = Guid.NewGuid();
                    result.IsEdit = false;
                }
                else
                {
                    result = _mapper.Map<PostLoaiDuAnRequest>(data);
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
        public BaseResponse<MODELLoaiDuAn> Insert(PostLoaiDuAnRequest request)
        {
            var response = new BaseResponse<MODELLoaiDuAn>();
            try
            {
                var add = _mapper.Map<ENTITIES.DBContent.DM_LOAIDUAN>(request);
                add.NguoiTao = _contextAccessor.HttpContext.User.Identity.Name;
                add.NgayTao = DateTime.Now;
                add.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                add.NgaySua = DateTime.Now;
                _unitOfWork.GetRepository<ENTITIES.DBContent.DM_LOAIDUAN>().add(add);
                _unitOfWork.Commit();

                response.Data = _mapper.Map<MODELLoaiDuAn>(add);
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //UPDATE
        public BaseResponse<MODELLoaiDuAn> Update(PostLoaiDuAnRequest request)
        {
            var response = new BaseResponse<MODELLoaiDuAn>();
            try
            {
                var update = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_LOAIDUAN>().Find(x => x.Id == request.Id);
                if (update != null)
                {
                    _mapper.Map(request, update);
                    update.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                    update.NgaySua = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.DM_LOAIDUAN>().update(update);
                    _unitOfWork.Commit();

                    response.Data = _mapper.Map<MODELLoaiDuAn>(update);
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
                var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_LOAIDUAN>().Find(x => x.Id == request.Id);
                if (delete != null)
                {
                    delete.IsDeleted = true;
                    delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                    delete.NgayXoa = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.DM_LOAIDUAN>().update(delete);
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
                    var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_LOAIDUAN>().Find(x => x.Id == id);
                    if (delete != null)
                    {
                        delete.IsDeleted = true;
                        delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                        delete.NgayXoa = DateTime.Now;

                        _unitOfWork.GetRepository<ENTITIES.DBContent.DM_LOAIDUAN>().update(delete);
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
            var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_LOAIDUAN>().GetAll(x => x.IsActived && !x.IsDeleted).ToList();
            response.Data = data.Select(x => new MODELCombobox
            {
                Text = x.TenGoi,
                Value = x.Id.ToString(),
            }).OrderBy(x => x.Sort).ToList();

            return response;
        }
    }
}
