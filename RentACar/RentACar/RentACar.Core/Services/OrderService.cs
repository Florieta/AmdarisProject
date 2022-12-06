using Microsoft.EntityFrameworkCore;
using RentACar.Core.ViewModels.Booking;
using RentACar.Infrastructure.Data.Common;
using RentACar.Infrastructure.Entitites;
using RentACar.Infrastructure.Entitites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Services
{
    public class OrderService
    {
        private readonly IRepository repo;

        public OrderService(IRepository repo)
        {
            this.repo = repo;

        }

        public async Task Create(OrderFormViewModel model, int Id, string userId)
        {
            var user = await repo.All<ApplicationUser>()
                .Where(u => u.Id == userId)
                .Include(b => b.Orders)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var car = await repo.GetByIdAsync<Car>(Id);

            if (car == null)
            {
                throw new ArgumentException("Invalid car ID");
            }

            car.IsAvailable = false;

            if (model.PickUpDateAndTime > model.DropOffDateAndTime)
            {
                throw new ArgumentException("The pick up date cannot be greater than the drop off date!");
            }


            var order = new Order()
            {
                CarId = Id,
                Car = car,
                PickUpDateAndTime = model.PickUpDateAndTime,
                DropOffDateAndTime = model.DropOffDateAndTime,
                Duration = model.Duration,
                PickUpLocationId = model.PickUpLocationId,
                DropOffLocationId = model.DropOffLocationId,
                InsuranceCode = model.InsuranceCode,
                TotalAmount = model.TotalAmount,
                PaymentType = model.PaymentType,
                ApplicationUserId = userId,
                IsActive = true,
                IsPaid = false
            };


            await repo.AddAsync<Order>(order);
            await repo.SaveChangesAsync();
        }

      

        public async Task<OrderDetailsViewModel> OrderDetailsById(int id)
        {
            return await repo.AllReadonly<Order>()
                .Where(b => b.IsActive)
                .Where(b => b.Id == id)
                .Select(b => new OrderDetailsViewModel()
                {
                    PickUpDateAndTime = b.PickUpDateAndTime,
                    DropOffDateAndTime = b.DropOffDateAndTime,
                    Duration = b.Duration,
                    PaymentType = b.PaymentType,
                    TotalAmount = b.TotalAmount,
                    PickUpLocationName = b.PickUpLocation.LocationName,
                    DropOffLocationName = b.DropOffLocation.LocationName,
                    FirstName = b.ApplicationUser.FirstName,
                    LastName = b.ApplicationUser.LastName,
                    Address = b.ApplicationUser.Address,
                    PhoneNumber = b.ApplicationUser.PhoneNumber,
                    Email = b.ApplicationUser.Email,
                    DrivingLicenseNumber = b.ApplicationUser.DrivingLicenseNumber,
                    Model = b.Car.Model,
                    Make = b.Car.Make,
                    RegNumber = b.Car.RegNumber,
                    MakeYear = b.Car.MakeYear,
                    ImageUrl = b.Car.ImageUrl

                })
                .FirstAsync();
        }

        //public async Task Edit(int id, EditOrderViewModel model)
        //{
        //    var order = await repo.GetByIdAsync<Order>(id);

        //    order.Id = id;
        //    order.ApplicationUser.FirstName = model.FirstName;
        //    order.ApplicationUser.LastName = model.LastName;
        //    order.ApplicationUser.Address = model.Address;
        //    order.ApplicationUser.PhoneNumber = model.PhoneNumber;
        //    order.ApplicationUser.Email = model.Email;
        //    order.ApplicationUser.DrivingLicenseNumber = model.DrivingLicenseNumber;
        //    order.PickUpDateAndTime = model.PickUpDateAndTime;
        //    order.DropOffDateAndTime = model.DropOffDateAndTime;
        //    order.Duration = model.Duration;
        //    order.PickUpLocationId = model.PickUpLocationId;
        //    order.DropOffLocationId = model.DropOffLocationId;
        //    order.InsuranceCode = model.InsuranceCode;
        //    order.TotalAmount = model.TotalAmount;
        //    order.PaymentType = model.PaymentType;
        //    order.Car.Make = model.Make;
        //    order.Car.Model = model.Model;
        //    order.Car.MakeYear = model.MakeYear;
        //    order.Car.RegNumber = model.RegNumber;
        //    order.Car.Model = model.Model;


        //    await repo.SaveChangesAsync();
        //}

        //public async Task<IEnumerable<AllBookingsViewModel>> GetAllBookingsAsync(string? searchTerm = null)
        //{
        //    var all = repo.AllReadonly<Booking>().Where(x => x.IsActive == true);

        //    if (string.IsNullOrEmpty(searchTerm) == false)
        //    {
        //        var searchTerm1 = DateTime.Parse(searchTerm).Date;
        //        all = all.Where(b => b.PickUpDateAndTime.Date == searchTerm1);
        //    }

        //    return await all
        //        .Select(m => new AllBookingsViewModel()
        //        {
        //            Id = m.Id,
        //            CarId = m.CarId,
        //            FullName = m.Customer.FullName,
        //            PickUpDateAndTime = m.PickUpDateAndTime,
        //            DropOffDateAndTime = m.DropOffDateAndTime,
        //            TotalAmount = m.TotalAmount,
        //            IsRented = m.IsRented
        //        }).OrderBy(t => t.PickUpDateAndTime).ToListAsync();
        //}

        //public async Task<IEnumerable<AllBookingsViewModel>> AllCheckIns(string? searchTerm = null)
        //{
        //    var bookings = repo.AllReadonly<Booking>()
        //        .Where(b => b.IsActive == true && b.IsPaid == false && b.IsRented == false);


        //    if (string.IsNullOrEmpty(searchTerm) == false)
        //    {
        //        var searchTerm1 = DateTime.Parse(searchTerm).Date;
        //        bookings = bookings.Where(b => b.PickUpDateAndTime.Date == searchTerm1);
        //    }

        //    var result = await bookings
        //        .Select(b => new AllBookingsViewModel()
        //        {
        //            Id = b.Id,
        //            PickUpDateAndTime = b.PickUpDateAndTime,
        //            DropOffDateAndTime = b.DropOffDateAndTime,
        //            TotalAmount = b.TotalAmount,
        //            FullName = b.Customer.FullName,
        //        })
        //        .OrderBy(t => t.PickUpDateAndTime)
        //        .ToListAsync();

        //    return result;
        //}

        //public async Task<IEnumerable<AllBookingsViewModel>> AllCheckOuts(string? searchTerm = null)
        //{
        //    var bookings = repo.AllReadonly<Booking>()
        //        .Where(b => b.IsActive && b.IsPaid == true && b.IsRented == true);


        //    if (string.IsNullOrEmpty(searchTerm) == false)
        //    {
        //        var searchTerm1 = DateTime.Parse(searchTerm).Date;
        //        bookings = bookings.Where(b => b.DropOffDateAndTime.Date == searchTerm1);
        //    }

        //    var result = await bookings
        //        .Select(b => new AllBookingsViewModel()
        //        {
        //            Id = b.Id,
        //            PickUpDateAndTime = b.PickUpDateAndTime,
        //            DropOffDateAndTime = b.DropOffDateAndTime,
        //            TotalAmount = b.TotalAmount,
        //            FullName = b.Customer.FullName,
        //        })
        //        .OrderBy(t => t.DropOffDateAndTime)
        //        .ToListAsync();

        //    return result;
        //}

        //public async Task<IEnumerable<Location>> GetLocationsAsync()
        //{
        //    return await repo.AllReadonly<Location>()
        //        .ToListAsync();
        //}

        //public async Task<IEnumerable<Insurance>> GetInsurancesAsync()
        //{
        //    return await repo.AllReadonly<Insurance>()
        //        .ToListAsync();
        //}

        //public async Task<bool> Exists(int id)
        //{
        //    return await repo.AllReadonly<Booking>()
        //        .AnyAsync(c => c.Id == id);
        //}

        //public async Task<Booking> FindBookingById(int id)
        //{
        //    return await repo.GetByIdAsync<Booking>(id);
        //}

        //public async Task<Customer> FindCustomerById(int id)
        //{
        //    return await repo.GetByIdAsync<Customer>(id);
        //}

        //public async Task<Car> GetCarById(int id)
        //{
        //    return await repo.GetByIdAsync<Car>(id);
        //}
    }
}

