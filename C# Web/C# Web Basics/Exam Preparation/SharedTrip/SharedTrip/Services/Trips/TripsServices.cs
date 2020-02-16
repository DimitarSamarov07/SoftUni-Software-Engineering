using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services.Trips
{
    using System.Globalization;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using Models;
    using ViewModels.Trips;

    public class TripsServices:ITripsServices
    {
        private readonly ApplicationDbContext db;

        public TripsServices()
        {
            this.db = new ApplicationDbContext();
        }
        public void CreateTrip(AddTripViewModel model)
        {
            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                Description = model.Description,
                DepartureTime = DateTime
                    .ParseExact(model.DepartureTime,"dd.MM.yyyy HH:mm",CultureInfo.InvariantCulture),
                ImagePath = model.ImagePath,
                Seats = model.Seats
            };

            
            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public AllTripsViewModel GetAll()
        {
            
            AllTripsViewModel model = new AllTripsViewModel
            {
                Trips = this.db.Trips
                    .Select(x => new AddTripViewModel
                    {
                        Id = x.Id,
                        StartPoint = x.StartPoint,
                        EndPoint = x.EndPoint,
                        DepartureTime = x.DepartureTime.ToString("dd.mm.yyyy HH:mm"),
                        Description = x.Description,
                        ImagePath = x.ImagePath,
                        Seats = x.Seats - x.UserTrips.Count(z => z.TripId==x.Id)
                    })
                    .ToList()
            };


            return model;
        }

        public AddTripViewModel GetTripById(string tripId)
        {
            var trip = this.db.Trips.Find(tripId);
            var userTrip = this.db.UsersTrips.Where(x=>x.TripId==tripId);
            if (trip==null)
            {
                return null;
            }
            return new AddTripViewModel
            {
                Id = trip.Id,
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = trip.DepartureTime.ToString("dd.mm.yyyy HH:mm"),
                Description = trip.Description,
                ImagePath = trip.ImagePath,
                Seats = trip.Seats - userTrip.Count()
            };
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            var trip = this.db.Trips.Find(tripId);
            var user = this.db.Users.Find(userId);

            var userTrip = new UserTrip
            {
                Trip = trip,
                User = user
            };

            this.db.UsersTrips.Add(userTrip);
            this.db.SaveChanges();
        }

        public bool IsUserInTrip(string tripId, string userId)
        {
            var isInTheTrip = this.db.UsersTrips
                                  .FirstOrDefault(x => x.TripId == tripId && x.UserId == userId) != null;
            return isInTheTrip;
        }

        public bool IsTripFull(string tripId)
        {
            var trip = this.db.Trips.Find(tripId);
            var seatsTaken = this.db.UsersTrips.Count(x => x.TripId == tripId);
            if (trip.Seats==seatsTaken)
            {
                return true;
            }

            return false;
        }
    }
}
