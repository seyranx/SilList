using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SO.SilList.Manager.Models.ValueObjects
{
    [Table("Visit", Schema = "data")]
    [Serializable]
    public class VisitVo
    {
        [DisplayName("Visit Id")]
        [Key]
        public Guid visitId { get; set; }

        [DisplayName("Site Id")]
        public int siteId { get; set; }

        [DisplayName("IP Address")]
        public string ipAddress { get; set; }

        [DisplayName("Referrer URL")]
        public string referrerUrl { get; set; }

        [DisplayName("Visit Time")]
        public DateTime visitTime { get; set; }

        [DisplayName("Browser")]
        public string browser { get; set; }

        [DisplayName("Controller")]
        public string controller { get; set; }

        [DisplayName("Action")]
        public string action { get; set; }

        [DisplayName("Site")]
        [ForeignKey("siteId")]
        public virtual SiteVo site { get; set; }

        public VisitVo()
        {
            this.visitId = Guid.NewGuid();
        }
    }
}
