
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
    		
    	[DisplayName("Listing Category Type Id")]
    	[Key]
        public int listingCategoryTypeId { get; set; }
    		
    	[DisplayName("Name")]
    	[StringLength(50)]
        public string name { get; set; }
    		
    	[DisplayName("Description")]
    	[StringLength(50)]
        public string description { get; set; }
    		
    	[DisplayName("Created By")]
        public int? createdBy { get; set; }
    		
    	[DisplayName("Modified By")]
        public int? modifiedBy { get; set; }
    		
    	[DisplayName("Created")]
    	[Required]
        public System.DateTime created { get; set; }
    		
    	[DisplayName("Modified")]
    	[Required]
        public System.DateTime modified { get; set; }
    		
    	[DisplayName("Active")]
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
