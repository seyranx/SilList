using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Models.ViewModels
{
    public class MemberVm
    {
        // public MemberVo member;
        public List<MemberVo> result { get; set; }
        public string keyword { get; set; }
        public int? pageNumber { get; set; }

        [DisplayName("Is Active: ")]
        public bool? filterIsActive { get; set; }

        public int totalCount { get; set; }

        public int skip
        {
            get
            {
                if (pageNumber == null || pageNumber < 2 || maxRowCount < 1)
                    return 0;

                return ((int)(pageNumber - 1) * maxRowCount);
            }
        }

        public int maxRowCount
        {
            get
            {
                return 3;
            }
        }
        public int pageCount
        {
            get
            {
                return (int)System.Math.Ceiling( (double)totalCount / maxRowCount);
            }
        }

        public string FromToTextOfPagination()
        {
            int fromNum = skip + 1;
            int toNum = skip + result.Count;
            return fromNum + "--" + toNum + " of " + totalCount;
        }

        // show up to 5 pages at a time
        const int pageRange = 5;
        public int FirstVisiblePage()
        {
            if (this.pageNumber == null)
                return 0;

            int blockNum = (int)System.Math.Ceiling((double)this.pageNumber.Value / pageRange);
            return (blockNum-1) * pageRange + 1;
        }

        public int LastVisiblePage()
        {
            if (this.pageNumber == null)
                return 0;

            return System.Math.Min(FirstVisiblePage() + pageRange - 1, this.pageCount);
        }

        public MemberVm()
        {
            this.result = new List<MemberVo>();
            // member = new MemberVo();
        }
        //public MemberVm(MemberVo memberVo)
        //{
        //    this.result = new List<MemberVo>();
        //    member = memberVo;
        //}
    }
}
