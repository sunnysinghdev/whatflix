using System;

namespace WhatFlix.Persistance
{
     public interface IUnitOfWork : IDisposable
    {
        ICreditRepository Credits { get; }
        IMovieRepositry Movies { get; }
    }
}