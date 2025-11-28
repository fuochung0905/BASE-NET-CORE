using AutoDependencyRegistration.Attributes;
using AutoMapper;
using ENTITIES.DBContent;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.DUAN.QUANLYCONGVIEC.Dtos;
using MODELS.DUAN.TRANGTHAICONGVIEC.Dtos;
using MODELS.DUAN.TRANGTHAICONGVIEC.Request;
using Repository;
using System.Text.Json;

namespace REPONSITORY.DUAN.TRANGTHAICONGVIEC
{
    [RegisterClassAsTransient]
    public class TRANGTHAICONGVIECService : ITRANGTHAICONGVIECService
    {
        private IUnitOfWork _unitOfWork;
        private IHttpContextAccessor _contextAccessor;
        private IMapper _mapper;
        private IWebHostEnvironment _webHostEnvironment;

        public TRANGTHAICONGVIECService(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;

        }

        public BaseResponse<GetListPagingResponse> GetListCongViec(PostTrangThaiCongViecGetListPagingRequest request)
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
                    new SqlParameter("@iDuAnId",
                        request.DuAnId.HasValue ? request.DuAnId : DBNull.Value),
                    new SqlParameter("@iGiaiDoanId",
                        request.GiaiDoanId.HasValue ? request.GiaiDoanId : DBNull.Value),
                    new SqlParameter("@iTrangThaiId", request.TrangThaiId),
                    new SqlParameter("@iCongViecTrongGiaiDoanId",
                        request.CongViecTrongGiaiDoanId.HasValue ? request.CongViecTrongGiaiDoanId : DBNull.Value),
                    new SqlParameter("@iCurrentUser",_contextAccessor.HttpContext.User.Identity.Name),
                    new SqlParameter("@iNguoiThucHienId",
                        request.NguoiThucHienId.HasValue ? request.NguoiThucHienId : DBNull.Value),
                    new SqlParameter("@iNguoiKiemTraId",
                        request.NguoiKiemTraId.HasValue ? request.NguoiKiemTraId : DBNull.Value),
                    new SqlParameter("@iAssignTo",
                        request.AssignTo.HasValue ? request.AssignTo : DBNull.Value),
                    new SqlParameter("@iTextSearch", request.TextSearch),
                    new SqlParameter("@iTuNgay",
                        request.TuNgay.HasValue ? request.TuNgay : DBNull.Value),
                    new SqlParameter("@iDenNgay",
                    request.DenNgay.HasValue ? request.DenNgay : DBNull.Value),
                    new SqlParameter("@iPageIndex", request.PageIndex),
                    new SqlParameter("@iRowsPerPage", request.RowPerPage),
                    iTotalRow
                };
                var result = _unitOfWork.GetRepository<MODELCongViec>().ExcuteStoredProcedure("sp_QUANLYCONGVIECBYTRANGTHAICONGVIEC", parameters).ToList();
                var responseData = new GetListPagingResponse
                {
                    PageIndex = request.PageIndex,
                    Data = result,
                    TotalRow = Convert.ToInt32(iTotalRow.Value) 
                };
                response.Data = responseData;
            }
            catch (Exception e)
            {
                response.Error = true;
                response.Message = e.Message;
            }
            return response;
        }

        public BaseResponse<List<MODELTrangThaiCongViec>> GetListTrangThaiCongViec()
        {
            var response = new BaseResponse<List<MODELTrangThaiCongViec>>();
            try
            {
                var userName = _contextAccessor.HttpContext.User.Identity.Name;
                var parameter = new[]
                {
                    new SqlParameter("@iTenNguoiDung", userName)
                };
                var result = _unitOfWork.GetRepository<MODELTrangThaiCongViec>().ExcuteStoredProcedure("sp_TRANGTHAICONGVIECBYUSERNAME", parameter).ToList();

                response.Data = result;
            }
            catch (Exception e)
            {
                response.Error = true;
                response.Message = e.Message;
            }
            return response;
        }

        public BaseResponse<MODELCongViec> UpdateTrangThaiCongViec(PostTrangThaiCongViecRequest request)
        {
            var response = new BaseResponse<MODELCongViec>();
            try
            {
                var isExists = _unitOfWork.GetRepository<DUAN_QUANLYCONGVIEC>().Find(x => x.Id == request.Id);
                if (isExists == null)
                {
                    throw new Exception("Không tồn tại dữ liệu");
                }
                else
                {
                    var userName = _contextAccessor.HttpContext.User.Identity.Name;
                    SqlParameter checkUpdate = new SqlParameter()
                    {
                        ParameterName = "@oCheckUpdate",
                        SqlDbType = System.Data.SqlDbType.Bit,
                        Direction = System.Data.ParameterDirection.Output
                    };
                    var parameters = new[]
                    {
                        new SqlParameter("@congViecId", request.Id),
                        new SqlParameter("@TrangThaiId", request.TrangThaiId),
                        new SqlParameter("@iUserName", userName),
                        checkUpdate
                    };
                    _unitOfWork.GetRepository<object>().ExcuteStoredProcedure("sp_CHECKUPDATETRANGTHAIDUYET", parameters);
                    bool checkKq = bool.Parse(checkUpdate.Value.ToString());
                    if (checkKq == false)
                    {
                        throw new Exception("Không thể cập nhật trạng thái công việc");
                    }

                    if (request.TrangThaiId.Value == 2)
                    {
                        if (!isExists.NguoiThucHienId.HasValue || isExists.NguoiThucHienId.Value == Guid.Empty)
                        {
                            return new BaseResponse<MODELCongViec>()
                            {
                                Error = true,
                                Message = "Chưa có người thực hiện"
                            };
                                                    }
                        isExists.AssignTo = isExists.NguoiThucHienId;
                    }
                    if (request.TrangThaiId.Value == 3)
                    {
                        if (!isExists.NguoiThucHienId.HasValue || isExists.NguoiThucHienId.Value == Guid.Empty)
                        {
                            return new BaseResponse<MODELCongViec>()
                            {
                                Error = true,
                                Message = "Chưa có người thực hiện"
                            };
                        }
                        isExists.AssignTo = isExists.NguoiThucHienId;
                    }
                    if (request.TrangThaiId.Value == 4)
                    {
                        if (!isExists.NguoiKiemTraId.HasValue || isExists.NguoiKiemTraId.Value == Guid.Empty)
                        {
                            return new BaseResponse<MODELCongViec>()
                            {
                                Error = true,
                                Message = "Chưa có người kiểm tra"
                            };
                            
                        }
                        isExists.AssignTo = isExists.NguoiKiemTraId;
                    }

                    if (request.TrangThaiId.Value == 5)
                    {
                        isExists.AssignTo = isExists.NguoiThucHienId;
                    }

                    if (request.TrangThaiId.Value == 3)
                    {
                        isExists.AssignTo = isExists.NguoiThucHienId;
                    }
                    if (request.TrangThaiId.Value == 6)
                    {
                        isExists.AssignTo = isExists.NguoiThucHienId;
                    }
                    isExists.TrangThaiId = request.TrangThaiId.Value;
                    isExists.NgaySua = DateTime.Now;
                    isExists.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                    _unitOfWork.GetRepository<DUAN_QUANLYCONGVIEC>().update(isExists);

                    _unitOfWork.Commit();

                    response.Data = _mapper.Map<MODELCongViec>(isExists);
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }
            return response;
        }
        public BaseResponse<MODELCongViec> UpdateCongViecByTrangThai(PostCongViecByTrangThaiRequest request)
        {
            var response = new BaseResponse<MODELCongViec>();
            try
            {

                var update = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC>().Find(x => x.Id == request.Id);

                if (update is not null)
                {
                    _mapper.Map(request, update);
                    update.TienDo /= 100;
                    _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC>().update(update);
                    response.Data = _mapper.Map<MODELCongViec>(update);
                    _unitOfWork.Commit();
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
        public BaseResponse<MODELCheckPhanQuyen> CheckRoleUser()
        {
            var response = new BaseResponse<MODELCheckPhanQuyen>();
            try
            {
                var username = _contextAccessor.HttpContext.User.Identity.Name;
                var data = new MODELCheckPhanQuyen();
                SqlParameter checkAdmin = new SqlParameter
                {
                    ParameterName = "@oCheckAdmin",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Direction = System.Data.ParameterDirection.Output
                };
                var parameters = new[]
                {
                    new SqlParameter("@iUsername", username),
                    checkAdmin
                };
                _unitOfWork.GetRepository<object>().ExcuteStoredProcedure("sp_CHECKROLEUPDATE", parameters);
                bool check = bool.Parse(checkAdmin.Value.ToString());
                if (check == false)
                {
                    data.IsQuanTri = false;
                }
                else
                {
                    data.IsQuanTri = true;
                }
                response.Data = data;
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public BaseResponse<MODELQuanLyCongViec> GetById(GetByIdRequest request)
        {
            var response = new BaseResponse<MODELQuanLyCongViec>();
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@iCongViecId", request.Id)
                };

                var isExists = _unitOfWork.GetRepository<MODELQuanLyCongViec>()
                    .ExcuteStoredProcedure("sp_DUANCONGVIECBYTRANGTHAI_GETLIST", parameters);
                var data = new MODELQuanLyCongViec();
                foreach (var item in isExists)
                {
                    data = item;
                }
                if (isExists == null)
                {
                    throw new Exception("Không tìm thấy thông tin");
                }
                else
                {
                    data.ListTepDinhKemGetBy = GetListTepDinhKem(data.Id);
                    data.ListTepDinhKem = GetListTepDinhKemNoBai(data.Id);
                    response.Data = data;
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }
        private List<MODELTepDinhKem> GetListTepDinhKem(Guid Id)
        {
            var result = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_TEPDINHKEM>().GetAll(x => x.LienKetId == Id).ToList();
            var mappedResult = _mapper.Map<List<MODELTepDinhKem>>(result);
            mappedResult.ForEach(x =>
            {
                x.TenTapTinFull = x.TenFile + x.TenMoRong;
            });
            return mappedResult;
        }

        private List<MODELTepDinhKem> GetListTepDinhKemNoBai(Guid Id)
        {
            var result = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_KETQUACONGVIEC_TEPDINHKEM>().GetAll(x => x.LienKetId == Id).ToList();
            var mappedResult = new List<MODELTepDinhKem>();
            foreach(var item in result)
            {
                var temp = new MODELTepDinhKem();
                temp.Id = item.Id;
                temp.LienKetId = item.LienKetId;
                temp.TenFile = item.TenFile;
                temp.Url = item.Url;
                temp.DoLon = item.DoLon;
                temp.TenMoRong = item.TenMoRong;
                mappedResult.Add(temp);
            }    
            mappedResult.ForEach(x =>
            {
                x.TenTapTinFull = x.TenFile + x.TenMoRong;
            });
            return mappedResult;
        }

        public BaseResponse<MODELQuanLyCongViec> UpdateNopBai(MODELQuanLyCongViec request)
        {
            var response = new BaseResponse<MODELQuanLyCongViec>();
            try
            {
                #region Thêm tài liệu đính kèm
                if (request.IsTepDinhKem == true)
                {
                    var dinhKemIds = JsonSerializer.Deserialize<List<Guid>>(request.TepDinhKemIDs);

                    List<MODELTepDinhKem> lstAttachment = [];
                    lstAttachment = MODELS.COMMON.CommonFunc.UploadData(request.Id, _webHostEnvironment.WebRootPath, "QUANLY", request.FolderUpload);
                    foreach (var attachment in lstAttachment)
                    {
                        var tepDinhKem = new ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_KETQUACONGVIEC_TEPDINHKEM
                        {
                            Id = attachment.Id,
                            LienKetId = request.Id,
                            TenFile = attachment.TenFile,
                            TenMoRong = attachment.TenMoRong,
                            DoLon = attachment.DoLon.Value,
                            Url = attachment.Url
                        };
                        _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_KETQUACONGVIEC_TEPDINHKEM>().add(tepDinhKem);
                    }
                    _unitOfWork.Commit();
                }

                #endregion
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
