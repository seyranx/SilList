
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
    		
    	[DisplayName("car Id")]
    	[Key]
        public System.Guid carId { get; set; }
    		
    	[DisplayName("model Type Id")]
        public Nullable<int> modelTypeId { get; set; }
    		
    	[DisplayName("year")]
        public Nullable<int> year { get; set; }
    		
    	[DisplayName("millage")]
        public Nullable<int> millage { get; set; }
    		
    	[DisplayName("car Body Type Id")]
        public Nullable<int> carBodyTypeId { get; set; }
    		
    	[DisplayName("site Id")]
        public Nullable<int> siteId { get; set; }
    		
    	//[DisplayName("listing Detail Id")]
        //public Nullable<System.Guid> listingDetailId { get; set; }
    		
    	[DisplayName("transmission Type Id")]
        public Nullable<int> transmissionTypeId { get; set; }

        [DisplayName("start Date")]
        [Required]
        public System.DateTime startDate { get; set; }

        [DisplayName("end Date")]
        [Required]
        public System.DateTime endDate { get; set; }

        [DisplayName("is Approved")]
        public bool isApproved { get; set; }
    		
    	[DisplayName("created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    		
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    		
    	[DisplayName("is Active")]
        public Nullable<bool> isActive { get; set; }

        //[Association("Car_CarImages", "carId", "carId", IsForeignKey = true)]
        //public List<CarImagesVo> carImages { get; set; }

        //[ForeignKey("modelTypeId")]
        //public virtual ModelTypeVo modelType { get; set; }

        //[ForeignKey("transmissionTypeId")]
        //public virtual TransmissionTypeVo transmissionType { get; set; }

        //[ForeignKey("listingDetailId")]
        //public virtual ListingDetailVo listingDetail { get; set; }

        //[ForeignKey("siteId")]
        //public virtual SiteVo site { get; set; }

        //[ForeignKey("carBodyTypeId")]
        //public virtual CarBodyTypeVo carBodyType { get; set; }

    	public CarVo(){
    			
    		this.carId = Guid.NewGuid();
            this.isApproved = false;    	
    	    this.isActive = true;
    	}
    }
}
