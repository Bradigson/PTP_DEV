using System.Collections.Generic;
using System.Web.Mvc;

namespace DataLayer.ViewModels
{
    public class SetProductPriceByNumber
    {
        public SetProductPriceByNumber()
        {
            Options = new List<SelectListItem>
            {
                new SelectListItem{Value = "1",Text = "1"},
                new SelectListItem{Value = "2",Text = "2"},
                new SelectListItem{Value = "3",Text = "3"}
            };
        }
        public int PriceOption { get; set; }
        public List<SelectListItem> Options { get; set; }
    }
}
