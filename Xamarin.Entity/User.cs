using System;
using System.Collections;
using System.Collections.Generic;

namespace Xamarin.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Booking> Bookings { get; set; }

        public User()
        {
            Bookings = new List<Booking>();
        }
    }
}
