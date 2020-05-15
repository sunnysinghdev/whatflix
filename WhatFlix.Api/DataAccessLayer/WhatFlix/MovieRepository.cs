using System;
using System.Web;
using System.IO;
using System.Linq;
//using System.Reflection;
using System.Data.OleDb;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.Common;
using WhatFlix.Domain.Model;
using WhatFlix.Persistance;
using CsvHelper;

namespace DataAccessLayer.WhatFlix
{
    public class MovieRepository : Repository<Movie>, IMovieRepositry
    {
        private MovieContext _context;
        public MovieRepository(MovieContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetByTitle(string text)
        {
            throw new NotImplementedException();
        }
    }
}