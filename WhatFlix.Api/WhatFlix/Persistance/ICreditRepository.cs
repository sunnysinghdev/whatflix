using System;
using System.Collections.Generic;
using WhatFlix.Domain.Model;

namespace WhatFlix.Persistance
{

public interface ICreditRepository : IRepository<Credit>
{
    IEnumerable<Credit> GetByActor(string text);
}
}