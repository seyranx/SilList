using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Models.ViewModels
{
    public class ListingVm
    {
        public List<ListingVo> result { get; set; }
        public string keyword { get; set; }
        public int? pageNumber { get; set; }
        public int? resultCount { get; set; }

        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }

        public int skip {
            get
            {
                if (pageNumber == null || pageNumber < 2 || rowCount < 1) return 0;

                return ( (int)(pageNumber-1) * (int)rowCount);
            }
        }

        public  int rowCount { 
               get{
                   return 4; // fix
               }
        }

        public ListingVm()
        {
            this.result = new List<ListingVo>();
        }

        // added this, but doesn't help
        public ListingVm(int pageNumber, string keyword, bool isActive)
        {
            this.keyword = keyword;
            this.pageNumber = pageNumber;
            this.isActive = isActive;
            this.result = new List<ListingVo>();
        }

    }
}
