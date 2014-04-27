
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SO.SilList.Manager.Models.ValueObjects;
using SO.Utility.Base;

namespace SO.SilList.Manager.DbContexts
{
    public partial class MainDb : BaseDbContext
    {
        public MainDb()
            : base("name=MainDb")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);
        }
    
        public DbSet<BusinessCategoryTypeVo> businessCategoryTypes { get; set; }
        public DbSet<BusinessServiceTypeVo> businessServiceTypes { get; set; }
        public DbSet<CarMakeTypeVo> carMakeTypes { get; set; }
        public DbSet<CarModelTypeVo> carModelTypes { get; set; }
        public DbSet<CityTypeVo> cityTypes { get; set; }
        public DbSet<CountryTypeVo> countryTypes { get; set; }
        public DbSet<JobCategoryTypeVo> jobCategoryTypes { get; set; }
        public DbSet<JobTypeVo> jobTypes { get; set; }
        public DbSet<ListingCategoryTypeVo> listingCategoryTypes { get; set; }
        public DbSet<ListingStatusTypeVo> listingStatusTypes { get; set; }
        public DbSet<ListingTypeVo> listingTypes { get; set; }
        public DbSet<MemberRoleTypeVo> memberRoleTypes { get; set; }
        public DbSet<OptionTypeVo> optionTypes { get; set; }
        public DbSet<PropertyListingTypeVo> propertyListingTypes { get; set; }
        public DbSet<PropertyTypeVo> propertyTypes { get; set; }
        public DbSet<SettingTypeVo> settingTypes { get; set; }
        public DbSet<StateTypeVo> stateTypes { get; set; }
        public DbSet<BusinessVo> businesses { get; set; }
        public DbSet<BusinessCategoryLookupVo> businessCategoryLookups { get; set; }
        public DbSet<BusinessServiceLookupVo> businessServiceLookups { get; set; }
        public DbSet<CarVo> cars { get; set; }
        public DbSet<ImageVo> images { get; set; }
        public DbSet<JobVo> jobs { get; set; }
        public DbSet<JobCategoryLookupVo> jobCategoryLookups { get; set; }
        public DbSet<ListingVo> listings { get; set; }
        public DbSet<ListingCategoryLookupVo> listingCategoryLookups { get; set; }
        public DbSet<MemberVo> members { get; set; }
        public DbSet<MemberRoleLookupVo> memberRoleLookups { get; set; }
        public DbSet<PropertyVo> properties { get; set; }
        public DbSet<RatingVo> ratings { get; set; }
        public DbSet<webpages_MembershipsVo> webpages_Memberships { get; set; }
    }
}
