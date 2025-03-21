using System.Text.Json;
using AutoDependencyRegistration.Attributes;
using AutoMapper;
using ENTITIES.DBContent;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using MODELS;
using MODELS.BASE;
using MODELS.DUAN.QUANLYCONGVIEC.Dtos;
using MODELS.DUAN.QUANLYCONGVIEC.Requests;
using MODELS.DUAN.QUANLICONGVIEC_CHITIET.Requests;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;
using Repository;
using Model.BASE;
using Microsoft.IdentityModel.Tokens;


namespace REPONSITORY.DUAN.QUANLYCONGVIEC;

[RegisterClassAsTransient]
public class QUANLYCONGVIECService : IQUANLYCONGVIECService
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    private IHttpContextAccessor _contextAccessor;
    private IWebHostEnvironment _webHostEnvironment;

    public QUANLYCONGVIECService(
        IHttpContextAccessor contextAccessor,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _webHostEnvironment = webHostEnvironment;
        _contextAccessor = contextAccessor;
    }

    //GET LIST
    public BaseResponse<GetListPagingResponse> GetList(GetListQuanLyCongViecRequest request)
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
                new SqlParameter("@iTuNgay",
                    request.TuNgay.HasValue ? request.TuNgay : DBNull.Value),
                new SqlParameter("@iDenNgay",
                    request.DenNgay.HasValue ? request.DenNgay : DBNull.Value),
                new SqlParameter("@iCongViecTrongGiaiDoanId",
                    request.CongViecTrongGiaiDoanId.HasValue ? request.CongViecTrongGiaiDoanId : DBNull.Value),
                new SqlParameter("@iNguoiThucHienId",
                    request.NguoiThucHienId.HasValue ? request.NguoiThucHienId : DBNull.Value),
                new SqlParameter("@iNguoiKiemTraId",
                    request.NguoiKiemTraId.HasValue ? request.NguoiKiemTraId : DBNull.Value),
                new SqlParameter("@iAssignTo",
                    request.AssignTo.HasValue ? request.AssignTo : DBNull.Value),
                new SqlParameter("@iTextSearch", request.TextSearch),
                new SqlParameter("@iPageIndex", request.PageIndex),
                new SqlParameter("@iRowsPerPage", request.RowPerPage),
                iTotalRow
            };

            var result = _unitOfWork.GetRepository<MODELQuanLyCongViec>()
                .ExcuteStoredProcedure("sp_DUAN_QUANLYCONGVIEC_GetListPaging", parameters)
                .ToList();
    
            var responseData = new GetListPagingResponse
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
    public BaseResponse<MODELQuanLyCongViec> GetById(GetByIdRequest request)
    {
        var response = new BaseResponse<MODELQuanLyCongViec>();
        try
        {
            var result = new MODELQuanLyCongViec();
            var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC>()
                .Find(x => x.Id == request.Id && !x.IsDeleted);
            if(data is null)
            {
                throw new Exception("Không tìm thấy thông tin");
            }
            else
            {
                result = _mapper.Map<MODELQuanLyCongViec>(data);
                result.TienDo *= 100;
                result.ListTepDinhKem = GetListTepDinhKem(result.Id);
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
    public BaseResponse<PostQuanLyCongViecRequest> GetByPost(GetByIdRequest request)
    {
        var response = new BaseResponse<PostQuanLyCongViecRequest>();
        try
        {
            var result = new PostQuanLyCongViecRequest();
            var data = _unitOfWork
                .GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC>()
                .Find(x => x.Id == request.Id);

            if (data is null)
            {
                result.Id = Guid.NewGuid();
                result.IsEdit = false;
            }
            else
            {
                result = _mapper.Map<PostQuanLyCongViecRequest>(data);
                result.IsEdit = true;
                result.TienDo *= 100;
                result.ListTepDinhKem = GetListTepDinhKem(result.Id);
                //result.ListSubTask = GetListSubTask(data.Id);
                result.listCongViecChiTiet = GetListCongViecChiTiet(data.Id);
                //result.listCongViecLoi = GetListChiTietCongViecLoi(data.Id);
                //if (result.ListSubTask?.Any() == true)
                //{
                  if (result.listCongViecChiTiet?.Any() == true)
                    {
                        //var assignToIds = result.ListSubTask
                        //.Where(x => x.AssignToId.HasValue)
                        //.Select(x => x.AssignToId.Value)
                        //.Distinct()
                        //.ToList();

                    //var trangThaiIds = result.ListSubTask
                    //    .Where(x => x.TrangThaiId.HasValue)
                    //    .Select(x => x.TrangThaiId.Value)
                    //    .Distinct()
                    //    .ToList();
                    var trangThaiIds = result.listCongViecChiTiet
                      .Where(x => x.TrangThaiId.HasValue)
                      .Select(x => x.TrangThaiId.Value)
                      .Distinct()
                      .ToList();
                    //var assignToUsers = _unitOfWork
                    //    .GetRepository<ENTITIES.DBContent.TAIKHOAN>()
                    //    .GetAll(x => assignToIds.Contains(x.Id))
                    //    .ToDictionary(x => x.Id, x => x.UserName);

                    var trangThaiCongViec = _unitOfWork
                        .GetRepository<ENTITIES.DBContent.SYS_TRANGTHAICONGVIEC>()
                        .GetAll(x => trangThaiIds.Contains(x.Id))
                        .ToDictionary(x => x.Id, x => x.TenGoi);
                    //foreach (var item in result.ListSubTask)
                    //{
                    //    if (item.AssignToId.HasValue && assignToUsers.TryGetValue(item.AssignToId.Value, out var userName))
                    //    {
                    //        item.ClientAssignTo.Text = userName;
                    //        item.ClientAssignTo.Value = item.AssignToId.ToString();
                    //    }
                    //    else
                    //    {
                    //        item.ClientAssignTo.Text = null;
                    //        item.ClientAssignTo.Value = null;
                    //    }
                    //    if (item.TrangThaiId.HasValue && trangThaiCongViec.TryGetValue(item.TrangThaiId.Value, out var trangThai))
                    //    {
                    //        item.ClientTrangThaiCongViec.Text = trangThai;
                    //        item.ClientTrangThaiCongViec.Value = item.TrangThaiId.ToString();
                    //    }
                    //    else
                    //    {
                    //        item.ClientTrangThaiCongViec.Text = null;
                    //        item.ClientTrangThaiCongViec.Value = null;
                    //    }
                    //}
                    foreach (var item in result.listCongViecChiTiet)
                    {
                        //if (item.AssignToId.HasValue && assignToUsers.TryGetValue(item.AssignToId.Value, out var userName))
                        //{
                        //    item.ClientAssignTo.Text = userName;
                        //    item.ClientAssignTo.Value = item.AssignToId.ToString();
                        //}
                        //else
                        //{
                        //    item.ClientAssignTo.Text = null;
                        //    item.ClientAssignTo.Value = null;
                        //}
                        if (item.TrangThaiId.HasValue && trangThaiCongViec.TryGetValue(item.TrangThaiId.Value, out var trangThai))
                        {
                            item.ClientTrangThaiCongViec.Text = trangThai;
                            item.ClientTrangThaiCongViec.Value = item.TrangThaiId.ToString();
                        }
                        else
                        {
                            item.ClientTrangThaiCongViec.Text = null;
                            item.ClientTrangThaiCongViec.Value = null;
                        }
                    }
                }
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
    public BaseResponse<MODELQuanLyCongViec> Insert(PostQuanLyCongViecRequest request)
	{
		var response = new BaseResponse<MODELQuanLyCongViec>();
		try
		{
			var isExist = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC>()
				.Find(x => x.TenCongViec == request.TenCongViec && x.DuAnId == request.DuAnId);
			if(isExist is not null)
			{
				throw new Exception("Dữ liệu đã tồn tại");
			}
			var add = _mapper.Map<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC>(request);
            add.TienDo /= 100;
         
            if (add.NguoiThucHienId is not null && add.NguoiThucHienId != Guid.Empty && add.AssignTo is null)
            {
                add.TrangThaiId = add.TrangThaiId == 1 ? 2 : add.TrangThaiId;
                add.AssignTo = request.NguoiThucHienId;
            }
            if (add.AssignTo != null && add.NguoiThucHienId == null )
            {
                add.TrangThaiId = add.TrangThaiId == 1 ? 2 : add.TrangThaiId;
                if (add.TrangThaiId == 1)
                {
                    add.TrangThaiId = 2;
                }             
                add.NguoiThucHienId = add.AssignTo;
            }
            if (add.AssignTo != null)
            {
                add.TrangThaiId = 2;
            }
            add.NguoiTao = _contextAccessor.HttpContext.User.Identity.Name;
			add.NgayTao = DateTime.Now;
			add.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
			add.NgaySua = DateTime.Now;
			_unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC>().add(add);

            #region Thêm tài liệu đính kèm
            if(request.IsTepDinhKem == true)
            {
                var dinhKemIds = JsonSerializer.Deserialize<List<Guid>>(request.TepDinhKemIDs);

                List<MODELTepDinhKem> lstAttachment = [];
                lstAttachment = MODELS.COMMON.CommonFunc.UploadData(add.Id, _webHostEnvironment.WebRootPath, "QUANLYCONGVIEC", request.FolderUpload);
                foreach (var attachment in lstAttachment)
                {
                    var tepDinhKem = new ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_TEPDINHKEM
                    {
                        Id = attachment.Id,
                        LienKetId = add.Id,
                        TenFile = attachment.TenFile,
                        TenMoRong = attachment.TenMoRong,
                        DoLon = attachment.DoLon.Value,
                        Url = attachment.Url
                    };
                    _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_TEPDINHKEM>().add(tepDinhKem);
                }
            }
            
            #endregion
            var thongBao = new ENTITIES.DBContent.HETHONG_THONGBAO();
            thongBao.Id = Guid.NewGuid();
            thongBao.TieuDe = "Có một công việc mới cần thực hiện";
            thongBao.NoiDung = request.GhiChu;
            thongBao.NguoiTao = _contextAccessor.HttpContext.User.Identity.Name;
            thongBao.NgayTao = DateTime.Now;
            thongBao.Type = 1;
            _unitOfWork.GetRepository<HETHONG_THONGBAO>().add(thongBao);
            HashSet<string> listAssignName = new HashSet<string>();
            if (request.AssignTo != null)
            {
                var assignTo = _unitOfWork.GetRepository<TAIKHOAN>().Find(x => x.Id == request.AssignTo);
                var thongBao_NguoiDung = new ENTITIES.DBContent.THONGBAO_NGUOIDUNG();
                thongBao_NguoiDung.Id = Guid.NewGuid();
                thongBao_NguoiDung.TaiKhoanId = assignTo.Id;
                thongBao_NguoiDung.ThongBaoId = thongBao.Id;
                thongBao_NguoiDung.Delivered_At = DateTime.Now;
                _unitOfWork.GetRepository<THONGBAO_NGUOIDUNG>().add(thongBao_NguoiDung);
                listAssignName.Add(assignTo.UserName);
            }
            if(request.NguoiThucHienId != null && request.AssignTo != request.NguoiThucHienId)
            {
                var nguoiThucHien = _unitOfWork.GetRepository<TAIKHOAN>().Find(x => x.Id == add.NguoiThucHienId);
                var thongBao_NguoiDung = new ENTITIES.DBContent.THONGBAO_NGUOIDUNG();
                thongBao_NguoiDung.Id = Guid.NewGuid();
                thongBao_NguoiDung.TaiKhoanId = nguoiThucHien.Id;
                thongBao_NguoiDung.ThongBaoId = thongBao.Id;
                thongBao_NguoiDung.Delivered_At = DateTime.Now;
                _unitOfWork.GetRepository<THONGBAO_NGUOIDUNG>().add(thongBao_NguoiDung);
                listAssignName.Add(nguoiThucHien.UserName);
            }
            if (request.NguoiKiemTraId != null && request.NguoiKiemTraId != request.AssignTo)
            {
                var nguoiKiemThu = _unitOfWork.GetRepository<TAIKHOAN>().Find(x => x.Id == request.NguoiKiemTraId);
                var thongBao_NguoiDung = new ENTITIES.DBContent.THONGBAO_NGUOIDUNG();
                thongBao_NguoiDung.Id = Guid.NewGuid();
                thongBao_NguoiDung.TaiKhoanId = nguoiKiemThu.Id;
                thongBao_NguoiDung.ThongBaoId = thongBao.Id;
                thongBao_NguoiDung.Delivered_At = DateTime.Now;
                thongBao_NguoiDung.Is_Read = false;
                _unitOfWork.GetRepository<THONGBAO_NGUOIDUNG>().add(thongBao_NguoiDung);
                listAssignName.Add(nguoiKiemThu.UserName);
            }
            _unitOfWork.Commit();
            response.Data = _mapper.Map<MODELQuanLyCongViec>(add);
            response.Data.listAssignName = listAssignName;
        }
        catch(Exception ex)
        {
            response.Error = true;
            response.Message = ex.Message;
        }
        return response;
    }

	//UPDATE
	public BaseResponse<MODELQuanLyCongViec> Update(PostQuanLyCongViecRequest request)
	{
		var response = new BaseResponse<MODELQuanLyCongViec>();
		try
		{
			var isExist = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC>()
				.Find(x => x.TenCongViec.Trim() == request.TenCongViec.Trim() && x.DuAnId == request.DuAnId && x.Id != request.Id & !x.IsDeleted);
			if(isExist is not null)
			{
				throw new Exception("Dữ liệu đã tồn tại");
			}
			var update = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC>().Find(x => x.Id == request.Id);

            if(update is not null)
            {              
                var nguoiThucHien = update.NguoiThucHienId;
                var nguoiKiemTra = update.NguoiKiemTraId;
                var assign = update.AssignTo;
                var userName = _contextAccessor.HttpContext.User.Identity.Name;
                SqlParameter checkUpdate = new SqlParameter()
                {
                    ParameterName = "@oCheckUpdate",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Direction = System.Data.ParameterDirection.Output
                };
                var parameters = new[]
                {
                    new SqlParameter("@congViecId", update.Id),
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
				_mapper.Map(request, update);
                update.TienDo /= 100;
                if(update.NguoiThucHienId is not null && update.NguoiThucHienId != Guid.Empty && assign is null)
                {
                    update.TrangThaiId = update.TrangThaiId == 1 ? 2 : update.TrangThaiId;
                    update.AssignTo = update.NguoiThucHienId;
                }
                if (assign is not null && update.AssignTo != Guid.Empty && update.NguoiThucHienId is null)
                {
                    update.TrangThaiId = update.TrangThaiId == 1 ? 2 : update.TrangThaiId;
                    update.NguoiThucHienId = update.AssignTo;
                }
                // update lại số giờ thực tế và tổng thời gian để lưu vào database vì khi lưu chi tiết không làm thay đổi số giờ thực tế (kh bắt đc js) nên lưu cái cũ
                if (request.listCongViecChiTiet.Count() > 0 || request.listCongViecChiTiet.Count() == 0)
                {
                    request.SoGioThucTe = 0;
                    request.TongThoiGianThucHien = 0;
                    double sumtongthoigianloi = 0;
                    foreach (var item in request.listCongViecChiTiet)
                    {                      
                        request.SoGioThucTe += item.SoGioCong;
                        //var ListChiTietLoi = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_LOI>()
                        //            .GetAll(x => x.ChiTietCongViecId == item.Id && x.IsDeleted != true).ToList();
                        //var TongthoiGianloi = ListChiTietLoi.Sum(x => x.SoGioFix.GetValueOrDefault());
                        //sumtongthoigianloi += TongthoiGianloi;
                        //request.TongThoiGianThucHien = request.SoGioThucTe + request.ThoiGianTest + sumtongthoigianloi;
                    }
                    var ids = request.listCongViecChiTiet
                            .Select(c => c.Id)
                            .ToList();
                     
                }
                update.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                update.NgaySua = DateTime.Now;

                _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC>().update(update);

                #region Thêm tài liệu đính kèm
                var dinhKemIds = JsonSerializer.Deserialize<List<Guid>>(request.TepDinhKemIDs);
                var ListDinhKemCanXoa = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_TEPDINHKEM>().GetAll(x => x.LienKetId == update.Id
                    && !dinhKemIds.Any(y => y == x.Id)).ToList();
                foreach(var attachment in ListDinhKemCanXoa)
                {
                    string fileDelete = Path.Combine(_webHostEnvironment.WebRootPath, attachment.Url);
                    if(System.IO.File.Exists(fileDelete))
                        System.IO.File.Delete(fileDelete);
                }
                _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_TEPDINHKEM>().DeleteRange(ListDinhKemCanXoa);

                List<MODELTepDinhKem> lstAttachment = new();
                lstAttachment = MODELS.COMMON.CommonFunc.UploadData(update.Id, _webHostEnvironment.WebRootPath, "QUANLYCONGVIEC", request.FolderUpload);
                foreach(var attachment in lstAttachment)
                {
                    ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_TEPDINHKEM tepDinhKem = new()
                    {
                        Id = attachment.Id,
                        LienKetId = update.Id,
                        TenFile = attachment.TenFile,
                        TenMoRong = attachment.TenMoRong,
                        DoLon = attachment.DoLon.Value,
                        Url = attachment.Url
                    };
                    _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_TEPDINHKEM>().add(tepDinhKem);
                }
                #endregion
                HashSet<string> listAssignName = new HashSet<string>();

            
                var thongBao = new ENTITIES.DBContent.HETHONG_THONGBAO();
                    thongBao.Id = Guid.NewGuid();
                    thongBao.TieuDe = "Có một công việc mới cần thực hiện";
                    thongBao.NoiDung = request.GhiChu;
                    thongBao.NguoiTao = _contextAccessor.HttpContext.User.Identity.Name;
                    thongBao.NgayTao = DateTime.Now;
                    thongBao.Type = 1;
                _unitOfWork.GetRepository<HETHONG_THONGBAO>().add(thongBao);
                response.Data = _mapper.Map<MODELQuanLyCongViec>(update);
                if (nguoiThucHien is not null && assign is not null && assign != request.AssignTo)
                {
					var AssignTo =  _unitOfWork.GetRepository<TAIKHOAN>().Find(x => x.Id == request.AssignTo);
                    if (AssignTo != null)
                    {
                        response.Data.AssignName = AssignTo.UserName;
                        var LichSuCongViecRequets = new DUAN_LICHSUGIAOVIEC
                        {
                            Id = Guid.NewGuid(),
                            CongViecId = request.Id,
                            TrangThaiId = update.TrangThaiId,
							NguoiDangThucHien = assign,
                            NgayBatDau = DateTime.Now,
                            NguoiTao = _contextAccessor.HttpContext.User.Identity.Name,
                            NgayTao = DateTime.Now,
                            NguoiSua = _contextAccessor.HttpContext.User.Identity.Name,
                            NgaySua = DateTime.Now
                        };
                        _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_LICHSUGIAOVIEC>().add(LichSuCongViecRequets);
                    }
                }
                _unitOfWork.Commit();
                response.Data.listAssignName = listAssignName;
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
            var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC>().Find(x => x.Id == request.Id);
            if(delete is not null)
            {
                delete.IsDeleted = true;
                delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                delete.NgayXoa = DateTime.Now;

                _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC>().update(delete);
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
                var delete = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC>().Find(x => x.Id == id);
                if(delete is not null)
                {
                    delete.IsDeleted = true;
                    delete.NguoiXoa = _contextAccessor.HttpContext.User.Identity.Name;
                    delete.NgayXoa = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC>().update(delete);
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

    public BaseResponse<List<MODELCombobox>> GetAllComboBox(PostQuanLyCongViecGetAllRequest request)
    {
        var response = new BaseResponse<List<MODELCombobox>>();
        var data = _unitOfWork.GetRepository<DUAN_QUANLYCONGVIEC>()
            .GetAll(x => x.DuAnId == request.DuAnId && !x.IsDeleted)
            .ToList();
        response.Data = data.Select(x => new MODELCombobox
        {
            Text = x.TenCongViec,
            Value = x.Id.ToString()
        }).OrderBy(x => x.Text).ToList();
        return response;
    }

    public BaseResponse<List<MODELCombobox>> GetComboBoxTrangThai(GetAllRequest request)
    {
        var response = new BaseResponse<List<MODELCombobox>>();
        var data = _unitOfWork.GetRepository<ENTITIES.DBContent.SYS_TRANGTHAICONGVIEC>()
            .GetAll()
            .ToList();
        response.Data = data.Select(x => new MODELCombobox
        {
            Text = x.TenGoi,
            Value = x.Id.ToString(),
        }).OrderBy(x => x.Value).ToList();

        return response;
    }
    public BaseResponse<List<MODELCombobox>> GetComboBoxTrangThaiForUserName(GetAllRequest request)
    {
        var response = new BaseResponse<List<MODELCombobox>>();

        var userName = _contextAccessor.HttpContext.User.Identity.Name;

        var parameters = new[]
        {
            new SqlParameter("@iUsername",userName)
        };
        var data = _unitOfWork.GetRepository<SYS_TRANGTHAICONGVIEC>().ExcuteStoredProcedure("sp_GETALLTRANGTHAIBYUSERNAM_GETCOMBOX", parameters).ToList();
        response.Data = data.Select(x => new MODELCombobox
        {
            Text = x.TenGoi,
            Value = x.Id.ToString(),
        }).OrderBy(x => x.Value).ToList();
        return response;
    }

    public BaseResponse<List<MODELTongSoCongViec>> GetTongSoCongViec(PostTongSoCongViecRequest request)
    {
        var response = new BaseResponse<List<MODELTongSoCongViec>>();
        try
        {
            var parameter = new[]
            {
                new SqlParameter("@iTaiKhoanId", request.taiKhoanId)
            };
            var result = _unitOfWork.GetRepository<MODELTongSoCongViec>().ExcuteStoredProcedure("sp_DUAN_CONGVIEC_THEOTAIKHOAN", parameter).ToList();
            response.Data = result;
        }
        catch (Exception e)
        {
            response.Error = true;
            response.Message = e.Message;
        }

        return response;
    }

    public BaseResponse<MODELTongSoGioCong> GetTongSoGioCongTrongCongViec(PostTongSoCongViecRequest request)
    {
        var response = new BaseResponse<MODELTongSoGioCong>();
        try
        {
            var parameter = new[]
            {
                new SqlParameter("@iTaiKhoanId", request.taiKhoanId)
            };
            var result = _unitOfWork.GetRepository<MODELTongSoGioCong>().ExcuteStoredProcedure("sp_DUAN_TONGSOGIOCONG_THEOTAIKHOAN", parameter);
            var data = new MODELTongSoGioCong();
            foreach (var iten in result)
            {
                data = iten;
            }
            response.Data = data;
        }
        catch (Exception e)
        {
            response.Error = true;
            response.Message = e.Message;
        }
        
        return response;
    }
    private List<PostQuanLiCongViec_ChiTietRequest> GetListCongViecChiTiet(Guid Id)
    {
        var result = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_CHITIET>().GetAll(x => x.CongViecId == Id).Select(x => new
        {
            Id = x.Id,
            TenCongViecCon = x.TenCongViecCon,
            SoGioCong = x.SoGioCong,
            NgayHoanThanh = x.NgayHoanThanh,
            TrangThaiId = x.TrangThaiId

        }).OrderByDescending(x=>x.NgayHoanThanh).ToList();
        List<PostQuanLiCongViec_ChiTietRequest> list = new List<PostQuanLiCongViec_ChiTietRequest>();
        foreach (var item in result)
        {
            var ctcv = new PostQuanLiCongViec_ChiTietRequest();
            ctcv.Id = item.Id;
            ctcv.TenCongViecCon = item.TenCongViecCon;
            ctcv.NgayHoanThanh = item.NgayHoanThanh;
            ctcv.SoGioCong = item.SoGioCong;
            ctcv.TrangThaiId = item.TrangThaiId;
            list.Add(ctcv);
        }
        return list;
    }
    //private List<PostQuanLyChiTietCongViecLoiRequest> GetListChiTietCongViecLoi(Guid Id)
    //{
    //    var result = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_LOI>().GetAll(x => x.CongViecId == Id)
    //        .Select(x => new { NgayFix = x.NgayFix, SoGioFix = x.SoGioFix , TrangThaiId = x.TrangThaiId  }).ToList();
    //    List<PostQuanLyChiTietCongViecLoiRequest> list = new List<PostQuanLyChiTietCongViecLoiRequest>();
    //    foreach (var item in result)
    //    {
    //        var ctcvl = new PostQuanLyChiTietCongViecLoiRequest();
    //        ctcvl.SoGioFix = item.SoGioFix;
    //        ctcvl.NgayFix = item.NgayFix;
    //        ctcvl.TrangThaiId = item.TrangThaiId;
    //        list.Add(ctcvl);
    //    }
    //    return list;
    //}
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
    //private List<PostSubTaskRequests> GetListSubTask(Guid Id)
    //{
    //    var result = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC>().GetAll(x => x.ParentId == Id).Select(x => new
    //    {
    //        TenCongViec = x.TenCongViec,
    //        AssignTo = x.AssignTo,
    //        TrangThaiId = x.TrangThaiId,
    //        DuKienTuNgay = x.DuKienTuNgay,
    //        DuKienDenNgay = x.DuKienDenNgay,
    //        GhiChu = x.GhiChu
    //    }).ToList();
    //    List<PostSubTaskRequests> list = new List<PostSubTaskRequests>();
    //    foreach(var item in result) 
    //    {
    //        var subTask = new PostSubTaskRequests();
    //        subTask.TenCongViec = item.TenCongViec;
    //        subTask.NgayBatDau = item.DuKienTuNgay;
    //        subTask.NgayHetHan = item.DuKienDenNgay;
    //        subTask.AssignToId = item.AssignTo;
    //        subTask.TrangThaiId = item.TrangThaiId;
    //        list.Add(subTask);
    //    }
    //    return list;
    //}

    public BaseResponse<List<MODELCombobox>> GetAllComboBoxWithDuAn(PostQuanLyCongViecGetAllRequest request)
    {
        var response = new BaseResponse<List<MODELCombobox>>();
        var data = _unitOfWork.GetRepository<DUAN_QUANLYCONGVIEC>()
            .GetAll(x => x.DuAnId == request.DuAnId && !x.IsDeleted)
            .ToList();
        response.Data = data.Select(x => new MODELCombobox
        {
            Text = x.TenCongViec,
            Value = x.Id.ToString()
        }).OrderBy(x => x.Text).ToList();
        return response;
    }
    public BaseResponse<List<MODELCombobox>> GetAllForComboboxChiTietCongViec(PostQuanLyCongViecRequest request)
    {
        BaseResponse<List<MODELCombobox>> response = new();
        var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_CHITIET>()
            .GetAll(x => x.IsDeleted != true && x.CongViecId == request.Id).ToList();
        response.Data = data.Select(x => new MODELCombobox
        {
            Text = x.TenCongViecCon,
            Value = x.Id.ToString(),
        }).OrderBy(x => x.Text).ToList();
            
        return response;
    }
}