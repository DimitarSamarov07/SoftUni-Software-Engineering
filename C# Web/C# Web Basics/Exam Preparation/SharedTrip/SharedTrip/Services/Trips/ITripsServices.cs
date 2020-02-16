namespace SharedTrip.Services.Trips
{
    using System.Collections.Generic;
    using ViewModels.Trips;

    public interface ITripsServices
    {
        void CreateTrip(AddTripViewModel model);
        AllTripsViewModel GetAll();

        AddTripViewModel GetTripById(string tripId);

        void AddUserToTrip(string tripId, string userId);

        bool IsUserInTrip(string tripId, string userId);
        bool IsTripFull(string tripId);
    }
}
