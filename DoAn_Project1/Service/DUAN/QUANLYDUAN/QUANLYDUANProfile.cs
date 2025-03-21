using AutoMapper;
using ENTITIES.DBContent;
using MODELS.DUAN.QUANLYDUAN.Dtos;
using MODELS.DUAN.QUANLYDUAN.Requests;

namespace REPONSITORY.DUAN.QUANLYDUAN;
public class QUANLYDUANProfile : Profile
{
    public QUANLYDUANProfile()
    {
        CreateMap<DUAN_QUANLYDUAN, MODELQuanLyDuAn>();
        CreateMap<MODELQuanLyDuAn, DUAN_QUANLYDUAN>();
        CreateMap<DUAN_QUANLYDUAN, PostQuanLyDuAnRequest>();
        CreateMap<PostQuanLyDuAnRequest, DUAN_QUANLYDUAN>();
    }
}
