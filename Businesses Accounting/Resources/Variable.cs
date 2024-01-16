using System.ComponentModel;

namespace Businesses_Accounting.Resources
{
    public class Variable
    {
        public enum AccessType
        {
            /// <summary>
            /// حسابدار
            /// </summary>
            [Description("حسابدار")]
            Accounter = 0,
            /// <summary>
            /// مالک
            /// </summary>
            [Description("مالک")]
            Owner = 1,
            /// <summary>
            /// مدیر
            /// </summary>
            [Description("مدیر")]
            Admin = 1,
            /// <summary>
            /// بدون دسترسی
            /// </summary>
            [Description("بدون دسترسی")]
            Ignore = 20000

        }
    }
}
