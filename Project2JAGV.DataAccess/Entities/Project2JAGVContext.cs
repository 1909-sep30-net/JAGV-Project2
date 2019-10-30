using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Project2JAGVContext : DbContext
    {
        public Project2JAGVContext()
        {

        }

        public Project2JAGVContext(DbContextOptions<Project2JAGVContext> options) : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<IngredientTypes> IngredientTypes { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PizzaDelivery> PizzaDeliveries { get; set; }
        public virtual DbSet<PizzaIngredients> PizzaIngredients { get; set; }
        public virtual DbSet<Pizzas> Pizzas { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.Property(e => e.Street).IsRequired();
                entity.Property(e => e.State).IsRequired();
                entity.Property(e => e.ZipCode).IsRequired();
            });

            modelBuilder.Entity<Drivers>(entity =>
            {
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.Property(e => e.TypeId).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<IngredientTypes>(entity =>
            {
                entity.Property(e => e.Type).IsRequired();
            });

            modelBuilder.Entity<Logins>(entity =>
            {
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.UserPassword).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Admin).IsRequired();
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Date).IsRequired();
            });

            modelBuilder.Entity<PizzaDelivery>(entity =>
            {
              
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasOne<Addresses>(e => e.Address)
                    .WithMany(a => a.Users)
                    .HasForeignKey(e => e.AddressId);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.State)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.ZipCode)
                .IsRequired()
                .HasMaxLength(50);
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
