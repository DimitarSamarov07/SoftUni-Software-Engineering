using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Controllers
{
    using Services.Trips;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using ViewModels.Trips;

    public class TripsController : Controller
    {
        private readonly ITripsServices service;
        //TODO: Check Security
        //TODO: Check Redirections
        public TripsController(ITripsServices service)
        {
            this.service = service;
        }

        public HttpResponse Add()
        {
            return !this.IsUserLoggedIn() 
                ? this.Redirect("/Users/Login") 
                : this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripViewModel model)
        {
            if (!this.IsUserLoggedIn())
            {
                this.Redirect("/Users/Login");
            }

            //Whitespace check included

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                return this.View();
            }

            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                return this.View();
            }

            if (string.IsNullOrWhiteSpace(model.DepartureTime))
            {
                return this.View();
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                return this.View();
            }

            if (model.Description?.Length > 80|| model.Description?.Length<10)
            {
                return this.View();
                //The should be some kind of description. I changed the min to 10.
            }

            this.service.CreateTrip(model);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse All()
        {
            return !this.IsUserLoggedIn() ? this.Redirect("/Users/Login") : this.View(this.service.GetAll());
        }

        public HttpResponse Details(string tripId)
        {
            var trip = this.service.GetTripById(tripId);
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return trip?.Id==null ? this.Redirect("/Trips/All") : this.View(trip);
            //If someone tries to get details of non existing he will be redirected to All

        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                this.Redirect("/Users/Login");
            }
            if (this.service.IsUserInTrip(tripId, this.User))
            {
                return this.Redirect($"/Trips/Details?id={tripId}");
            }

            if (this.service.IsTripFull(tripId))
            {
                return this.Redirect($"/Trips/Details?id={tripId}");
            }

            this.service.AddUserToTrip(tripId, this.User);
            return this.Redirect("/Trips/All");
        }
    }
}
