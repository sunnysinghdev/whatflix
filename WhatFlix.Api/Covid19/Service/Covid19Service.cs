using System;
using System.Linq;
using System.Collections.Generic;
using Covid19;
using Covid19.Domain;
using Covid19.Repository;
using DataAccessLayer.Covid19;
using System.Threading.Tasks;

namespace Covid19.Service
{
    public class Covid19Service //: ILocationService
    {
        private IUnitOfWork unitOfWork;
        public Covid19Service(Covid19DbContext context)
        {
            //  this.unitOfWork = unitOfWork;
            this.unitOfWork = new UnitOfWork(context);
        }

        public async Task<IEnumerable<Location>> GetAll()
        {

            return await this.unitOfWork.Locations.GetAll();
            //return new [] { new Location { zipcode = 560076, area="test" }};
        }
        public void Add(Location location)
        {
            location.id = location.zipcode.ToString();
            this.unitOfWork.Locations.Add(location);
            //return new [] { new Location { zipcode = 560076, area="test" }};
        }


    }
}