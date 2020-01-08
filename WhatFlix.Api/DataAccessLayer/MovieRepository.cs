using System;
using System.Web;
using System.IO;
using System.Linq;
//using System.Reflection;
using System.Data.OleDb;
using System.Data;
using System.Text;
using System.Collections.Generic;
using WhatFlix.Common;
using System.Data.Common;
using WhatFlix.Api.Model;
using CsvHelper;

namespace WhatFlix.DataAccessLayer
{
    public class MovieRepository : Repository<Movie>, IMovieRepositry
    {
        MovieContext _context;
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