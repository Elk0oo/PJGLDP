using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Template.Models
{
    public class BookingModel
    {
        public DateTime Date { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
        public int NbAttendees { get; set; }
    }
}
