using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Entity


{
    public class Space
    {
        public int IdSpace { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public string SpaceRecap()
        { return $"Êtes-vous sur de vouloir créer la réunion : '{Name}' avec {Capacity}  personne(s) ?"; }
        public ICollection<Booking> Bookings { get; set; }
        public Space()
        {
            Bookings = new List<Booking>();
        }
    }
}
