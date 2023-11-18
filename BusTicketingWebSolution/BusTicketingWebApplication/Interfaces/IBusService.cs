using BusModelLibrary;

namespace BusTicketingWebApplication.Interfaces
{
    public interface IBusService
    {
        List<Bus> GetBuses();
        Bus Add(Bus bus);
    }
}
