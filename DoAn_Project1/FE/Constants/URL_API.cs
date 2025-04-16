namespace FE.Constants
{
    public class URL_API
    {
        #region BASE
        public const string UPLOADFILE = "uploadfile";
        public const string PING = "ping";
        public const string GETCODEREGISTER = "license/getcoderegister";
        public const string GETREGISTERINFO = "license/GetRegisterInfo";
        public const string SETLICENSE = "license/SetLicense";
        #endregion

        #region HETHONG
        //TAIKHOAN
        public const string TAIKHOAN_LOGIN = "taikhoan/login";
        public const string TAIKHOAN_GETLISTPAGING = "taikhoan/get-list-paging";
        public const string TAIKHOAN_GETBYID = "taikhoan/get-by-id";
        public const string TAIKHOAN_GETBYPOST = "taikhoan/get-by-post";
        public const string TAIKHOAN_GETBYUSERNAME = "taikhoan/get-by-username";
        public const string TAIKHOAN_GETINFO = "taikhoan/get-info";
        public const string TAIKHOAN_INSERT = "taikhoan/insert";
        public const string TAIKHOAN_UPDATE = "taikhoan/update";
        public const string TAIKHOAN_UPDATEINFO = "taikhoan/capnhat-info";
        public const string TAIKHOAN_DELETE = "taikhoan/delete";
        public const string TAIKHOAN_DELETELIST = "taikhoan/delete-list";
        public const string TAIKHOAN_CHANGEPASSWORD = "taikhoan/change-password";
        public const string TAIKHOAN_GETLISTMENU = "taikhoan/get-list-menu";
        public const string TAIKHOAN_GETPHANQUYEN = "taikhoan/get-phan-quyen";
        public const string TAIKHOAN_GETLISTNHATKY = "taikhoan/get-list-nhatky";
        public const string TAIKHOAN_GETLISTNHATKYTRUYCAP = "taikhoan/get-list-nhatky-truycap";
        public const string TAIKHOAN_GETLISTNHATKYTHAOTAC = "taikhoan/get-list-nhatky-thaotac";
        public const string TAIKHOAN_GETALLFORCOMBOBOX = "taikhoan/get-all-combobox";
        public const string TAIKHOAN_GETCOMBOBOXNGUOIQUANLY = "taikhoan/get-combo-box-nguoi-quan-ly";

        //VAITRO
        public const string VAITRO_GETLISTPAGING = "vaitro/get-list-paging";
        public const string VAITRO_GETBYID = "vaitro/get-by-id";
        public const string VAITRO_GETBYPOST = "vaitro/get-by-post";
        public const string VAITRO_INSERT = "vaitro/insert";
        public const string VAITRO_UPDATE = "vaitro/update";
        public const string VAITRO_DELETELIST = "vaitro/delete-list";
        public const string VAITRO_GETALLCOMBOBOX = "vaitro/get-all-combobox";
        public const string VAITRO_GETLISTPHANQUYEN = "vaitro/get-list-phan-quyen";
        public const string VAITRO_POSTPHANQUYEN = "vaitro/post-phan-quyen";
        //MENU
        public const string MENU_GETLISTPAGING = "menu/get-list-paging";
        public const string MENU_GETALL = "menu/get-all";
        public const string MENU_GETBYID = "menu/get-by-id";
        public const string MENU_GETBYPOST = "menu/get-by-post";
        public const string MENU_INSERT = "menu/insert";
        public const string MENU_UPDATE = "menu/update";
        //NHOMQUYEN
        public const string NHOMQUYEN_GETLIST = "nhomquyen/get-list";
        public const string NHOMQUYEN_GETALL = "nhomquyen/get-all";
        public const string NHOMQUYEN_GETBYID = "nhomquyen/get-by-id";
        public const string NHOMQUYEN_GETBYPOST = "nhomquyen/get-by-post";
        public const string NHOMQUYEN_INSERT = "nhomquyen/insert";
        public const string NHOMQUYEN_UPDATE = "nhomquyen/update";
        public const string NHOMQUYEN_GETALLCOMBOBOX = "nhomquyen/get-all-combobox";
        public const string NHOMQUYEN_GETALLPARENTCOMBOBOX = "nhomquyen/get-all-parent-combobox";
        //CAUHINHHETHONG
        public const string CAUHINHHETHONG_GETBYPOST = "cauhinhhethong/get-by-post";
        public const string CAUHINHHETHONG_UPDATE = "cauhinhhethong/update";
        //CAIDATBAOMAT
        public const string CAIDATBAOMAT_GETSESSIONTIME = "caidatbaomat/get-session-time";
        public const string CAIDATBAOMAT_GETBYPOST = "caidatbaomat/get-by-post";
        public const string CAIDATBAOMAT_UPDATE = "caidatbaomat/update";
        public const string BLOCKIP_GETLIST = "caidatbaomat/get-list-blockip";
        public const string BLOCKIP_POST = "caidatbaomat/update-blockip";
        //EMAIL
        public const string EMAIL_GET = "email/get";
        public const string EMAIL_UPDATE = "email/update";
        public const string EMAIL_POSTLAYLAIMATKHAU = "email/post-lay-lai-mat-khau";

        //THONGBAO
        public const string THONGBAO_GETLISTPAGING = "thongbao/get-list-paging";
        public const string THONGBAO_GETBYID = "thongbao/get-by-id";
        public const string THONGBAO_GETBYPOST = "thongbao/get-by-post";
        public const string THONGBAO_INSERT = "thongbao/insert";
        public const string THONGBAO_UPDATE = "thongbao/update";
        public const string THONGBAO_DELETELIST = "thongbao/delete-list";
        public const string THONGBAO_GETALLCOMBOBOX = "thongbao/get-all-combobox";
        public const string THONGBAO_GETLISTPHANQUYEN = "thongbao/get-list-phan-quyen";
        public const string THONGBAO_POSTPHANQUYEN = "thongbao/post-phan-quyen";
        public const string THONGBAO_SOLUONGTHONGBAOCHUAXEM = "thongbao/get-so-luong-thong-bao";
        
        #endregion

        #region DANHMUC
        //DONVIhttps://localhost:7294/TrangThaiCongViec/Index#
        public const string DONVI_GETALLFORCOMBOBOX = "donvi/get-all-combobox";
        public const string DONVI_GETLIST = "donvi/get-list";
        public const string DONVI_GETBYID = "donvi/get-by-id";
        public const string DONVI_GETBYPOST = "donvi/get-by-post";
        public const string DONVI_INSERT = "donvi/insert";
        public const string DONVI_UPDATE = "donvi/update";
        public const string DONVI_DELETE = "donvi/delete";
        public const string DONVI_DELETELIST = "donvi/delete-list";

        //PHONGBAN
        public const string PHONGBAN_GETALLFORCOMBOBOX = "phongban/get-all-combobox";
        public const string PHONGBAN_GETALLFORCOMBOBOX_DONVI = "phongban/get-all-combobox-donvi";
        public const string PHONGBAN_GETLIST = "phongban/get-list";
        public const string PHONGBAN_GETBYID = "phongban/get-by-id";
        public const string PHONGBAN_GETBYPOST = "phongban/get-by-post";
        public const string PHONGBAN_INSERT = "phongban/insert";
        public const string PHONGBAN_UPDATE = "phongban/update";
        public const string PHONGBAN_DELETE = "phongban/delete";
        public const string PHONGBAN_DELETELIST = "phongban/delete-list";



        //GIAIDOANDUAN
        public const string GIAIDOANDUAN_GETLIST = "giaidoanduan/get-list";
        public const string GIAIDOANDUAN_GETBYID = "giaidoanduan/get-by-id";
        public const string GIAIDOANDUAN_GETBYPOST = "giaidoanduan/get-by-post";
        public const string GIAIDOANDUAN_INSERT = "giaidoanduan/insert";
        public const string GIAIDOANDUAN_UPDATE = "giaidoanduan/update";
        public const string GIAIDOANDUAN_DELETELIST = "giaidoanduan/delete-list";
        public const string GIAIDOANDUAN_GETALLFORCOMBOBOX = "giaidoanduan/get-all-combobox";

        //LOAITAIKHOAN
        public const string LOAITAIKHOAN_GETLIST = "loaitaikhoan/get-list";
        public const string LOAITAIKHOAN_GETBYID = "loaitaikhoan/get-by-id";
        public const string LOAITAIKHOAN_GETBYPOST = "loaitaikhoan/get-by-post";
        public const string LOAITAIKHOAN_INSERT = "loaitaikhoan/insert";
        public const string LOAITAIKHOAN_UPDATE = "loaitaikhoan/update";
        public const string LOAITAIKHOAN_DELETELIST = "loaitaikhoan/delete-list";
        public const string LOAITAIKHOAN_GETALLFORCOMBOBOX = "loaitaikhoan/get-all-combobox";

        //CONGVIECTRONGGIAIDOAN
        public const string CONGVIECTRONGGIAIDOAN_GETLIST = "congviectronggiaidoan/get-list";
        public const string CONGVIECTRONGGIAIDOAN_GETBYID = "congviectronggiaidoan/get-by-id";
        public const string CONGVIECTRONGGIAIDOAN_GETBYPOST = "congviectronggiaidoan/get-by-post";
        public const string CONGVIECTRONGGIAIDOAN_INSERT = "congviectronggiaidoan/insert";
        public const string CONGVIECTRONGGIAIDOAN_UPDATE = "congviectronggiaidoan/update";
        public const string CONGVIECTRONGGIAIDOAN_DELETELIST = "congviectronggiaidoan/delete-list";
        public const string CONGVIECTRONGGIAIDOAN_GETALLCOMBOBOX = "congviectronggiaidoan/get-all-combobox";
        public const string CONGVIECTRONGGIAIDOAN_GETALLCOMBOBOXBYGIAIDOAN = "congviectronggiaidoan/get-all-combobox-by-giai-doan";
        //CHUCVU
        public const string CHUCVU_GETALLFORCOMBOBOX = "chucvu/get-all-combobox";
        public const string CHUCVU_GETLIST = "chucvu/get-list";
        public const string CHUCVU_GETBYID = "chucvu/get-by-id";
        public const string CHUCVU_GETBYPOST = "chucvu/get-by-post";
        public const string CHUCVU_INSERT = "chucvu/insert";
        public const string CHUCVU_UPDATE = "chucvu/update";
        public const string CHUCVU_DELETE = "chucvu/delete";
        public const string CHUCVU_DELETELIST = "chucvu/delete-list";


        //MONHOC
        public const string MONHOC_GETALLFORCOMBOBOX = "monhoc/get-all-combobox";
        public const string MONHOC_GETLIST = "monhoc/get-list";
        public const string MONHOC_GETBYID = "monhoc/get-by-id";
        public const string MONHOC_GETBYPOST = "monhoc/get-by-post";
        public const string MONHOC_INSERT = "monhoc/insert";
        public const string MONHOC_UPDATE = "monhoc/update";
        public const string MONHOC_DELETE = "monhoc/delete";
        public const string MONHOC_DELETELIST = "monhoc/delete-list";

        //TEAM
        public const string TEAM_GETALLFORCOMBOBOX = "chucvu/get-all-combobox";
        public const string TEAM_GETLIST = "chucvu/get-list";
        public const string TEAM_GETBYID = "chucvu/get-by-id";
        public const string TEAM_GETBYPOST = "chucvu/get-by-post";
        public const string TEAM_INSERT = "chucvu/insert";
        public const string TEAM_UPDATE = "chucvu/update";
        public const string TEAM_DELETE = "chucvu/delete";
        public const string TEAM_DELETELIST = "chucvu/delete-list";

        //LOAITAIKHOAN
        public const string LOAIHOSO_GETALLFORCOMBOBOX = "loaihoso/get-all-combobox";
        public const string LOAIHOSO_GETLIST = "loaihoso/get-list";
        public const string LOAIHOSO_GETBYID = "loaihoso/get-by-id";
        public const string LOAIHOSO_GETBYPOST = "loaihoso/get-by-post";
        public const string LOAIHOSO_INSERT = "loaihoso/insert";
        public const string LOAIHOSO_UPDATE = "loaihoso/update";
        public const string LOAIHOSO_DELETE = "loaihoso/delete";
        public const string LOAIHOSO_DELETELIST = "loaihoso/delete-list";
   
        #endregion

     

        #region ThongKeKetQua
        public const string THONGKEKETQUACONGVIEC_GETKETQUA = "THONGKEKETQUACONGVIEC/get-ket-qua";
        public const string THONGKEKETQUACONGVIEC_GETKETQUATUAN = "THONGKEKETQUACONGVIEC/get-ket-qua-tuan";
        public const string THONGKEKETQUACONGVIEC_GETKETQUAP = "THONGKEKETQUACONGVIEC/get-ket-qua-phong";
        public const string THONGKEKETQUACONGVIEC_GETKETQUATUANP = "THONGKEKETQUACONGVIEC/get-ket-qua-tuan-phong";
        public const string THONGKEKETQUACONGVIEC_GETKETQUADUAN = "THONGKEKETQUACONGVIECDUAN/get-ket-qua-duan";
        #endregion

        #region DUAN
        //QUANLYCONGVIEC
        public const string QUANLYCONGVIEC_GETLIST = "quanlycongviec/get-list";
        public const string QUANLYCONGVIEC_TONG = "quanlycongviec/get-tong";
        
        public const string QUANLYCONGVIEC_GETBYID = "quanlycongviec/get-by-id";
		public const string QUANLYCONGVIEC_GETBYPOST = "quanlycongviec/get-by-post";
		public const string QUANLYCONGVIEC_INSERT = "quanlycongviec/insert";
		public const string QUANLYCONGVIEC_UPDATE = "quanlycongviec/update";
		public const string QUANLYCONGVIEC_DELETE = "quanlycongviec/delete";
        public const string QUANLYCONGVIEC_DELETELIST = "quanlycongviec/delete-list";
        public const string QUANLYCONGVIEC_GETALLCOMBOBOX = "quanlycongviec/get-all-combo-box";
        public const string QUANLYCONGVIEC_GETALLCOMBOBOXWITHDUAN = "quanlycongviec/get-all-combo-box-with-du-an";
        public const string QUANLYCONGVIEC_GETCOMBOBOXTRANGTHAI = "quanlycongviec/get-combo-box-trang-thai";
        public const string QUANLYCONGVIEC_GETCOMBOBOXBYUSERNAME = "quanlycongviec/get-combo-box-trang-thai-by-username";
        public const string QUANLYCONGVIEC_GETTONGSOCONGVIECTHEOUSER= "quanlycongviec/tong-so-cong-viec";
        public const string QUANLYCONGVIEC_GETTONGSOGIOCONG = "quanlycongviec/tong-so-gio-cong";
        public const string QUANLYCONGVIEC_GETCOMBOBOXBYCHITIETCV = "quanlycongviec/get-all-combo-box-chi-tiet-cong-viec";
        // PHAN HOI
        public const string CONGVIEC_PHANHOI_GETLIST = "phanhoi_congviec/get-list";
        public const string CONGVIEC_PHANHOI_INSERT = "phanhoi_congviec/insert";
        public const string CONGVIEC_PHANHOI_GETBYID = "phanhoi_congviec/get-by-id";
        public const string CONGVIEC_PHANHOI_DELETE = "phanhoi_congviec/delete";
        public const string CONGVIEC_PHANHOI_UPDATE = "phanhoi_congviec/update";
        //QUANLYCONGVIEC_CHITIET
        public const string QUANLICONGVIEC_CHITIET_GETLIST = "quanlicongviecchitiet/get-list";
        public const string QUANLICONGVIEC_CHITIET_GETBYPOST = "quanlicongviecchitiet/get-by-post";
        public const string QUANLICONGVIEC_CHITIET_UPDATE = "quanlicongviecchitiet/update";
        //QUANLYCONGVIEC_LOI
        public const string QUANLYCONGVIEC_LOI_GETLISTTESTLOI_THONGKE = "QuanLyCongViec_Loi_Test/get-list-test-loi-thong-ke";
        public const string QUANLYCONGVIEC_LOI_GETLIST_THONGKE = "quanlycongviec_loi/get-list-loi-thong-ke";
        public const string QUANLYCONGVIEC_LOI_GETLIST = "quanlycongviec_loi/get-list";
        public const string QUANLYCONGVIEC_LOI_GETBYID = "quanlycongviec_loi/get-by-id";
        public const string QUANLYCONGVIEC_LOI_GETBYPOST = "quanlycongviec_loi/get-by-post";
        public const string QUANLYCONGVIEC_LOI_INSERT = "quanlycongviec_loi/insert";
        public const string QUANLYCONGVIEC_LOI_UPDATE = "quanlycongviec_loi/update";
        public const string QUANLYCONGVIEC_LOI_DELETE = "quanlycongviec_loi/delete";
        public const string QUANLYCONGVIEC_LOI_DELETELIST = "quanlycongviec_loi/delete-list";

        // LICH SU CONG VIEC
        public const string QUANLYCONGVIEC_LICHSUCONGVIEC = "lichsucongviec/get-list";

        //TRANG THAI CONG VIEC
        public const string TRANGTHAICONGVIEC_GETLISTCONGVIEC = "trangthaicongviec/get-list-cong-viec";
        public const string TRANGTHAICONGVIEC_GETLISTTRANGTHAICONGVIEC = "trangthaicongviec/get-list-trang-thai";
        public const string TRANGTHAICONGVIEC_UPDATETRANGTHAICONGVIEC = "trangthaicongviec/update";
        public const string TRANGTHAICONGVIEC_CHECKROLE = "trangthaicongviec/check-role";
        public const string TRANGTHAICONGVIEC_GETBYID = "trangthaicongviec/get-by-id";
        public const string TRANGTHAICONGVIEC_UPDATECONGVIEC = "trangthaicongviec/update-congviec";

        //QUANLYDUAN
        public const string QUANLYDUAN_GETLIST = "quanlyduan/get-list";
        public const string QUANLYDUAN_GETBYID = "quanlyduan/get-by-id";
        public const string QUANLYDUAN_GETBYPOST = "quanlyduan/get-by-post";
        public const string QUANLYDUAN_INSERT = "quanlyduan/insert";
        public const string QUANLYDUAN_UPDATE = "quanlyduan/update";
        public const string QUANLYDUAN_DELETE = "quanlyduan/delete";
        public const string QUANLYDUAN_DELETELIST = "quanlyduan/delete-list";
        public const string QUANLYDUAN_GETALLCOMBOBOX = "quanlyduan/get-all-combo-box";
        public const string QUANLYDUAN_GETTONGDUANTHEOTUNGIAIDOAN = "quanlyduan/get-tong-du-an";



        #endregion


 


        #region THONGKE
        //QUANLICONGVIEC
        public const string QUANLICONGVIEC_GETLISTEXPORT = "thongke/export-excel-bao-cao-cong-viec";
        public const string THONGKEBAOCAOCONGVIECCANHAN = "thongkebaocaocongvieccanhan/bao-cao-cong-viec-tung-ca-nhan-theo-thang";
        public const string THONGKESOGIOCONGNHANVIEN = "thongkesogiocong/export-excel-thong-ke-so-gio-cong-nhan-vien";
        #endregion
    }
}