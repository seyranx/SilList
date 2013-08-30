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

        [DisplayName("Rows per page: ")]
        [Range(5, 50)]
        public int rowsPerPage { get; set; }

        public int totalRows { get; set; }

        [DisplayName("Show Page Links: ")]
        [Range(2, 5)]
        public int pageLinkCount { get; set; }

        public int skip 
        {
            get
            {
                return (pageNumber - 1) * rowsPerPage;
            }
        }

        public int firstVisibleRow 
        {
            get
            {
                return (totalRows > 0 ? (pageNumber - 1) * rowsPerPage + 1 : 0);
            }
        }

        public int lastVisibleRow 
        {
            get
            {
                return Math.Min(pageNumber * rowsPerPage, totalRows);
            }
        }

        public int totalPages
        {
            get
            {
                return (int)Math.Ceiling((double)totalRows / rowsPerPage);
            }
        }


        public VisitVm()
        {
            this.result = new List<VisitVo>();
            this.rowsPerPage = 10;
            this.pageLinkCount = 2;
            this.pageNumber = 1;
        }
    }
}
