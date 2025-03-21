using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ENTITIES.DBContent;
using MODELS.DUAN.PHANHOI.Requests;
using MODELS.DUAN.QUANLYCONGVIEC.Dtos;

namespace REPONSITORY.DUAN.PHANHOI
{
    public class PhanHoiProfile : Profile
    {
        public PhanHoiProfile()
        {
            CreateMap<DUAN_QUANLYCONGVIEC_PHANHOI, MODELQuanLyCongViec_PhanHoi>();
            CreateMap<MODELQuanLyCongViec_PhanHoi, DUAN_QUANLYCONGVIEC_PHANHOI>();
            CreateMap<PostPhanHoiRequest, DUAN_QUANLYCONGVIEC_PHANHOI>();
            CreateMap<DUAN_QUANLYCONGVIEC_PHANHOI, PostPhanHoiRequest>();
        }
    }
}
