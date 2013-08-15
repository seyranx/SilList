
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
     
    [Table("ListingCategoryType", Schema = "app" )]
    [Serializable]
    public partial class ListingCategoryTypeVo
    {
    		
    	[DisplayName("listing Category Type Id")]
    	[Key]
        public int listingCategoryTypeId { get; set; }
    		
    	[DisplayName("name")]
    	[StringLength(50)]
        public string name { get; set; }
    		
    	[DisplayName("description")]
    	[StringLength(50)]
        public string description { get; set; }
    		
    	[DisplayName("created By")]
        public int? createdBy { get; set; }
    		
    	[DisplayName("modified By")]
        public int? modifiedBy { get; set; }
    		
    	[DisplayName("created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("is Active")]
    	[Required]
        public bool isActive { get; set; }

        //[Association("ListingCategories_ListingCategoryType", "listingCategoryTypeId", "listingCategoryTypeId", IsForeignKey = true)]
        //public List<ListingCategoriesVo> listingCategories { get; set; }
      
    	public ListingCategoryTypeVo()
        {
    			this.isActive = true;
    	}
    }
}
