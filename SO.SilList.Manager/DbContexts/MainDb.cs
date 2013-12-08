using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Utility.Base;
using SO.SilList.Manager.Models;


namespace SO.SilList.Manager.DbContexts
{
    public partial class MainDb : BaseDbContext
    {
        public MainDb()
            : base("name=MainDb")
        {
           // this.Configuration.LazyLoadingEnabled = false;
           // this.Configuration.ProxyCreationEnabled = false;
           

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<JobVo> jobs { get; set; }
        public DbSet<JobCategoriesVo> jobCategories { get; set; }
        public DbSet<JobCategoryTypeVo> jobCategoryTypes { get; set; }
        public DbSet<BusinessVo> businesses { get; set; }
        public DbSet<SiteVo> sites { get; set; }
        public DbSet<JobTypeVo> jobTypes { get; set; }

        public DbSet<PropertyVo> properties { get; set; }
        public DbSet<BedroomTypeVo> bedroomType { get; set; }
        public DbSet<BathroomTypeVo> bathroomType { get; set; }
        public DbSet<BusinessCategoryTypeVo> businessCategoryType { get; set; }
        public DbSet<PropertyListingTypeVo> propertyListingTypes { get; set; }
        
        public DbSet<PropertyTypeVo> propertyTypes { get; set; }
        public DbSet<PropertyImageVo> propertyImages { get; set; }

        public DbSet<SettingTypeVo> settingTypes { get; set; }
        public DbSet<EnvironmentTypeVo> environmentTypes { get; set; }
        
        public DbSet<RatingVo> rating { get; set; }
        public DbSet<BusinessRatingsVo> businessRatings { get; set; }
        public DbSet<BusinessCategoriesVo> businessCategories { get; set; }

        public DbSet<MemberVo> members { get; set; }
        public DbSet<ImageVo> images { get; set; }
        //public DbSet<ListingDetailVo> listingDetails { get; set; }

        public DbSet<ListingVo> listing { get; set; }
        public DbSet<ListingImagesVo> listingImages { get; set; }
        public DbSet<ListingTypeVo> listingType { get; set; }
        public DbSet<ListingCategoriesVo> listingCategories { get; set; }
        public DbSet<ListingCategoryTypeVo> listingCategoryType { get; set; }

        public DbSet<ServiceTypeVo> serviceTypes { get; set; }
        public DbSet<BusinessServicesVo> businessServices { get; set; }
        public DbSet<BusinessImagesVo> businessImages { get; set; }
        public DbSet<CarVo> car { get; set; }
        public DbSet<CarBodyTypeVo> carBodyType { get; set; }
        public DbSet<CarColorTypeVo> carColorType { get; set; }
        public DbSet<CarDoorTypeVo> carDoorType { get; set; }
        public DbSet<CarDriveTypeVo> carDriveType { get; set; }
        public DbSet<CarEngineTypeVo> carEngineType { get; set; }
        public DbSet<CarFuelTypeVo> carFuelType { get; set; }
        public DbSet<CountryTypeVo> countryType { get; set; }
        public DbSet<StateTypeVo> stateType { get; set; }
        public DbSet<CityTypeVo> cityType { get; set; }
        public DbSet<ModelTypeVo> modelType { get; set; }
        public DbSet<MakeTypeVo> makeType { get; set; }
        public DbSet<CarImagesVo> carImages { get; set; }
        public DbSet<TransmissionTypeVo> transmissionType { get; set; }
        public DbSet<AdminVo> admins { get; set; }
        public DbSet<VisitVo> visits { get; set; }

        public DbSet<EntryStatusTypeVo> entryStatusType { get; set; }
    }

}
