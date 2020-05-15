using System.Collections.Generic;
using WhatFlix.Domain.Model;

namespace WhatFlix.Persistance
{

    public interface IMovieRepositry: IRepository<Movie>
    {
        IEnumerable<Movie> GetByTitle(string text);
    }
}