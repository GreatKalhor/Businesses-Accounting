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
            Admin = 2,
            /// <summary>
            /// بدون دسترسی
            /// </summary>
            [Description("بدون دسترسی")]
            Ignore = 20000

        }
        public enum CategoryType
        {
            /// <summary>
            /// اشخاص
            /// </summary>
            [Description("اشخاص")]
            Contact = 0,
            /// <summary>
            /// بانکداری
            /// </summary>
            [Description("بانکداری")]
            Banking = 1,
            /// <summary>
            /// کالا
            /// </summary>
            [Description("کالا")]
            Product = 2,
            /// <summary>
            /// خدمات
            /// </summary>
            [Description("خدمات")]
            Service = 3

        }
        public enum CalendarType
        {
            /// <summary>
            /// هجری شمسی
            /// </summary>
            [Description("هجری شمسی")]
            Persian = 1,
            /// <summary>
            /// میلادی
            /// </summary>
            [Description("میلادی")]
            Gregorian = 2

        }
        public enum InventoryAccountingSystemType
        {
            /// <summary>
            /// ادواری
            /// </summary>
            [Description("ادواری")]
            Periodic = 0

        }


        public enum ObjectType
        {
            /// <summary>
            /// اشخاص
            /// </summary>
            [Description("اشخاص")]
            Contact = 0,
            /// <summary>
            /// بانکداری
            /// </summary>
            [Description("بانکداری")]
            Banking = 1,
            /// <summary>
            /// کالا
            /// </summary>
            [Description("کالا")]
            Product = 2,
            /// <summary>
            /// خدمات
            /// </summary>
            [Description("خدمات")]
            Service = 3

        }

        public enum AppType
        {
            /// <summary>
            /// زبان
            /// </summary>
            [Description("زبان")]
            Language = 0,
            /// <summary>
            /// دسته بندی بانکداری
            /// </summary>
            [Description("بانکداری")]
            CategoryBanking = 1,
            /// <summary>
            /// دسته بندی کالا
            /// </summary>
            [Description("دسته بندی کالا")]
            CategoryProduct = 2,
            /// <summary>
            /// دسته بندی خدمات
            /// </summary>
            [Description("دسته بندی خدمات")]
            CategoryService = 3,
            /// <summary>
            /// دسته بندی اشخاص
            /// </summary>
            [Description("دسته بندی اشخاص")]
            CategoryContact = 4,
            /// <summary>
            /// واحد مالی
            /// </summary>
            [Description("واحد مالی")]
            Currency = 5,
        }
    }
}
