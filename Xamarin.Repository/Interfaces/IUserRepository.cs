using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Entity;

namespace Xamarin.Repository.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
    }
}
