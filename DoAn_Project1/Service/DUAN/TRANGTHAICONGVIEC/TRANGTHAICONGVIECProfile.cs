using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ENTITIES.DBContent;
using MODELS.DUAN.TRANGTHAICONGVIEC.Dtos;
using MODELS.DUAN.TRANGTHAICONGVIEC.Request;

namespace REPONSITORY.DUAN.TRANGTHAICONGVIEC
{
    public class TRANGTHAICONGVIECProfile : Profile
    {
        public TRANGTHAICONGVIECProfile()
        {
            CreateMap<SYS_TRANGTHAICONGVIEC, MODELTrangThaiCongViec>();
            CreateMap<MODELTrangThaiCongViec, SYS_TRANGTHAICONGVIEC>();
            CreateMap<MODELCongViec, DUAN_QUANLYCONGVIEC>();
            CreateMap<DUAN_QUANLYCONGVIEC, MODELCongViec>();
            CreateMap<PostCongViecByTrangThaiRequest, DUAN_QUANLYCONGVIEC>();
            CreateMap<DUAN_QUANLYCONGVIEC, PostCongViecByTrangThaiRequest>();
        }
    }
}
