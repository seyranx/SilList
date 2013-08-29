
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
    		
    	[DisplayName("Car")]
    	[Key]
        public System.Guid carId { get; set; }
    		
    	[DisplayName("Model")]
        public Nullable<int> modelTypeId { get; set; }
    		
    	[DisplayName("Year")]
        public Nullable<int> year { get; set; }
    		
    	[DisplayName("Millage")]
        public Nullable<int> millage { get; set; }
    		
    	[DisplayName("Body")]
        public Nullable<int> carBodyTypeId { get; set; }
    		
    	[DisplayName("Site")]
        public Nullable<int> siteId { get; set; }
    		
    	[DisplayName("Transmission")]
        public Nullable<int> transmissionTypeId { get; set; }

        [DisplayName("Start date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public System.DateTime startDate { get; set; }

        [DisplayName("End date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public System.DateTime endDate { get; set; }

        [DisplayName("Approved")]
        public bool isApproved { get; set; }

    	[DisplayName("Created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("Modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("Created By")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("Modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("Active")]
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


        [NotMapped]
        [DisplayName("Make")]
        public int? makeTypeId { get; set; }


    	public CarVo(){
    			
    		this.carId = Guid.NewGuid();

            this.isApproved = false;    	
    	    this.isActive = true;
    	}
    }
}
