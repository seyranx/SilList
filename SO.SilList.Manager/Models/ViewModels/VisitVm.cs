using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Manager.Models.ViewModels
{
    public class VisitVm
    {
        public List<VisitVo> result { get; set; }

        [DisplayName("Keyword: ")]
        public string keyword { get; set; }

        [DisplayName("Page: ")]
        public int pageNumber { get; set; }

        public int skip {
            get
            {
                if (pageNumber == null || pageNumber < 2 || rowsPerPage < 1) 
                    return 0;

                return ( (pageNumber-1) * rowsPerPage );
            }
        }

        [DisplayName("Rows per page: ")]
        [Range(5, 10)]
        public int rowsPerPage { get; set; }

        [DisplayName("Total rows: ")]
        public int totalRows { get; set; }


        public VisitVm()
        {
            this.result = new List<VisitVo>();
            this.pageNumber = 1;
            this.rowsPerPage = 5;

        }
    }
}
