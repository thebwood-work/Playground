﻿using System;
using System.Collections.Generic;

namespace Locations.Infrastructure.Entities
{
    public partial class State
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}
