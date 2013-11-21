
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

        [DisplayName("Price")]
        public Nullable<int> price { get; set; }

        [DisplayName("Vin Number")]
        [StringLength(50)]
        public string vin { get; set; }

        [DisplayName("Description")]
        public string description { get; set; }

        [DisplayName("Address")]
        public string address { get; set; }

        [DisplayName("City")]
        public Nullable<int> cityTypeId { get; set; }

        [DisplayName("State")]
        public Nullable<int> stateTypeId { get; set; }

        [DisplayName("Country")]
        public Nullable<int> countryTypeId { get; set; }

        [DisplayName("Zip")]
        public Nullable<int> zip { get; set; }

        [DisplayName("Phone")]
        [StringLength(50)]
        public string phone { get; set; }

        [DisplayName("Fax")]
        [StringLength(50)]
        public string fax { get; set; }

        [DisplayName("Engine")]
        public Nullable<int> carEngineTypeId { get; set; }

        [DisplayName("Drive")]
        public Nullable<int> carDriveTypeId { get; set; }

        [DisplayName("Fuel")]
        public Nullable<int> carFuelTypeId { get; set; }

        [DisplayName("Door")]
        public Nullable<int> carDoorTypeId { get; set; }

        [DisplayName("Exterior Color")]
        public Nullable<int> exteriorColorTypeId { get; set; }

        [DisplayName("Interior Color")]
        public Nullable<int> interiorColorTypeId { get; set; }
    	
        [DisplayName("Start date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public System.DateTime startDate { get; set; }

        [DisplayName("End date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public System.DateTime endDate { get; set; }

        [DisplayName("Entry Status Type")]
        public Nullable<int> entryStatusTypeId { get; set; }

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

        [ForeignKey("modelTypeId")]
        public virtual ModelTypeVo modelType { get; set; }

        [ForeignKey("transmissionTypeId")]
        public virtual TransmissionTypeVo transmissionType { get; set; }

        [ForeignKey("siteId")]
        public virtual SiteVo site { get; set; }

        [ForeignKey("carBodyTypeId")]
        public virtual CarBodyTypeVo carBodyType { get; set; }
        
        [ForeignKey("carEngineTypeId")]
        public virtual CarEngineTypeVo carEngineType { get; set; }
        
        [ForeignKey("carDriveTypeId")]
        public virtual CarDriveTypeVo carDriveType { get; set; }
        
        [ForeignKey("carFuelTypeId")]
        public virtual CarFuelTypeVo carFuelType { get; set; }
        
        [ForeignKey("carDoorTypeId")]
        public virtual CarDoorTypeVo carDoorType { get; set; }
        
        [ForeignKey("exteriorColorTypeId")]
        public virtual CarColorTypeVo exteriorColorType { get; set; }
        
        [ForeignKey("interiorColorTypeId")]
        public virtual CarColorTypeVo interiorColorType { get; set; }
     
        [ForeignKey("countryTypeId")]
        public virtual CountryTypeVo countryType { get; set; }
                
        [ForeignKey("stateTypeId")]
        public virtual StateTypeVo stateType { get; set; }
                
        [ForeignKey("cityTypeId")]
        public virtual CityTypeVo cityType { get; set; }

        [ForeignKey("entryStatusTypeId")]
        public virtual EntryStatusTypeVo entryStatusType { get; set; }

        [Association("Car_CarImages", "carId", "carId", IsForeignKey = true)]
        public List<CarImagesVo> carImages { get; set; }

        [NotMapped]
        [DisplayName("Make")]
        public int? makeTypeId { get; set; }

    	public CarVo()
        {
    		this.carId = Guid.NewGuid();
    	    this.isActive = true;
    	}
    }
}
