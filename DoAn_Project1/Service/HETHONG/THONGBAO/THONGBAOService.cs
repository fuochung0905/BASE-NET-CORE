using AutoDependencyRegistration.Attributes;
using AutoMapper;
using ENTITIES.DBContent;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.HETHONG.HETHONGTHONGBAO.Dtos;
using MODELS.HETHONG.HETHONGTHONGBAO.Requests;
using Repository;

namespace REPONSITORY.HETHONG.THONGBAO
{
    [RegisterClassAsTransient]
    public class THONGBAOService : ITHONGBAOService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IHttpContextAccessor _contextAccessor;

        public THONGBAOService(
            IHttpContextAccessor contextAccessor,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        //GET LIST PAGING
        public BaseResponse<GetListPagingResponse> GetList(GetListPagingRequest request)
        {
            BaseResponse<GetListPagingResponse> response = new BaseResponse<GetListPagingResponse>();

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

                var result = _unitOfWork.GetRepository<MODELThongBao>().ExcuteStoredProcedure("sp_ThongBao_GetListPaging", parameters).ToList();
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
        public BaseResponse<MODELThongBao> GetById(GetByIdRequest request)
        {
            var response = new BaseResponse<MODELThongBao>();
            try
            {
                var result = new MODELThongBao();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.HETHONG_THONGBAO>().Find(x => x.Id == request.Id);
                if (data == null)
                    throw new Exception("Không tìm thấy thông báo");
                else
                {
                    result = _mapper.Map<MODELThongBao>(data);
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
        public BaseResponse<PostThongBaoRequest> GetByPost(GetByIdRequest request)
        {
            var response = new BaseResponse<PostThongBaoRequest>();
            try
            {
                var result = new PostThongBaoRequest();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.HETHONG_THONGBAO>().Find(x => x.Id == request.Id);
                if (data == null)
                {
                    result.Id = Guid.NewGuid();
                    result.IsEdit = false;
                }
                else
                {

                    result = _mapper.Map<PostThongBaoRequest>(data);
                    var userId = _unitOfWork.GetRepository<THONGBAO_NGUOIDUNG>().GetAll(x => x.ThongBaoId == data.Id).Select(x => x.TaiKhoanId).ToList();
                    result.UserIds = userId;
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
        public BaseResponse<MODELThongBao> Insert(PostThongBaoRequest request)
        {
            var response = new BaseResponse<MODELThongBao>();
            try
            {
                var add = _mapper.Map<ENTITIES.DBContent.HETHONG_THONGBAO>(request);
                add.NguoiTao = _contextAccessor.HttpContext.User.Identity.Name;
                add.NgayTao = DateTime.Now;
                add.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                add.NgaySua = DateTime.Now;

                _unitOfWork.GetRepository<ENTITIES.DBContent.HETHONG_THONGBAO>().add(add);
                if (request.UserIds.Count > 0) {
                    List<THONGBAO_NGUOIDUNG> utb = new List<THONGBAO_NGUOIDUNG>();
                    foreach (var id in request.UserIds)
                    {
                        var item = new THONGBAO_NGUOIDUNG
                        {
                            Id = Guid.NewGuid(),
                            Delivered_At = DateTime.Now,
                            TaiKhoanId = id,
                            ThongBaoId = add.Id,
                            Is_Read = false
                        };
                        utb.Add(item);
                    }
                    _unitOfWork.GetRepository<THONGBAO_NGUOIDUNG>().addRange(utb);
                    _unitOfWork.Commit();
                    response.Data = _mapper.Map<MODELThongBao>(add);
                    response.Data.UserId = new List<string>();
                    foreach (var item in utb)
                    {
                        var userName = _unitOfWork.GetRepository<ENTITIES.DBContent.TAIKHOAN>().Find(x => x.Id == item.TaiKhoanId);
                        if (userName != null)
                        {
                            response.Data.UserId.Add(userName.UserName);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        //UPDATE
        public BaseResponse<MODELThongBao> Update(PostThongBaoRequest request)
        {
            var response = new BaseResponse<MODELThongBao>();
            try
            {
                var update = _unitOfWork.GetRepository<ENTITIES.DBContent.HETHONG_THONGBAO>().Find(x => x.Id == request.Id && !x.IsDeleted);
                if (update != null)
                {
                    _mapper.Map(request, update);
                    update.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                    update.NgaySua = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.HETHONG_THONGBAO>().update(update);
                    _unitOfWork.Commit();

                    response.Data = _mapper.Map<MODELThongBao>(update);
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

        //DELETE LIST
        public BaseResponse<string> DeleteList(DeleteListRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {
                foreach (var id in request.Ids)
                {
                    var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.HETHONG_THONGBAO>().Find(x => x.Id == id);
                    if (delete != null)
                    {
                        delete.IsDeleted = true;
                        delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                        delete.NgayXoa = DateTime.Now;

                        _unitOfWork.GetRepository<ENTITIES.DBContent.HETHONG_THONGBAO>().update(delete);
                    }
                    else
                    {
                        throw new Exception("Không tìm thấy dữ liệu");
                    }
                }
                _unitOfWork.Commit();
                response.Data = String.Join(",", request);
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
            var data = _unitOfWork.GetRepository<ENTITIES.DBContent.HETHONG_THONGBAO>().GetAll(x => x.IsDeleted == false).ToList();
            response.Data = data.Select(x => new MODELCombobox
            {
                Text = x.TieuDe,
                Value = x.Id.ToString(),
            }).OrderBy(x => x.Text).ToList();

            return response;
        }

        public BaseResponse<int> SoLuongThongBaoNguoiDung()
        {
            var response = new BaseResponse<int>();
            var userName = _contextAccessor.HttpContext.User.Identity.Name;
            SqlParameter iTotalRow = new SqlParameter()
            {
                ParameterName = "@oCountRow",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
            var parameters = new[]
            {
                new SqlParameter("@iUserName", userName),
                iTotalRow
            };
            _unitOfWork.GetRepository<object>().ExcuteStoredProcedure("sp_SoLuongThongBaoChuaXem", parameters);
            response.Data = Convert.ToInt32(iTotalRow.Value);
            return response;

        }
    }
}
