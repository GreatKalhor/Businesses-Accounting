using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.SvgIcons;

namespace Businesses_Accounting.Models.ViewModels
{
    public class ItemViewModel
    {
        public ItemViewModel()
        {
                
        }
        public ItemViewModel(Account x)
        {
            Value = x.Id;
            Text = x.Name;
            bool _hasChildren= x.InverseParent.Count() > 0;
            HasChildren = _hasChildren;
            if (_hasChildren)
            {
                Items = new List<ItemViewModel>(x.InverseParent.Select(v => new ItemViewModel(v)));
            }
            ParentId = x.ParentId!=null?x.ParentId:0;
        }
      
        public int Value { get; set; }

        public string Text { get; set; }

        public int?  ParentId { get; set; }

        public bool HasChildren { get; set; }
        public bool expanded { get; set; }

        public IEnumerable<ItemViewModel> Items { get; set; }   
    }
}