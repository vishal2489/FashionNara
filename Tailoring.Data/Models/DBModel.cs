namespace Tailoring.Data.DB {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public class TailoringContext: DbContext {
        // Your context has been configured to use a 'DBModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Tailoring.Data.DB.DBModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DBModel' 
        // connection string in the application configuration file.

        //public TailoringContext(string connectionName) : base(connectionName) {
        //}

        public TailoringContext(): base("TailorDb") {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<ProductOption> ProductOption { get; set; }
        public virtual DbSet<OptionType> OptionType { get; set; }
        public virtual DbSet<RequestOrder> RequestOrder { get; set; }
        public virtual DbSet<TimeSlot> TimeSlot { get; set; }
        public virtual DbSet<User> User { get; set; }
    }

    public class Product {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public int PriceId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; } //product image url
        public bool IsAcive { get; set; }

        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; set; }
        [ForeignKey("PriceId")]
        public Price Price { get; set; }

        public ICollection<ProductOption> ProductOptions { get; set; }
        public ICollection<RequestOrder> RequestOrders { get; set; }

        public Models.Product ToDomainProduct() {
            return new Models.Product() {
                Description = this.Description,
                Id = this.Id,
                ImageUrl = this.ImageUrl,
                Price = this.Price.Amount,
                ProductCategory = this.ProductCategory.Description
            };
        }
    }

    public class ProductCategory {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; }
    }

    public class Price {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public float Amount { get; set; }
        public Nullable<DateTime> EffectiveDate { get; set; }
        public Nullable<DateTime> ExpireDate { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<ProductOption> ProductOptions { get; set; }
    }

    public class ProductOption {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OptionTypeId { get; set; }
        public int PriceId { get; set; }
        public bool IsDefaultWithProduct { get; set; }
        public bool IsFree { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; } //SVC URL
        public Nullable<int> SortOrder { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("OptionTypeId")]
        public OptionType OptionType { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("PriceId")]
        public Price Price { get; set; }

        public ICollection<RequestSize> RequestSizes { get; set; }
    }
    public class OptionType {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }

        public ICollection<ProductOption> ProductOptions { get; set; }
    }

    public class RequestOrder {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long UserId { get; set; }
        public int ProductId { get; set; }
        public RequestState State { get; set; }
        
        public Nullable<int> TimeSlotId { get; set; }
        public Nullable<DateTime> ScheduleDate { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("TimeSlotId")]
        public TimeSlot TimeSlot { get; set; }

        public ICollection<RequestSize> RequestSizes { get; set; }
    }


    public class RequestSize {
        [Key, Column(Order = 0)]
        public int RequestOrderId { get; set; }
        [Key, Column(Order = 1)]
        public int ProductOptionsId { get; set; }

        public RequestOrder RequestOrder { get; set; }
        public ProductOption ProductOption { get; set; }
    }

    public class TimeSlot {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; } //like 9-10, 10-11 etc.
        public bool IsActive { get; set; }
    }

    public enum RequestState {
        PickupSchedule = 1,
        PickupComplete = 2,
        AtBotique = 3,
        ReceivedFromBotique = 4,
        DeliveredToCustomer = 5
    }

    public class User {
        [Key]
        public long MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<RequestOrder> RequestOrders { get; set; }
    }
}