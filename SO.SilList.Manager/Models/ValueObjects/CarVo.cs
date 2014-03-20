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
    public  class CarVo
    {
    
          
    	[DisplayName("car Id")]
    	[Required]
    	[Key]
        public Guid carId { get; set; }
    
    	[DisplayName("car Model Type Id")]
        public Nullable<int> carModelTypeId { get; set; }
    
    	[DisplayName("year")]
        public Nullable<int> year { get; set; }
    
    	[DisplayName("millage")]
        public Nullable<int> millage { get; set; }
    
    	[DisplayName("price")]
        public Nullable<int> price { get; set; }
    
    	[DisplayName("vin")]
    	[StringLength(50)]
        public string vin { get; set; }
    
    	[DisplayName("description")]
        public string description { get; set; }
    
    	[DisplayName("address")]
        public string address { get; set; }
    
    	[DisplayName("city Type Id")]
        public Nullable<int> cityTypeId { get; set; }
    
    	[DisplayName("state Type Id")]
        public Nullable<int> stateTypeId { get; set; }
    
    	[DisplayName("country Type Id")]
        public Nullable<int> countryTypeId { get; set; }
    
    	[DisplayName("zip")]
        public Nullable<int> zip { get; set; }
    
    	[DisplayName("body Option Type Id")]
        public Nullable<int> bodyOptionTypeId { get; set; }
    
    	[DisplayName("transmission Option Type Id")]
        public Nullable<int> transmissionOptionTypeId { get; set; }
    
    	[DisplayName("engine Option Type Id")]
        public Nullable<int> engineOptionTypeId { get; set; }
    
    	[DisplayName("drive Option Type Id")]
        public Nullable<int> driveOptionTypeId { get; set; }
    
    	[DisplayName("fuel Option Type Id")]
        public Nullable<int> fuelOptionTypeId { get; set; }
    
    	[DisplayName("door Option Type Id")]
        public Nullable<int> doorOptionTypeId { get; set; }
    
    	[DisplayName("exterior Color Option Type Id")]
        public Nullable<int> exteriorColorOptionTypeId { get; set; }
    
    	[DisplayName("interior Color Option Type Id")]
        public Nullable<int> interiorColorOptionTypeId { get; set; }
    
    	[DisplayName("start Date")]
    	[Required]
        public DateTime startDate { get; set; }
    
    	[DisplayName("end Date")]
    	[Required]
        public DateTime endDate { get; set; }
    
    	[DisplayName("listing Status Type Id")]
        public Nullable<int> listingStatusTypeId { get; set; }
    
    	[DisplayName("created")]
    	[Required]
        public DateTime created { get; set; }
    
    	[DisplayName("modified")]
    	[Required]
        public DateTime modified { get; set; }
    
    	[DisplayName("created By")]
        public Nullable<int> createdBy { get; set; }
    
    	[DisplayName("modified By")]
        public Nullable<int> modifiedBy { get; set; }
    
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }
    
    
        [ForeignKey("carModelTypeId")]
        public CarModelTypeVo carModelType { get; set; }
       
        [ForeignKey("cityTypeId")]
        public CityTypeVo cityType { get; set; }
       
        [ForeignKey("countryTypeId")]
        public CountryTypeVo countryType { get; set; }
       
        [ForeignKey("listingStatusTypeId")]
        public ListingStatusTypeVo listingStatusType { get; set; }
       
        [ForeignKey("stateTypeId")]
        public StateTypeVo stateType { get; set; }
       
      public CarVo()
            {
    				this.carId = Guid.NewGuid();
    				this.isActive = true;
            }
    
    }
    
}
