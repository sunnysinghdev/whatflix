using System;
using System.Collections.Generic;

namespace WhatFlix.Service
{
    public interface IMovieService
    {
        IEnumerable<Object> GetAllMovie(string text);
    }
}
