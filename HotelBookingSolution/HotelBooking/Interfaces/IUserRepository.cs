﻿using HotelBooking.Models;

namespace HotelBooking.Interfaces
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
