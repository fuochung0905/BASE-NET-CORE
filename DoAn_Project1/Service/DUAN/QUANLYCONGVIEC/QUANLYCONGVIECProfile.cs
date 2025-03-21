using AutoMapper;
using ENTITIES.DBContent;
using Model.BASE;
using MODELS.BASE;
using MODELS.DUAN.QUANLYCONGVIEC.Dtos;
using MODELS.DUAN.QUANLYCONGVIEC.Requests;

namespace REPONSITORY.DUAN.QUANLYCONGVIEC;

public class QUANLYCONGVIECProfile : Profile
{
    public QUANLYCONGVIECProfile()
    {
        CreateMap<DUAN_QUANLYCONGVIEC, MODELQuanLyCongViec>();
        CreateMap<MODELQuanLyCongViec, DUAN_QUANLYCONGVIEC>();
        CreateMap<PostQuanLyCongViecRequest, DUAN_QUANLYCONGVIEC>();
        CreateMap<DUAN_QUANLYCONGVIEC, PostQuanLyCongViecRequest>();
        //TepDinhKem
        CreateMap<DUAN_QUANLYCONGVIEC_TEPDINHKEM, MODELTepDinhKem>();
        CreateMap<MODELTepDinhKem, DUAN_QUANLYCONGVIEC_TEPDINHKEM>();
    }
}