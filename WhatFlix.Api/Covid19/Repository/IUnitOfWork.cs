using System;
using System.Collections.Generic;
namespace Covid19.Repository
{

    public interface IUnitOfWork : IDisposable
    {
        ILocationRepository Locations { get; set; }
    }
}