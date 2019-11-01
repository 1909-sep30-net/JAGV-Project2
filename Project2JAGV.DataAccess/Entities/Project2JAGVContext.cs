using Microsoft.EntityFrameworkCore;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Project2JAGVContext : DbContext
    {
        public Project2JAGVContext()
        {

        }
        public Project2JAGVContext(DbContextOptions<Project2JAGVContext> options) : base(options) { }
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<IngredientTypes> IngredientTypes { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PizzaIngredients> PizzaIngredients { get; set; }
        public virtual DbSet<Pizzas> Pizzas { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserTypes> UserTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.Property(e => e.Street).IsRequired().HasMaxLength(50);
                entity.Property(e => e.City).IsRequired();
                entity.Property(e => e.State).IsRequired();
                entity.Property(e => e.ZipCode).IsRequired();
            });
            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.Property(e => e.TypeId).IsRequired();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Price).HasColumnType("money");
            });
            modelBuilder.Entity<IngredientTypes>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<Logins>(entity =>
            {
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.UserPassword).IsRequired().HasMaxLength(50);
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.UserTypeId).IsRequired();
            });
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.Date).IsRequired();
            });
            modelBuilder.Entity<PizzaIngredients>(entity =>
            {
                entity.Property(e => e.PizzaId).IsRequired();
                entity.Property(e => e.IngredientId).IsRequired();
            });
            modelBuilder.Entity<Pizzas>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.AddressId).IsRequired();
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
            });
            modelBuilder.Entity<UserTypes>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
