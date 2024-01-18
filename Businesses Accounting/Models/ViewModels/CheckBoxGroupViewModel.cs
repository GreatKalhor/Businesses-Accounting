using Kendo.Mvc.UI;

namespace Businesses_Accounting.Models.ViewModels
{
    public class CheckBoxGroupViewModel
    {
        public List<IInputGroupItem> Items { get; set; }
        public string[] CheckBoxGroupValue { get; set; }
    }
    public class InputGroupItemModel : IInputGroupItem
    {
        public IDictionary<string, object> HtmlAttributes { get; set; }

        public string CssClass { get; set; }

        public bool? Enabled { get; set; }

        public bool? Encoded { get; set; }

        public string Label { get; set; }

        public string Value { get; set; }
    }
}
