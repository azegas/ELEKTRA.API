using ELEKTRA.API.Interfaces;

namespace ELEKTRA.API.Services
{
    // The WelcomeService class already has a GetWelcomeMessage method that
    // matches the method signature in the IWelcomeService interface
    public class WelcomeService : IWelcomeService
    {
        DateTime _serviceCreated;
        Guid _serviceId;

        // fields are set in CONSTRUCTOR and they never change
        // for the LIFETIME of the SERVICE INSTANCE
        public WelcomeService()
        {
            _serviceCreated = DateTime.Now;
            _serviceId = Guid.NewGuid();    
        }

        public string GetWelcomeMessage()
        {
            return $"Welcome to the ELEKTRA API! This service was created at {_serviceCreated} with the ID {_serviceId}";
        }
    }
}
