using AutoDependencyRegistration.Attributes;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.DANHMUC.GIAIDOANDUAN.Dtos;
using MODELS.DANHMUC.GIAIDOANDUAN.Requests;
using Repository;


namespace REPONSITORY.DANHMUC.GIAIDOANDUAN;

[RegisterClassAsTransient]
public class GIAIDOANDUANService : IGIAIDOANDUANService
{
	private IUnitOfWork _unitOfWork;
	private IMapper _mapper;
	private IHttpContextAccessor _contextAccessor;

	public GIAIDOANDUANService(
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
			SqlParameter iTotalRow = new()
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

			var result = _unitOfWork.GetRepository<MODELGiaiDoanDuAn>().ExcuteStoredProcedure("sp_DM_GIAIDOANDUAN_GetListPaging", parameters).ToList();
			GetListPagingResponse responseData = new()
			{
				PageIndex = request.PageIndex,
				Data = result,
				TotalRow = Convert.ToInt32(iTotalRow.Value)
			};
			response.Data = responseData;

		}
		catch(Exception ex)
		{
			response.Error = true;
			response.Message = ex.Message;
		}

		return response;
	}

	//GET BY ID
	public BaseResponse<MODELGiaiDoanDuAn> GetById(GetByIdRequest request)
	{
		var response = new BaseResponse<MODELGiaiDoanDuAn>();
		try
		{
			var result = new MODELGiaiDoanDuAn();
			var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_GIAIDOANDUAN>()
                .Find(x => x.Id == request.Id && !x.IsDeleted);
			if(data == null)
				throw new Exception("Không tìm thấy thông tin");
			else
			{
				result = _mapper.Map<MODELGiaiDoanDuAn>(data);
			}
			response.Data = result;
		}
		catch(Exception ex)
		{
			response.Error = true;
			response.Message = ex.Message;
		}

		return response;
	}

	//GET BY POST (INSERT/UPDATE)
	public BaseResponse<PostGiaiDoanDuAnRequest> GetByPost(GetByIdRequest request)
	{
		var response = new BaseResponse<PostGiaiDoanDuAnRequest>();
		try
		{
			var result = new PostGiaiDoanDuAnRequest();
			var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_GIAIDOANDUAN>().Find(x => x.Id == request.Id);
			if(data == null)
			{
				result.Id = Guid.NewGuid();
				result.IsEdit = false;
			}
			else
			{
				result = _mapper.Map<PostGiaiDoanDuAnRequest>(data);
				result.IsEdit = true;
			}
			response.Data = result;
		}
		catch(Exception ex)
		{
			response.Error = true;
			response.Message = ex.Message;
		}

		return response;
	}

	//INSERT
	public BaseResponse<MODELGiaiDoanDuAn> Insert(PostGiaiDoanDuAnRequest request)
	{
		var response = new BaseResponse<MODELGiaiDoanDuAn>();
		try
		{
			var isExist = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_GIAIDOANDUAN>()
                .Find(x => x.Ma == request.Ma || x.TenGoi == request.TenGoi);
            if (isExist != null)
            {
                throw new Exception("Dữ liệu đã tồn tại");
            }
            var add = _mapper.Map<ENTITIES.DBContent.DM_GIAIDOANDUAN>(request);
			add.NguoiTao = _contextAccessor.HttpContext.User.Identity.Name;
			add.NgayTao = DateTime.Now;
			add.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
			add.NgaySua = DateTime.Now;
			_unitOfWork.GetRepository<ENTITIES.DBContent.DM_GIAIDOANDUAN>().add(add);
			_unitOfWork.Commit();

			response.Data = _mapper.Map<MODELGiaiDoanDuAn>(add);
		}
		catch(Exception ex)
		{
			response.Error = true;
			response.Message = ex.Message;
		}

		return response;
	}

	//UPDATE
	public BaseResponse<MODELGiaiDoanDuAn> Update(PostGiaiDoanDuAnRequest request)
	{
		var response = new BaseResponse<MODELGiaiDoanDuAn>();
		try
		{
            var isExist = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_GIAIDOANDUAN>()
                .Find(x => x.Id != request.Id && (x.Ma == request.Ma || x.TenGoi == request.TenGoi));
            if(isExist != null)
            {
                throw new Exception("Dữ liệu đã tồn tại");
            }
            var update = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_GIAIDOANDUAN>().Find(x => x.Id == request.Id);
			if(update != null)
			{
				_mapper.Map(request, update);
				update.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
				update.NgaySua = DateTime.Now;

				_unitOfWork.GetRepository<ENTITIES.DBContent.DM_GIAIDOANDUAN>().update(update);
				_unitOfWork.Commit();

				response.Data = _mapper.Map<MODELGiaiDoanDuAn>(update);
			}
			else
			{
				throw new Exception("Không tìm thấy dữ liệu");
			}
		}
		catch(Exception ex)
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
			var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_GIAIDOANDUAN>().Find(x => x.Id == request.Id);
			if(delete != null)
			{
				delete.IsDeleted = true;
				delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
				delete.NgayXoa = DateTime.Now;

				_unitOfWork.GetRepository<ENTITIES.DBContent.DM_GIAIDOANDUAN>().update(delete);
			}
			else
			{
				throw new Exception("Không tìm thấy dữ liệu");
			}
			_unitOfWork.Commit();
			response.Data = request.Id.ToString();
		}
		catch(Exception ex)
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
			foreach(var id in request.Ids)
			{
				var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_GIAIDOANDUAN>().Find(x => x.Id == id);
				if(delete != null)
				{
					delete.IsDeleted = true;
					delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
					delete.NgayXoa = DateTime.Now;

					_unitOfWork.GetRepository<ENTITIES.DBContent.DM_GIAIDOANDUAN>().update(delete);
				}
				else
				{
					throw new Exception("Không tìm thấy dữ liệu");
				}
			}
			_unitOfWork.Commit();
			response.Data = string.Join(',', request);
		}
		catch(Exception ex)
		{
			response.Error = true;
			response.Message = ex.Message;
		}

		return response;
	}

	//GET ALL FOR COMBOBOX
	public BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request)
	{
		BaseResponse<List<MODELCombobox>> response = new();
		var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DM_GIAIDOANDUAN>().GetAll(x => x.IsActived && !x.IsDeleted).ToList();
		response.Data = data.OrderBy(x => x.NgayTao)
            .Select(x => new MODELCombobox
		    {
			    Text = x.TenGoi,
			    Value = x.Id.ToString(),
		    })
            .ToList();

		return response;
	}
}