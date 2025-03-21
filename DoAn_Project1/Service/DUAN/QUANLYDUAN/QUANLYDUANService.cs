using AutoDependencyRegistration.Attributes;
using AutoMapper;
using ENTITIES.DBContent;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.DUAN.QUANLYDUAN.Dtos;
using MODELS.DUAN.QUANLYDUAN.Requests;
using Repository;

namespace REPONSITORY.DUAN.QUANLYDUAN;

[RegisterClassAsTransient]
public class QUANLYDUANService : IQUANLYDUANService
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    private IHttpContextAccessor _contextAccessor;

    public QUANLYDUANService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _contextAccessor = contextAccessor;
    }

    //GET LIST
    public BaseResponse<GetListPagingResponse> GetList(GetListQuanLyDuAnRequest request)
        {
        var response = new BaseResponse<GetListPagingResponse>();
        try
        {
            SqlParameter iTotalRow = new()
            {
                ParameterName = "@oTotalRow",
                SqlDbType = System.Data.SqlDbType.BigInt,
                Direction = System.Data.ParameterDirection.Output
            };

            var parameters = new[]
            {
                new SqlParameter("@iLoaiDuAn", request.LoaiDuAn.HasValue ? request.LoaiDuAn : DBNull.Value),
                new SqlParameter("@iGiaiDoanId", request.GiaiDoanId.HasValue ? request.GiaiDoanId : DBNull.Value),
                new SqlParameter("@iTuNgay", request.TuNgay.HasValue ? request.TuNgay : DBNull.Value),
                new SqlParameter("@iDenNgay", request.DenNgay.HasValue ? request.DenNgay : DBNull.Value),
                new SqlParameter("@iTextSearch", request.TextSearch),
                new SqlParameter("@iPageIndex", request.PageIndex),
                new SqlParameter("@iRowsPerPage", request.RowPerPage),
                iTotalRow
            };

            var result = _unitOfWork.GetRepository<MODELQuanLyDuAn>().ExcuteStoredProcedure("sp_DUAN_QUANLYDUAN_GetListPaging", parameters).ToList();

            var responseData = new GetListPagingResponse
            {
                PageIndex = request.PageIndex,
                Data = result,
                TotalRow = Convert.ToInt32(iTotalRow.Value)
            };
            response.Data = responseData;

        }
        catch (Exception ex)
        {
            response.Error = true;
            response.Message = ex.Message;
        }

        return response;
    }

    //GET BY ID
    public BaseResponse<MODELQuanLyDuAn> GetById(GetByIdRequest request)
    {
        var response = new BaseResponse<MODELQuanLyDuAn>();
        try
        {
            var result = new MODELQuanLyDuAn();
            var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYDUAN>()
                .Find(x => x.Id == request.Id && !x.IsDeleted);
            if (data is null)
            {
                throw new Exception("Không tìm thấy thông tin");
            }
            else
            {
                result = _mapper.Map<MODELQuanLyDuAn>(data);
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
    public BaseResponse<PostQuanLyDuAnRequest> GetByPost(GetByIdRequest request)
    {
        var response = new BaseResponse<PostQuanLyDuAnRequest>();
        try
        {
            var result = new PostQuanLyDuAnRequest();
            var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYDUAN>().Find(x => x.Id == request.Id);
            if (data is null)
            {
                result.Id = Guid.NewGuid();
                result.IsEdit = false;
            }
            else
            {
                result = _mapper.Map<PostQuanLyDuAnRequest>(data);
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
    public BaseResponse<MODELQuanLyDuAn> Insert(PostQuanLyDuAnRequest request)
    {
        var response = new BaseResponse<MODELQuanLyDuAn>();
        try
        {
            var isExist = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYDUAN>()
                .Find(x => x.MaDuAn == request.MaDuAn);
            if (isExist is not null)
            {
                throw new Exception("Dữ liệu đã tồn tại");
            }
            var add = _mapper.Map<ENTITIES.DBContent.DUAN_QUANLYDUAN>(request);
            add.NguoiTao = _contextAccessor.HttpContext.User.Identity.Name;
            add.NgayTao = DateTime.Now;
            add.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
            add.NgaySua = DateTime.Now;
            if(request.IsCanhBaoHetHan!=true)
            {
                add.IsCanhBaoHetHan = false;
            }    
            _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYDUAN>().add(add);
         
            


            _unitOfWork.Commit();
            response.Data = _mapper.Map<MODELQuanLyDuAn>(add);
        }
        catch (Exception ex)
        {
            response.Error = true;
            response.Message = ex.Message;
        }

        return response;
    }

    //UPDATE
    public BaseResponse<MODELQuanLyDuAn> Update(PostQuanLyDuAnRequest request)
    {
        var response = new BaseResponse<MODELQuanLyDuAn>();
        try
        {
            var isExist = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYDUAN>()
                .Find(x => x.Id != request.Id && x.MaDuAn == request.MaDuAn);
            if (isExist is not null)
            {
                throw new Exception("Dữ liệu đã tồn tại");
            }
            var update = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYDUAN>().Find(x => x.Id == request.Id);
            if (update is not null)
            {
                _mapper.Map(request, update);
                update.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                update.NgaySua = DateTime.Now;

                _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYDUAN>().update(update);
                _unitOfWork.Commit();

                response.Data = _mapper.Map<MODELQuanLyDuAn>(update);
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
            var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYDUAN>().Find(x => x.Id == request.Id);
            if (delete is not null)
            {
                delete.IsDeleted = true;
                delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                delete.NgayXoa = DateTime.Now;

                _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYDUAN>().update(delete);
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
                var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYDUAN>().Find(x => x.Id == id);
                if (delete is not null)
                {
                    delete.IsDeleted = true;
                    delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                    delete.NgayXoa = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYDUAN>().update(delete);
                }
                else
                {
                    throw new Exception("Không tìm thấy dữ liệu");
                }
            }
            _unitOfWork.Commit();
            response.Data = string.Join(',', request);
        }
        catch (Exception ex)
        {
            response.Error = true;
            response.Message = ex.Message;
        }

        return response;
    }

    public BaseResponse<List<MODELCombobox>> GetAllComboBox(GetAllRequest request)
    {
        var response = new BaseResponse<List<MODELCombobox>>();
        var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYDUAN>()
            .GetAll(x => !x.IsDeleted && x.IsActived)
            .Select(x => new { x.Id, x.MaDuAn, x.TenDuAn })
            .ToList();
        response.Data = data.Select(x => new MODELCombobox
        {
            Text = x.MaDuAn + " - " + x.TenDuAn,
            Value = x.Id.ToString(),
        }).OrderBy(x => x.Text).ToList();

        return response;
    }

}
