using Microsoft.AspNetCore.Mvc.Rendering;
namespace FE.Constants
{
	public class SYS_CONFIG
	{
		public static int[] PAGE_SIZES = new int[] { 50, 70, 100 };
		public const int PAGE_SIZE_DEFAULT = 50;
		public const int PAGE_SIZE_DEFAULT_5 = 50;
		public const int PAGE_SIZE_SHOWLIST = 500;

		public static string PHONGBAN_LABEL = "Phòng ban";

        public static List<SelectListItem> GIOI_TINH = new List<SelectListItem>()
        {
            new SelectListItem(){Text ="Nam", Value="0"},
            new SelectListItem(){Text ="Nữ", Value="1"},
            new SelectListItem(){Text ="Khác", Value="2"}
        };
        public static List<SelectListItem> LOAITHONGBAO = new List<SelectListItem>()
        {
            new SelectListItem(){Text = "Tin nhắn", Value="0"},
            new SelectListItem(){Text ="Thông báo công việc", Value="True"},
            new SelectListItem(){Text ="Thông báo chung", Value="False"},
        };
        public static List<SelectListItem> TRANG_THAI = new List<SelectListItem>()
		{
			new SelectListItem(){Text ="Hoạt động", Value="True"},
			new SelectListItem(){Text ="Không hoạt động", Value="False"},
		};
        public static List<SelectListItem> LOAIDUAN = new List<SelectListItem>()
        {
            new SelectListItem(){Text ="OutSource", Value="1"},
            new SelectListItem(){Text ="Khoán phòng", Value="2"},
            new SelectListItem(){Text ="Tư vấn", Value="3"},
        };
        public static List<SelectListItem> PHUONG_THUC_THANH_TOAN = new List<SelectListItem>()
        {
            new SelectListItem(){Text ="Chuyển khoản", Value="1"},
            new SelectListItem(){Text ="Tiền mặt", Value="2"},
        };
    }
}
