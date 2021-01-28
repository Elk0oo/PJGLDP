using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Entity;

namespace Xamarin.Repository.Interfaces
{
    public interface ISpaceRepository
    {
        Task<List<Space>> GetSpaces();

        Task<Space> GetOneSpace(int idSpace);

        Task<bool> UpdateSpace(Space spaceObject);

        Task<bool> DeleteSpace(int idSpace);

        Task<bool> CreateSpace(Space spaceObject);
        
    }
}
