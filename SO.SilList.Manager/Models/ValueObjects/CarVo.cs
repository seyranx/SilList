
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
    		
    	[DisplayName("CAR")]
    	[Key]
        public System.Guid carId { get; set; }
    		
    	[DisplayName("MODEL")]
        public Nullable<int> modelTypeId { get; set; }
    		
    	[DisplayName("YEAR")]
        public Nullable<int> year { get; set; }
    		
    	[DisplayName("MILLAGE")]
        public Nullable<int> millage { get; set; }
    		
    	[DisplayName("BODY")]
        public Nullable<int> carBodyTypeId { get; set; }
    		
    	[DisplayName("SITE")]
        public Nullable<int> siteId { get; set; }
    		
    	[DisplayName("TRANSMISSION")]
        public Nullable<int> transmissionTypeId { get; set; }

        [DisplayName("START DATE")]
        [Required]
        public System.DateTime startDate { get; set; }

        [DisplayName("END DATE")]
        [Required]
        public System.DateTime endDate { get; set; }

        [DisplayName("APPROVED")]
        public bool isApproved { get; set; }

    	[DisplayName("CREATED")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("MODIFIED")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("CREATED BY")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("MODIFIED BY")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("ACTIVE")]
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
