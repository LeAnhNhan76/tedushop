﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TeduShop.Common.Constants;
using TeduShop.Model.Models;

namespace TeduShop.Data
{
    public class TeduShopDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Constructors

        public TeduShopDbContext() : base(Constant.ConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static TeduShopDbContext Create()
        {
            return new TeduShopDbContext();
        }

        #endregion Constructors

        #region Entities

        public DbSet<Footer> Footers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationGroup> ApplicationGroups { get; set; }
        public DbSet<ApplicationRoleGroup> ApplicationRoleGroups { get; set; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroups { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        #endregion Entities

        #region Methods

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable(Constant.Table_ApplicationUserRoles);
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable(Constant.Table_ApplicationUserLogins);
            builder.Entity<IdentityRole>().ToTable(Constant.Table_ApplicationRoles);
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable(Constant.Table_ApplicationUserClaims);
        }

        #endregion Methods
    }
}