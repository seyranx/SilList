
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
     
    [Table("Car", Schema = "data" )]
    [Serializable]
    public partial class CarVo
    {
    		
    	[DisplayName("car")]
    	[Key]
        public System.Guid carId { get; set; }
    		
    	[DisplayName("model")]
        public Nullable<int> modelTypeId { get; set; }
    		
    	[DisplayName("year")]
        public Nullable<int> year { get; set; }
    		
    	[DisplayName("millage")]
        public Nullable<int> millage { get; set; }
    		
    	[DisplayName("body")]
        public Nullable<int> carBodyTypeId { get; set; }
    		
    	[DisplayName("site")]
        public Nullable<int> siteId { get; set; }
    		
    	[DisplayName("transmission")]
        public Nullable<int> transmissionTypeId { get; set; }

        [DisplayName("start date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public System.DateTime startDate { get; set; }

        [DisplayName("end date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public System.DateTime endDate { get; set; }

        [DisplayName("approved")]
        public bool isApproved { get; set; }

    	[DisplayName("created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("created by")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("modified by")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("active")]
        public bool isActive { get; set; }

        [Association("Car_CarImages", "carId", "carId", IsForeignKey = true)]
        public List<CarImagesVo> carImages { get; set; }

        [ForeignKey("modelTypeId")]
        public virtual ModelTypeVo modelType { get; set; }

        [ForeignKey("transmissionTypeId")]
        public virtual TransmissionTypeVo transmissionType { get; set; }

        [ForeignKey("siteId")]
        public virtual SiteVo site { get; set; }

        [ForeignKey("carBodyTypeId")]
        public virtual CarBodyTypeVo carBodyType { get; set; }

    	public CarVo(){
    			
    		this.carId = Guid.NewGuid();
    	
    	 this.isActive = true;
    	}
    }
}
