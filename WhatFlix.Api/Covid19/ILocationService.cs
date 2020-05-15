using System.Collections.Generic;
using Covid19.Domain;
namespace Covid19
{
    public interface ILocationService
    {
        IEnumerable<Location> GetAll();
    }
}