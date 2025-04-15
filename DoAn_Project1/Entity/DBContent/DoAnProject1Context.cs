using System;
using System.Collections.Generic;
using ENTITIES.DBContent;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ENTITIES.DBContent;

public partial class DoAnProject1Context : DbContext
{   
    public DoAnProject1Context(DbContextOptions<DoAnProject1Context> options)
        : base(options)
    {
    }
    public virtual DbSet<DM_CHUCVU> DM_CHUCVUs { get; set; }
    public virtual DbSet<DM_DONVI> DM_DONVIs { get; set; }
    public virtual DbSet<DM_GIAIDOANDUAN> DM_GIAIDOANDUANs { get; set; }
    public virtual DbSet<DM_LOAIDUAN> DM_LOAIDUANs { get; set; }
    public virtual DbSet<DM_LOAITAIKHOAN> DM_LOAITAIKHOANs { get; set; }
    public virtual DbSet<DM_PHONGBAN> DM_PHONGBANs { get; set; }
    public virtual DbSet<DUAN_DANHSACHNGUOITHUCHIEN> DUAN_DANHSACHNGUOITHUCHIENs { get; set; }
    public virtual DbSet<DUAN_QUANLYCONGVIEC_TEPDINHKEM> DUAN_QUANLYCONGVIEC_TEPDINHKEMs { get; set; }
    public virtual DbSet<DUAN_LICHSUGIAOVIEC> DUAN_LICHSUGIAOVIECs { get; set; }
    public virtual DbSet<DUAN_QUANLYCONGVIEC> DUAN_QUANLYCONGVIECs { get; set; }
    public virtual DbSet<DUAN_QUANLYCONGVIEC_LOI_TEPDINHKEM> DUAN_QUANLYCONGVIEC_LOI_TEPDINHKEMs { get; set; }
    public virtual DbSet<DUAN_QUANLYCONGVIEC_PHANHOI> DUAN_QUANLYCONGVIEC_PHANHOIs { get; set; }
    public virtual DbSet<DUAN_QUANLYDUAN> DUAN_QUANLYDUANs { get; set; }
    public virtual DbSet<HETHONG_THONGBAO> HETHONG_THONGBAOs { get; set; }

    public virtual DbSet<HETHONG_THONGBAO_TEPDINHKEM> HETHONG_THONGBAO_TEPDINHKEMs { get; set; }

    public virtual DbSet<PHANQUYEN> PHANQUYENs { get; set; }

    public virtual DbSet<PHANQUYEN_NHOMQUYEN> PHANQUYEN_NHOMQUYENs { get; set; }

    public virtual DbSet<QUANLYDUAN_NGUOIDUNG> QUANLYDUAN_NGUOIDUNGs { get; set; }

    public virtual DbSet<SYS_MENU> SYS_MENUs { get; set; }

    public virtual DbSet<SYS_TRANGTHAICONGVIEC> SYS_TRANGTHAICONGVIECs { get; set; }

    public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }

    public virtual DbSet<THONGBAO_NGUOIDUNG> THONGBAO_NGUOIDUNGs { get; set; }

    public virtual DbSet<VAITRO> VAITROs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           
    }

}
