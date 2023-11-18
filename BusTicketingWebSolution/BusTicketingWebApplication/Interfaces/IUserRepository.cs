using BusTicketingWebApplication.Models;

namespace BusTicketingWebApplication.Interfaces
{
    public interface IUserRepository
    {
        public User Add(User item);
        public User Delete(string key);
        public User GetById(string key);
        public IList<User> GetAll();
        public User Update(User item);
    }
}
