using Covid19.Repository;

namespace DataAccessLayer.Covid19 {
    public class UnitOfWork : IUnitOfWork
    {
        public ILocationRepository Locations { get ; set; }
        private Covid19DbContext _context;
        public UnitOfWork(Covid19DbContext context)
        {
            _context = context;
            this.Locations = new LocationRepository(_context);
        }
        public void Dispose()
        {
            //throw new System.NotImplementedException();
        }
    }
}