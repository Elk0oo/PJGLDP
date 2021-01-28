using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Entity;

namespace Xamarin.Template.ViewModels
{
    public class EspaceViewModel : BaseModel
    {
        private Space _space;
        public EspaceViewModel()
        {
            // set some default here for example
            _space = new Space
            {
                Type = "Salle",
                Picture = "https://cdn.nemesis-studio.com/wp-content/uploads/2018/01/reunion-efficace-nemesis-studio.png",               
            };


        }

        public int Capacity
        {
            get { return _space.Capacity; }
            set
            {
                _space.Capacity = value;
                OnPropertyChanged("Capacity");
                OnPropertyChanged("SpaceRecap");
            }
        }

        public string Name
        {
            get { return _space.Name; }
            set
            {
                _space.Name = value;
                OnPropertyChanged("Name");
                OnPropertyChanged("SpaceRecap");
            }
        }

        public string Description
        {
            get { return _space.Description; }
            set
            {
                _space.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public string Picture
        {
            get { return _space.Picture; }
            set
            {
                _space.Picture = value;
                OnPropertyChanged("Picture");
            }
        }

        public string Type
        {
            get { return _space.Type; }
            set
            {
                _space.Type = value;
                OnPropertyChanged("Type");
            }
        }


        public string SpaceRecap
        {
            get { return _space.SpaceRecap(); }
        }
    }
}

