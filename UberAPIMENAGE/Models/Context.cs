using Microsoft.EntityFrameworkCore;

namespace UberAPIMENAGE.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt):base(opt) { }

       public DbSet<Ride> rides {  get; set; } 
       public DbSet<Payment> payments {  get; set; } 
       public DbSet<User> users {  get; set; } 
       public DbSet<Vehicle> vehicles {  get; set; } 
       public DbSet<Rating> ratings {  get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(i => i.Vehicle).WithOne(i => i.Driver).HasForeignKey<Vehicle>(o => o.DriverId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Ride>().HasOne(i => i.Payment).WithOne(i => i.Ride).HasForeignKey<Payment>(o => o.RideId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Ride>().HasOne(i => i.Rating).WithOne(i => i.Ride).HasForeignKey<Rating>(o => o.RideId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany(o => o.DriverUser).WithOne(o => o.Driver).HasForeignKey(i => i.DriverId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasMany(o => o.RiderUser).WithOne(o => o.Rider).HasForeignKey(i => i.RiderId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FullName = "Admin User",
                Email = "admin@uber.com",
                Password = "AdminPassword123!", 
                Phone = "+201000000001",
                Role = "Admin"
            },
            new User
            {
                Id = 2,
                FullName = "John Driver",
                Email = "john.driver@gmail.com",
                Password = "DriverPassword123!",
                Phone = "+201000000002",
                Role = "Driver"
            },
            new User
            {
                Id = 3,
                FullName = "Alice Rider",
                Email = "alice.rider@gmail.com",
                Password = "RiderPassword123!",
                Phone = "+201000000003",
                Role = "Rider"
            }
        );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Id = 1,
                    PlateNumber = "ABC-1234",
                    Color = "Black",
                    DriverId = 2
                }
            );

            modelBuilder.Entity<Ride>().HasData(
                new Ride
                {
                    Id = 1,
                    PickupLocation = "Downtown Mall, Cairo",
                    DropOffLocation = "Cairo International Airport",
                    Fare = 250,
                    Status = "Completed",
                    RiderId = 3,
                    DriverId = 2
                }
            );

            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = 1,
                    Amount = 250,
                    PaymentMethod = "CreditCard",
                    PaymentDate = new DateTime(2026, 10, 14, 10, 30, 0),
                    Status = "Successful",
                    RideId = 1
                }
            );
  
            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    Id = 1,
                    Score = 5,
                    Comments = "Great driving and very polite driver!",
                    RideId = 1
                }
            );
        }
    }
}
