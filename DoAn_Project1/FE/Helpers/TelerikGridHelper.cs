using Kendo.Mvc.UI.Fluent;

namespace FE.Helpers
{
    public class TelerikGridHelper
    {
        private static void customStringFilterOperator(GridFilterableSettingsBuilder arg)
        {
            arg.Operators(f => f
                .ForString(str => str
                    .Clear()
                    .Contains("Bao gồm")
                    .DoesNotContain("Không bao gồm")
                    .StartsWith("Bắt đầu với")
                    .EndsWith("Kết thúc với")
                    .IsEqualTo("Bằng")
                    .IsNotEqualTo("Không bằng")
                    .IsEmpty("Rỗng")
                    .IsNotEmpty("Không rỗng")
                    .IsNotNull("Có giá trị")
                    .IsNull("Không có giá trị")
                )
            );
        }

        public static Action<GridFilterableSettingsBuilder> CustomStringFilterOperator()
        {
            return customStringFilterOperator;
        }
    }
}
