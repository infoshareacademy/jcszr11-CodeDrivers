﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers.Models
{
    internal class Admin
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

    }
}
