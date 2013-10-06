using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Utility.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.SilList.Manager.Models.ViewModels
{
    public class RentalVm
    {
        public List<RentalVo> result { get; set; }
        public string keyword { get; set; }
        public int? pageNumber { get; set; }
        public string location { get; set; }

        [DisplayName("isActive: ")]
        public bool? isActive { get; set; }

        public Paging paging;

        public RentalVo listing { get; set; }

        public RentalVm()
        {

            listing = new RentalVo();
            this.result = new List<RentalVo>();
            if (paging == null)
                paging = new Paging();
        }

        public RentalVm(RentalVo input)
        {
            listing = input;
            this.result = new List<RentalVo>();
            if (paging == null)
                paging = new Paging();
        }

        public int skip
        {
            get
            {
                if (pageNumber == null || pageNumber < 2 || rowCount < 1)
                    return 0;
                return ((int)(pageNumber - 1) * (int)rowCount);
            }
        }

        public int rowCount
        {
            get
            {
                return 30;
            }
        }
    }
}
