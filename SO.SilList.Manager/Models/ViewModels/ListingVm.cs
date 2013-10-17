using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Utility.Classes;
using System.Web;

namespace SO.SilList.Manager.Models.ViewModels
{
    public class ListingVm
    {
        public List<ListingVo> result { get; set; }
        public string keyword { get; set; }
        public int location { get; set; } //change int to 'string'
        public string locKeyword { get; set; } //change int to 'string'
        public string category { get; set; } //change int to 'string'
        public string type { get; set; } //change int to 'string'
        public bool titleOnly { get; set; }

        // Images
        public List<ImageCheckBoxInfo> imagesToRemove { get; set; }

        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }
        //  public int totalCount { get; set; }
        public string submitButton { get; set; }
        public Paging paging;

        public ListingVo listing { get; set; }

        public ListingVm()
        {
            //pageNumber = 1;
            listing = new ListingVo();
            this.result = new List<ListingVo>();
            if (paging == null)
                paging = new Paging();
        }

        public ListingVm(ListingVo input)
        {
            listing = input;
            this.result = new List<ListingVo>();
            if (paging == null)
                paging = new Paging();

            this.category = null;
            this.type = null;
        }

    }
}
