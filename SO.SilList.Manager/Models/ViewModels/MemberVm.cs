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
        public MemberVo member;
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
                return totalCount / maxRowCount + 1;
            }
        }

        public MemberVm()
        {
            this.result = new List<MemberVo>();
            member = new MemberVo();
        }
        public MemberVm(MemberVo memberVo)
        {
            this.result = new List<MemberVo>();
            member = memberVo;
        }
    }
}
