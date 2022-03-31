﻿using System;
using System.Collections.Generic;

namespace RocketElevatorREST.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Batteries = new HashSet<Battery>();
        }

        public long Id { get; set; }
        public string? Title { get; set; }
        public long? UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Battery> Batteries { get; set; }
    }
}