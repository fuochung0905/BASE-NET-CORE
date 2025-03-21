using System;
using System.Collections.Generic;
using ENTITIES.DBContent;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<DM_CHUCVU>(entity =>
        {
            entity.ToTable("DM_CHUCVU");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsActived).HasDefaultValue(true);
            entity.Property(e => e.MaChucVu).HasMaxLength(256);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiXoa)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.TenChucVu).HasMaxLength(500);
        });

        modelBuilder.Entity<DM_DONVI>(entity =>
        {
            entity.ToTable("DM_DONVI");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(1000);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActived).HasDefaultValue(true);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiLienHe).HasMaxLength(500);
            entity.Property(e => e.NguoiSua)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiXoa)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.TenGoi).HasMaxLength(500);
            entity.Property(e => e.Website)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DM_GIAIDOANDUAN>(entity =>
        {
            entity.ToTable("DM_GIAIDOANDUAN");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Ma).HasMaxLength(50);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiXoa)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.TenGoi).HasMaxLength(500);
        });

        modelBuilder.Entity<DM_LOAIDUAN>(entity =>
        {
            entity.ToTable("DM_LOAIDUAN");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Ma).HasMaxLength(50);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiXoa)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.TenGoi).HasMaxLength(500);
        });


        modelBuilder.Entity<DM_PHONGBAN>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PHONGBAN");

            entity.ToTable("DM_PHONGBAN");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsActived).HasDefaultValue(true);
            entity.Property(e => e.Ma).HasMaxLength(50);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasDefaultValueSql("(((((0)-(0))-(0))-(0))-(0.0))");
            entity.Property(e => e.NguoiXoa)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.TenGoi).HasMaxLength(500);
        });


        modelBuilder.Entity<DUAN_DANHSACHNGUOITHUCHIEN>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DUAN_DANHSACHNGUOITHUCHIEN");
        });

        modelBuilder.Entity<DUAN_LICHSUGIAOVIEC>(entity =>
        {
            entity.ToTable("DUAN_LICHSUGIAOVIEC");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua).HasMaxLength(256);
            entity.Property(e => e.NguoiTao).HasMaxLength(256);
            entity.Property(e => e.NguoiXoa).HasMaxLength(256);
        });

        modelBuilder.Entity<DUAN_QUANLYCONGVIEC>(entity =>
        {
            entity.ToTable("DUAN_QUANLYCONGVIEC");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DuKienDenNgay).HasColumnType("datetime");
            entity.Property(e => e.DuKienTuNgay).HasColumnType("datetime");
            entity.Property(e => e.GioCongDuKien).HasComment("Tính theo giờ");
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiXoa)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.TenCongViec).HasMaxLength(500);
            entity.Property(e => e.ThoiGianTest).HasComment("Tính theo giờ");
            entity.Property(e => e.ThucTeDenNgay).HasColumnType("datetime");
            entity.Property(e => e.ThucTeTuNgay).HasColumnType("datetime");
        });

        modelBuilder.Entity<DUAN_QUANLYCONGVIEC_TEPDINHKEM>(entity =>
        {
            entity.ToTable("DUAN_QUANLYCONGVIEC_TEPDINHKEM");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TenFile).HasMaxLength(500);
            entity.Property(e => e.TenMoRong)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.Url).HasMaxLength(1000);
        });
        modelBuilder.Entity<DUAN_QUANLYCONGVIEC_LOI_TEPDINHKEM>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_QUANLYCONGVIEC_LOI_TEPDINHkEM");

            entity.ToTable("DUAN_QUANLYCONGVIEC_LOI_TEPDINHKEM");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TenFile).HasMaxLength(500);
            entity.Property(e => e.TenMoRong)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.Url).HasMaxLength(1000);
        });

        modelBuilder.Entity<DUAN_QUANLYCONGVIEC_PHANHOI>(entity =>
        {
            entity.ToTable("DUAN_QUANLYCONGVIEC_PHANHOI");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NgayGui).HasColumnType("datetime");
        });


        modelBuilder.Entity<DUAN_QUANLYDUAN>(entity =>
        {
            entity.ToTable("DUAN_QUANLYDUAN");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ChuDauTu).HasMaxLength(500);
            entity.Property(e => e.MaDuAn).HasMaxLength(50);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua).HasMaxLength(256);
            entity.Property(e => e.NguoiTao).HasMaxLength(256);
            entity.Property(e => e.NguoiXoa).HasMaxLength(256);
            entity.Property(e => e.TenDuAn).HasMaxLength(500);
            entity.Property(e => e.ThoiGianBatDau).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianKetThuc).HasColumnType("datetime");
        });

        modelBuilder.Entity<HETHONG_THONGBAO>(entity =>
        {
            entity.ToTable("HETHONG_THONGBAO");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsActived).HasDefaultValue(true);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiXoa)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.TieuDe).HasMaxLength(500);
        });

        modelBuilder.Entity<HETHONG_THONGBAO_TEPDINHKEM>(entity =>
        {
            entity.ToTable("HETHONG_THONGBAO_TEPDINHKEM");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.TenFile).HasMaxLength(500);
            entity.Property(e => e.TenMoRong)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.Url).HasMaxLength(1000);
        });

        modelBuilder.Entity<PHANQUYEN>(entity =>
        {
            entity.ToTable("PHANQUYEN");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ControllerName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PHANQUYEN_NHOMQUYEN>(entity =>
        {
            entity.ToTable("PHANQUYEN_NHOMQUYEN");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActived).HasDefaultValue(true);
            entity.Property(e => e.TenGoi).HasMaxLength(500);
        });

        modelBuilder.Entity<QUANLYDUAN_NGUOIDUNG>(entity =>
        {
            entity.ToTable("QUANLYDUAN_NGUOIDUNG");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });


        modelBuilder.Entity<SYS_MENU>(entity =>
        {
            entity.HasKey(e => e.ControllerName).HasName("PK_PHANQUYEN_QUYEN");

            entity.ToTable("SYS_MENU");

            entity.Property(e => e.ControllerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Controller)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActived).HasDefaultValue(true);
            entity.Property(e => e.IsShowMenu).HasDefaultValue(true);
            entity.Property(e => e.TenGoi).HasMaxLength(500);
        });

        modelBuilder.Entity<TAIKHOAN>(entity =>
        {
            entity.ToTable("TAIKHOAN");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AnhDaiDien).HasMaxLength(500);
            entity.Property(e => e.CountLoginFail).HasComment("Số lần đăng nhập sai");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinh).HasComment("0: nam, 1: nữ");
            entity.Property(e => e.HoLot).HasMaxLength(200);
            entity.Property(e => e.IsFirstLogin)
                .HasDefaultValue(false)
                .HasComment("Là đăng nhập lần đầu");
            entity.Property(e => e.MatKhau).HasMaxLength(500);
            entity.Property(e => e.MatKhauSalt).HasMaxLength(100);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiXoa)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Ten).HasMaxLength(100);
            entity.Property(e => e.TimeChangePassword)
                .HasComment("Thời gian đổi mật khẩu gần nhất")
                .HasColumnType("datetime");
            entity.Property(e => e.TimeLoginFail)
                .HasComment("Thời gian đăng nhập sai gần nhất")
                .HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(256)
                .IsUnicode(false);
        });

        modelBuilder.Entity<THONGBAO_NGUOIDUNG>(entity =>
        {
            entity.ToTable("THONGBAO_NGUOIDUNG");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Delivered_At).HasColumnType("datetime");
            entity.Property(e => e.Read_At).HasColumnType("datetime");
        });

        modelBuilder.Entity<VAITRO>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_VAITRO_1");

            entity.ToTable("VAITRO");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NgayXoa).HasColumnType("datetime");
            entity.Property(e => e.NguoiSua)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.NguoiXoa)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.TenGoi).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
