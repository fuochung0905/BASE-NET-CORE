using AutoMapper;
using ENTITIES.DBContent;
using MODELS.HETHONG.HETHONGTHONGBAO.Dtos;
using MODELS.HETHONG.HETHONGTHONGBAO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPONSITORY.HETHONG.THONGBAO
{
    public class THONGBAOProfile : Profile
    {
        public THONGBAOProfile() {
            CreateMap<HETHONG_THONGBAO, MODELThongBao>();
            CreateMap<MODELThongBao, HETHONG_THONGBAO>();
            CreateMap<PostThongBaoRequest, HETHONG_THONGBAO>();
            CreateMap<HETHONG_THONGBAO, PostThongBaoRequest>();
        }
    }
}
