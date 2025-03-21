using AutoMapper;
using ENTITIES.DBContent;
using MODELS.BASE;
using MODELS.DUAN.QUANLICONGVIEC_CHITIET.Dtos;
using MODELS.DUAN.QUANLICONGVIEC_CHITIET.Requests;
using MODELS.DUAN.QUANLYCONGVIEC.Dtos;
using MODELS.DUAN.QUANLYCONGVIEC.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPONSITORY.DUAN.QUANLYCONGVIECCHITIET
{
    public class QUANLICONGVIECCHITIETProfile : Profile
    {
        public QUANLICONGVIECCHITIETProfile()
        {
            CreateMap<DUAN_QUANLYCONGVIEC_CHITIET, MODELQuanLiCongViecChiTiet>();
            CreateMap<MODELQuanLiCongViecChiTiet, DUAN_QUANLYCONGVIEC_CHITIET>();
            CreateMap<PostQuanLiCongViec_ChiTietRequest, DUAN_QUANLYCONGVIEC_CHITIET>();
            CreateMap<DUAN_QUANLYCONGVIEC_CHITIET, PostQuanLiCongViec_ChiTietRequest>();
        }
    }
}
