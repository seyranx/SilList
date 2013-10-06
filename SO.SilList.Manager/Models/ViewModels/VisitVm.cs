using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Utility.Classes;

namespace SO.SilList.Manager.Models.ViewModels
{
    public class VisitVm
    {
        public List<VisitVo> result { get; set; }
        public string submitButton { get; set; }
        public Paging paging;

        public int totalRows { get; set; }

        [DisplayName("Keyword: ")]
        public string keyword { get; set; }

        [DisplayName("Site: ")]
        public Nullable<int> siteId { get; set; }

        [ForeignKey("siteId")]
        public SiteVo site { get; set; }

        public string btnSearch { get; set; }

      

        public VisitVm()
        {
            this.result = new List<VisitVo>();
          
            if (paging == null)
                paging = new Paging();
        
        }
    }
}
