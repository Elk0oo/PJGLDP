using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Entity;
using Xamarin.Template.Models;

namespace Xamarin.Template.ViewModels
{
    public class ReservationViewModel : BaseModel
    {
        private BookingModel _booking;
        public ReservationViewModel()
        {
            _booking = new BookingModel
            {
                Date = DateTime.Now,
                StartHour = DateTime.Now.TimeOfDay,
                EndHour = DateTime.Now.AddHours(1).TimeOfDay
            };
        }

        public TimeSpan StartHour
        {
            get { return _booking.StartHour; }
            set
            {
                _booking.StartHour = value;
                OnPropertyChanged("StartHour");
            }
        }

        public int NbAttendees
        {
            get { return _booking.NbAttendees; }
            set
            {
                _booking.NbAttendees = value;
                OnPropertyChanged("NbAttendees");
            }
        }

        public TimeSpan EndHour
        {
            get { return _booking.EndHour; }
            set
            {
                _booking.EndHour = value;
                OnPropertyChanged("EndHour");
            }
        }

        public DateTime Date
        {
            get { return _booking.Date; }
            set
            {
                _booking.Date = value;
                OnPropertyChanged("Date");
            }
        }



    }
}
