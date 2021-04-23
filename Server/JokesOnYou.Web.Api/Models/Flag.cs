﻿using JokesOnYou.Web.Api.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models
{
    public class Flag
    {
        public int Id { get; set; }
        public Reason Reason { get; set; }
        public User Issuer { get; set; }
        public DateTime Created { get; } = DateTime.Now;
        public IFlaggable Flagged { get; set; }
    }
}
