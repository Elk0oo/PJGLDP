using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Entity
{
    public class Booking
    {
        public int Id { get; set; }
        public int NbAttendees { get; set; }
        public DateTime Date { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public Space Space { get; set; }
        public int SpaceId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
