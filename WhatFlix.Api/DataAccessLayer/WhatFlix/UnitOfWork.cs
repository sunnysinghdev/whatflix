
using WhatFlix.Persistance;

namespace DataAccessLayer.WhatFlix
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICreditRepository Credits { get; }

        public IMovieRepositry Movies { get; }
        
        private MovieContext context;
        public UnitOfWork(MovieContext context)
        {
            //Credits = _credit;
            this.context = context;
            Movies = new MovieRepository(context);
            Credits = new CreditRepository(context);
            //Movies = new MovieRepository(context);
        }
        public void Dispose()
        {
            this.context.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}